namespace TryingZip;

public interface IFileUnZiper
{
    public ExistingDirectory UnZip(ExistingFile file, ExistingDirectory destination);
}