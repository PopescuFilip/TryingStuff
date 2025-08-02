using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public sealed partial record ExistingDirectory(DirectoryPath DirectoryPath) : ExistingPath
{
    public DirectoryPath DirectoryPath { get; init; } = Directory.Exists(DirectoryPath)
        ? DirectoryPath
        : throw new IOObjectCreationException("Inexistent directory", DirectoryPath);

    public string Name { get; init; } = Path.GetFileName(DirectoryPath);

    public static bool TryCreate(string path, out ExistingDirectory existingDirectory)
    {
        existingDirectory = null;

        try
        {
            if (!NonEmptyString.TryCreate(Path.GetDirectoryName(path), out var parentPath))
                return false;

            existingDirectory = new ExistingDirectory(new DirectoryPath(parentPath));
            return true;
        }
        catch (IOObjectCreationException)
        {
            existingDirectory = null;
            return false;
        }
    }

    public static implicit operator string(ExistingDirectory e) => e.DirectoryPath.Path.Value;
    public static implicit operator NonEmptyString(ExistingDirectory e) => e.DirectoryPath.Path;
    public static implicit operator DirectoryPath(ExistingDirectory e) => e.DirectoryPath;
    public static explicit operator ExistingDirectory(string @string) => new(new DirectoryPath((NonEmptyString)@string));
}