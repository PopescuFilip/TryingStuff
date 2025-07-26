namespace TryingZip;

public readonly struct ExistingDirectory(string directoryPath)
{
    private readonly NonEmptyString _directoryPath = Directory.Exists(directoryPath)
        ? new(directoryPath)
        : throw new IOObjectCreationException($"Inexistent directory", directoryPath);

    public ExistingDirectory() : this(string.Empty) {}

    public static implicit operator string(ExistingDirectory e) => e._directoryPath;

    public string GetName() => Path.GetFileName(_directoryPath);
}