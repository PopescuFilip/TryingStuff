using UsefullStuff.IOModels;

namespace TryingZip.Serivces;

public class BigUnZiper(IUnZiper _unZiper) : IBigUnZiper
{
    public void UnzipAll(List<ExistingPath> zipFiles, ExistingDirectory unzipLocation)
    {
        Parallel.ForEach(zipFiles, zipFile =>
        {
            _unZiper.UnZip(zipFile, unzipLocation);
        });
    }
}