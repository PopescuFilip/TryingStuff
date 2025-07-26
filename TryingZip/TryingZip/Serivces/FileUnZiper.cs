using System.IO.Compression;

namespace TryingZip.Serivces;

public class FileUnZiper : IFileUnZiper
{
    public void UnZip(ExistingPath pathToZip, ExistingDirectory destinationDirectory) =>
        ZipFile.ExtractToDirectory(pathToZip, destinationDirectory);
}