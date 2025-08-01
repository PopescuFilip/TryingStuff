using UsefullStuff.Common;
using IOPath = System.IO.Path;

namespace UsefullStuff.IOModels;

public record ExtensionPath(DirectoryPath ParentPath, WildcardExtension[] WildcardExtensions)
{
    public static bool TryCreate(string path, out ExtensionPath extensionPath)
    {
        extensionPath = null;

        if (!NonEmptyString.TryCreate(IOPath.GetDirectoryName(path), out var parentPath))
            return false;

        var wildcardExtensions = GetWildCardExtensions(parentPath);
        if (wildcardExtensions.Length == 0)
            return false;

        extensionPath = new ExtensionPath(new(parentPath), wildcardExtensions);
        return true;
    }

    private static WildcardExtension[] GetWildCardExtensions(string path) => IOPath.GetFileName(path)
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s) && s[0] == '*')
            .Select(s => new WildcardExtension(new(s)))
            .ToArray();
}