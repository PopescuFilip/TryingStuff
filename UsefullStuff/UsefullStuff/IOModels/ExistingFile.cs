using UsefullStuff.Common;
using IOPath = System.IO.Path;

namespace UsefullStuff.IOModels;

public record ExistingFile(FilePath Path)
{
    public FilePath Path { get; init; } = File.Exists(Path)
        ? Path
        : throw new IOObjectCreationException("Inexistent file", Path);

    public static bool TryCreate(FilePath path, out ExistingFile existingFile)
    {
        try
        {
            existingFile = new ExistingFile(path);
            return true;
        }
        catch (IOObjectCreationException)
        {
            existingFile = null;
            return false;
        }
    }

    public static implicit operator string(ExistingFile e) => e.Path;
    public static implicit operator NonEmptyString(ExistingFile e) => e.Path;
    public static implicit operator FilePath(ExistingFile e) => e.Path;
    public static implicit operator ExistingPath(ExistingFile e) => new(e.Path);
    public static explicit operator ExistingFile(string filePath) => new(new FilePath((NonEmptyString)filePath));

    public string GetName() => IOPath.GetFileNameWithoutExtension(Path);
}