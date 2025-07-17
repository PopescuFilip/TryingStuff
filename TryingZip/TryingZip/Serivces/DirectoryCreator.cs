using TryingZip.Models;

namespace TryingZip.Serivces;

public class DirectoryCreator : IDirectoryCreator
{
    public ExistingDirectory Create(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        return new ExistingDirectory(directoryPath);
    }
}