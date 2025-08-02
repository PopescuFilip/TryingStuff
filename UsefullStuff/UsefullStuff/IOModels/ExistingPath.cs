namespace UsefullStuff.IOModels;

public abstract record ExistingPath
{
    public static readonly NoPath NoPath = new();
};

public sealed record NoPath : ExistingPath { internal NoPath() {} }

public sealed partial record ExistingFile : ExistingPath;
public sealed partial record ExistingDirectory : ExistingPath;
public sealed partial record ExtensionPath : ExistingPath;

public static class ExistingPathExtensions
{
    public static string MapToString(this ExistingPath value) =>
        value.Map(
            (existingFile) => existingFile,
            (existingDirectory) => existingDirectory,
            (extensionPath) => extensionPath.ParentPath,
            (noPath) => string.Empty
            );

    public static T Map<T>(
        this ExistingPath value,
        Func<ExistingFile, T> mapExistingFile,
        Func<ExistingDirectory, T> mapExistingDirectory,
        Func<ExtensionPath, T> mapExtensionPath,
        Func<NoPath, T> mapNoPath) => value switch
        {
            ExistingFile existingFile => mapExistingFile(existingFile),
            ExistingDirectory existingDirectory => mapExistingDirectory(existingDirectory),
            ExtensionPath extensionPath => mapExtensionPath(extensionPath),
            NoPath noPath => mapNoPath(noPath),
            _ => throw new ArgumentException($"{value} is not a supported type", nameof(value))
        };

    public static void Match(
        this ExistingPath value,
        Action<ExistingFile> onExistingFile,
        Action<ExistingDirectory> onExistingDirectory,
        Action<ExtensionPath> onExtensionPath,
        Action<NoPath> onNoPath)
    {
        switch (value)
        {
            case ExistingFile existingFile:
                onExistingFile(existingFile);
                break;
            case ExistingDirectory existingDirectory:
                onExistingDirectory(existingDirectory);
                break;
            case ExtensionPath extensionPath:
                onExtensionPath(extensionPath);
                break;
            case NoPath noPath:
                onNoPath(noPath);
                break;
            default:
                throw new ArgumentException($"{value} is not a supported type", nameof(value));
        }
    }
}