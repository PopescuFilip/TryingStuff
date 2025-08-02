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
        file = null;

        if (!NonEmptyString.TryCreate(path, out var nonEmptyString))
            return false;

        var filePath = new FilePath(nonEmptyString);

        if (!ExistingFile.TryCreate(filePath, out var existingFile))
            return false;

        file = new File(existingFile);
        return true;
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
            .Where(s => !string.IsNullOrWhiteSpace(s) && s[0] =='*')
            .Select(s => new WildcardExtension(new(s)))
            .ToArray();

        extensions = new Extensions((ExistingDirectory)parentDirectory, wildcardExtensions);
        return true;
    }
}