using UsefullStuff.IOModels;

namespace TryingBusinessImproved;

public abstract record DeleteSource;
public sealed record NonExistent : DeleteSource;
public sealed record File(ExistingFile ExistingFile) : DeleteSource
{
    public static bool TryCreate(string path, out File file)
    {
        file = null;

        if (!ExistingFile.TryCreate(path, out var existingFile))
            return false;

        file = new File(existingFile);
        return true;
    }
};

public sealed record Extensions(ExtensionPath ExtensionPath) : DeleteSource
{
    public static bool TryCreate(string path, out Extensions extensions)
    {
        extensions = null;

        if(!ExtensionPath.TryCreate(path, out var extensionPath))
            return false;

        extensions = new(extensionPath);
        return true;
    }
}