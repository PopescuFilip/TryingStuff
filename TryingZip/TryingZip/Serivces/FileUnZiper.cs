using System.IO.Compression;
using TryingZip.Models;

namespace TryingZip.Serivces;

public class FileUnZiper : IFileUnZiper
{
    public ExistingDirectory UnZip(ExistingFile file, ExistingDirectory destination)
    {
        ZipFile.ExtractToDirectory(file, destination);
        return new ExistingDirectory(Path.Combine(destination, file.GetName()));
    }
}