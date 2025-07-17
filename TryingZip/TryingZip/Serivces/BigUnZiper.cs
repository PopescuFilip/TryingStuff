using System.Collections.Concurrent;
using TryingZip.Models;

namespace TryingZip.Serivces;

public class BigUnZiper(IFileUnZiper _unZiper) : IBigUnZiper
{
    public List<ExistingDirectory> UnzipAll(List<ExistingFile> zipFiles, ExistingDirectory unzipLocation)
    {
        using var bc = new BlockingCollection<ExistingDirectory>();

        Parallel.ForEach(zipFiles, zipFile =>
        {
            var existingDirectory = _unZiper.UnZip(zipFile, unzipLocation);
            bc.Add(existingDirectory);
        });
        bc.CompleteAdding();

        return ConsumeBlockingCollection(bc, zipFiles.Count);
    }

    private static List<T> ConsumeBlockingCollection<T>(BlockingCollection<T> bc, int capacity = 0)
    {
        var list = capacity == 0 ? [] : new List<T>(capacity);
        while (!bc.IsCompleted)
        {
            list.Add(bc.Take());
        }
        return list;
    }
}