using System.IO.Compression;

namespace TryingZip.Serivces;

public class ZipUnZiper : IUnZiper
{
    public void UnZip(ExistingPath pathToZip, ExistingDirectory destinationDirectory) =>
        ZipFile.ExtractToDirectory(pathToZip, destinationDirectory);
}