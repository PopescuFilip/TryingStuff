using UsefullStuff.Common;
using IOPath = System.IO.Path;

namespace UsefullStuff.IOModels;

public abstract record BasePath;
public sealed record NonExistent : BasePath;
public record ValidPath(NonEmptyString Path) : BasePath
{
    public virtual NonEmptyString Path { get; init; } = IOPath.GetInvalidPathChars().Any(Path.Value.Contains)
        ? throw new ArgumentException($"{Path} contains invalid characters", nameof(Path))
        : Path;

    public static implicit operator string(ValidPath path) => path.Path;
    public static implicit operator NonEmptyString(ValidPath path) => path.Path;
    public static explicit operator ValidPath(string path) => new((NonEmptyString)path);
}
public record FilePath(NonEmptyString Path) : ValidPath(Path);
public record DirectoryPath(NonEmptyString Path) : ValidPath(Path);
public record ExtensionPath(DirectoryPath ParentPath, WildcardExtension[] WildcardExtensions) : BasePath(ParentPath)
{
    public static bool TryCreate(string path, out ExtensionPath extensionPath)
    {
        try
        {
            extensionPath = new ExtensionPath(path);
            return true;
        }
        catch (Exception)
        {
            extensionPath = null;
            return false;
        }
    }

    private ExtensionPath(string path) : this(new(GetParentPath(path)), GetWildCardExtensions(path)) {}

    private static NonEmptyString GetParentPath(string path) => (NonEmptyString)IOPath.GetDirectoryName(path);
    private static WildcardExtension[] GetWildCardExtensions(string path) => IOPath.GetFileName(path)
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s) && s[0] == '*')
            .Select(s => new WildcardExtension(new(s)))
            .ToArray();
}