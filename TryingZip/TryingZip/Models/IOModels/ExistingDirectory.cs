namespace TryingZip;

public record ExistingDirectory(NonEmptyString DirectoryPath)
{
    public NonEmptyString DirectoryPath { get; init; } = Directory.Exists(DirectoryPath)
        ? new(DirectoryPath)
        : throw new IOObjectCreationException("Inexistent directory", DirectoryPath);

    public string Name { get; init; } = Path.GetFileName(DirectoryPath);

    public static ExistingDirectory Create(string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);
        return new ExistingDirectory((NonEmptyString)directoryPath);
    }

    public static implicit operator string(ExistingDirectory e) => e.DirectoryPath;
}