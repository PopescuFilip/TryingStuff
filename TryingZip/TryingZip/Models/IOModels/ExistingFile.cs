namespace TryingZip;

public record ExistingFile(string FilePath)
{
    private readonly NonEmptyString _filePath = File.Exists(FilePath)
        ? new(FilePath)
        : throw new IOObjectCreationException($"Inexistent file", FilePath);

    public ExistingFile() : this(string.Empty) {}

    public static implicit operator string(ExistingFile e) => e._filePath;
    public static implicit operator ExistingPath(ExistingFile e) => new(e._filePath);
    public static explicit operator ExistingFile(string filePath) => new(filePath);

    public string GetName() => Path.GetFileNameWithoutExtension(_filePath);
}