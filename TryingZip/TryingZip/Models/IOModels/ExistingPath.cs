namespace TryingZip;

public readonly struct ExistingPath(string path)
{
    private readonly NonEmptyString _path = Path.Exists(path)
        ? new(path)
        : throw new IOObjectCreationException("Inexistent directory or file", path);

    public ExistingPath() : this(string.Empty) {}

    public static implicit operator string(ExistingPath e) => e._path;
}