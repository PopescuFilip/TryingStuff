namespace TryingZip;

public interface IDirectoryCreator
{
    ExistingDirectory Create(string directoryPath);
}