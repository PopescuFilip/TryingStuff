namespace TryingZip;

public readonly struct ExistingFile(string filePath)
{
    private readonly NonEmptyString _filePath = File.Exists(filePath)
        ? new(filePath)
        : throw new IOObjectCreationException($"Inexistent file", filePath);

    public ExistingFile() : this(string.Empty) {}

    public static implicit operator string(ExistingFile e) => e._filePath;
    public static implicit operator ExistingFile(string filePath) => new(filePath);

    public string GetName() => Path.GetFileNameWithoutExtension(_filePath);
}