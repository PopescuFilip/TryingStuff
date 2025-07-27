using UsefullStuff.Common;
using IOPath = System.IO.Path;

namespace UsefullStuff.IOModels;

public record ExistingFile(NonEmptyString Path) : FilePath(Path)
{
    public override NonEmptyString Path { get; init; } = File.Exists(Path)
        ? new(Path)
        : throw new IOObjectCreationException("Inexistent file", Path);

    public static implicit operator string(ExistingFile e) => e.Path;
    public static implicit operator NonEmptyString(ExistingFile e) => e.Path;
    public static implicit operator ExistingPath(ExistingFile e) => new(e.Path);
    public static explicit operator ExistingFile(string filePath) => new((NonEmptyString)filePath);

    public string GetName() => IOPath.GetFileNameWithoutExtension(Path);
}