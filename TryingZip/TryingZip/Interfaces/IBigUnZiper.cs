using TryingZip.Models;

namespace TryingZip;

public interface IBigUnZiper
{
    public List<ExistingDirectory> UnzipAll(List<ExistingFile> zipFiles, ExistingDirectory unzipLocation);
}