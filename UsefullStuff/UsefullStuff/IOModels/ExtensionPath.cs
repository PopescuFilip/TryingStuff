using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public sealed partial record ExtensionPath(ExistingDirectory ParentPath, WildcardExtension[] WildcardExtensions) : ExistingPath
{
    public static bool TryCreate(string path, out ExtensionPath extensionPath)
    {
        extensionPath = null;

        if (!ExistingDirectory.TryCreate(path, out var existingDirectory))
            return false;

        var wildcardExtensions = GetWildCardExtensions(path);
        if (wildcardExtensions.Length == 0)
            return false;

        extensionPath = new ExtensionPath(existingDirectory, wildcardExtensions);
        return true;
    }

    private static WildcardExtension[] GetWildCardExtensions(string path) => Path.GetFileName(path)
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s) && s[0] == '*')
            .Select(s => new WildcardExtension(new(s)))
            .ToArray();
}