using UsefullStuff.IOModels;

namespace TryingZip;

public interface IUnZiper
{
    public void UnZip(ExistingPath pathToZip, ExistingDirectory destinationDirectory);
}