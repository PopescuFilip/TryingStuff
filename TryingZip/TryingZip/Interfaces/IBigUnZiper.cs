namespace TryingZip;

public interface IBigUnZiper
{
    public void UnzipAll(List<ExistingPath> zipFiles, ExistingDirectory unzipLocation);
}