namespace TryingZip.Models;

public readonly struct ExistingFile(string filePath)
{
    private readonly string _filePath = File.Exists(filePath) ? filePath : throw new ArgumentException("Invalid directory path");

    public static implicit operator string(ExistingFile e) => e._filePath;
    public static implicit operator ExistingFile(string filePath) => new(filePath);

    public string GetName() => Path.GetFileNameWithoutExtension(_filePath);
}