namespace TryingZip;

public readonly struct ExistingDirectory
{
    private readonly NonEmptyString _directoryPath;

    public ExistingDirectory() : this(new(string.Empty)) {}

    public static ExistingDirectory Create(string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);
        return new ExistingDirectory(directoryPath);
    }

    private ExistingDirectory(string directoryPath) { _directoryPath = new(directoryPath); }

    public static implicit operator string(ExistingDirectory e) => e._directoryPath;

    public string GetName() => Path.GetFileName(_directoryPath);
}