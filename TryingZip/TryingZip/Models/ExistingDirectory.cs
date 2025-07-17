namespace TryingZip.Models;

public readonly struct ExistingDirectory(string directoryPath)
{
    private readonly string _directoryPath = Directory.Exists(directoryPath) ? directoryPath : throw new ArgumentException("Invalid directory path");

    public static implicit operator string(ExistingDirectory e) => e._directoryPath;

    public string GetName() => Path.GetFileName(_directoryPath);
}