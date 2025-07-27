using UsefullStuff.Common;
using UsefullStuff.IOModels;
using IOFile = System.IO.File;
using IODirectory = System.IO.Directory;
using IOPath = System.IO.Path;

namespace TryingBusinessImproved;

public abstract record DeleteSource;
public sealed record NonExistent : DeleteSource;
public sealed record File(ExistingFile ExistingFile) : DeleteSource
{
    public static bool TryCreate(string path, out File file)
    {
        if (IOFile.Exists(path))
        {
            file = new File((ExistingFile)path);
            return true;
        }

        file = null;
        return false;
    }
};

public sealed record Extensions(ExistingDirectory ParentFolder, WildcardExtension[] WildcardExtensions) : DeleteSource
{
    public static bool TryCreate(string path, out Extensions extensions)
    {
        extensions = null;
        var parentDirectory = IOPath.GetDirectoryName(path);

        if (!IODirectory.Exists(parentDirectory))
            return false;

        var wildcardExtensions = IOPath.GetFileName(path)
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => new WildcardExtension(new(s)))
            .ToArray();

        extensions = new Extensions((ExistingDirectory)parentDirectory, wildcardExtensions);
        return true;
    }
}