using System.IO.Compression;
using UsefullStuff.IOModels;

namespace TryingZip.Serivces;

public class ZipUnZiper : IUnZiper
{
    public void UnZip(ExistingPath pathToZip, ExistingDirectory destinationDirectory) =>
        ZipFile.ExtractToDirectory(pathToZip, destinationDirectory);
}