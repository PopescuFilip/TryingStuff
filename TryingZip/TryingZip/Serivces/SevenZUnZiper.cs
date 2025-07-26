using SharpCompress.Archives;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;

namespace TryingZip.Serivces;

public class SevenZUnZiper(IDirectoryCreator _directoryCreator) : IFileUnZiper
{
    public ExistingDirectory UnZip(ExistingFile file, ExistingDirectory destination)
    {
        var actualDestination = _directoryCreator.Create(Path.Combine(destination, file.GetName()));

        using var archive = SevenZipArchive.Open(file);
        foreach (var entry in archive.Entries)
        {
            entry.WriteToDirectory(actualDestination, new ExtractionOptions
            {
                ExtractFullPath = true
            });
        }
        return actualDestination;
    }
}