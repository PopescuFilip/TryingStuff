using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public record ExistingDirectory(DirectoryPath DirectoryPath)
{
    public DirectoryPath DirectoryPath { get; init; } = Directory.Exists(DirectoryPath)
        ? DirectoryPath
        : throw new IOObjectCreationException("Inexistent directory", DirectoryPath);

    public string Name { get; init; } = Path.GetFileName(DirectoryPath);

    public static bool TryCreate(DirectoryPath path, out ExistingDirectory existingDirectory)
    {
        try
        {
            existingDirectory = new ExistingDirectory(path);
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