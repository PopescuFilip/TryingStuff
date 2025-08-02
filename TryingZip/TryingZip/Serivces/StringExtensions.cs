using UsefullStuff.IOModels;

namespace TryingZip.Serivces;

public static class StringExtensions
{
    public static ExistingDirectory CreateDirectory(this string path)
    {
        Directory.CreateDirectory(path);
        return (ExistingDirectory)path;
    }
}