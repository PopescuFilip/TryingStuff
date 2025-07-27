using UsefullStuff;

namespace TryingZip;

public record ExistingFile(NonEmptyString FilePath)
{
    public NonEmptyString FilePath { get; init; } = File.Exists(FilePath)
        ? new(FilePath)
        : throw new IOObjectCreationException("Inexistent file", FilePath);

    public static implicit operator string(ExistingFile e) => e.FilePath;
    public static implicit operator ExistingPath(ExistingFile e) => new(e.FilePath);
    public static explicit operator ExistingFile(string filePath) => new((NonEmptyString)filePath);

    public string GetName() => Path.GetFileNameWithoutExtension(FilePath);
}