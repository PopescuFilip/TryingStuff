using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public sealed partial record ExistingFile(FilePath FilePath) : ExistingPath
{
    public FilePath FilePath { get; init; } = File.Exists(FilePath)
        ? FilePath
        : throw new IOObjectCreationException("Inexistent file", FilePath);

    public static bool TryCreate(string path, out ExistingFile existingFile)
    {
        existingFile = null;
        try
        {
            if (!NonEmptyString.TryCreate(path, out var nonEmptyString))
                return false;

            existingFile = new ExistingFile(new FilePath(nonEmptyString));
            return true;
        }
        catch (IOObjectCreationException)
        {
            existingFile = null;
            return false;
        }
    }

    public static implicit operator string(ExistingFile e) => e.FilePath.Path.Value;
    public static implicit operator NonEmptyString(ExistingFile e) => e.FilePath.Path;
    public static implicit operator FilePath(ExistingFile e) => e.FilePath;
    public static explicit operator ExistingFile(string filePath) => new(new FilePath((NonEmptyString)filePath));
}