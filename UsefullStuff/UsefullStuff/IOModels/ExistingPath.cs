using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public record ExistingPath(NonEmptyString Path)
{
    private readonly NonEmptyString Path = System.IO.Path.Exists(Path)
        ? Path
        : throw new IOObjectCreationException("Inexistent directory or file", Path);

    public static implicit operator string(ExistingPath e) => e.Path;
}