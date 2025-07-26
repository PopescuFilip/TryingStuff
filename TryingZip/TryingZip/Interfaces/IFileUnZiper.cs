namespace TryingZip;

public interface IFileUnZiper
{
    public void UnZip(ExistingPath pathToZip, ExistingDirectory destinationDirectory);
}