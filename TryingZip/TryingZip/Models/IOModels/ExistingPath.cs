namespace TryingZip;

public record ExistingPath(string Path)
{
    private readonly NonEmptyString _path = System.IO.Path.Exists(Path)
        ? new(Path)
        : throw new IOObjectCreationException("Inexistent directory or file", Path);

    public static implicit operator string(ExistingPath e) => e._path;
}