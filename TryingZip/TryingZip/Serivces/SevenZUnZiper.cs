using SharpCompress.Archives;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using UsefullStuff.IOModels;

namespace TryingZip.Serivces;

public class SevenZUnZiper : IUnZiper
{
    public void UnZip(ExistingPath pathToZip, ExistingDirectory destinationDirectory)
    {
        using var archive = SevenZipArchive.Open(pathToZip.MapToString());
        foreach (var entry in archive.Entries)
        {
            entry.WriteToDirectory(destinationDirectory, new ExtractionOptions
            {
                ExtractFullPath = true
            });
        }
    }
}