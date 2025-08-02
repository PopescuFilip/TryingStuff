using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public record FilePath(NonEmptyString Path)
{
    public static implicit operator string(FilePath path) => path.Path.Value;
    public static implicit operator NonEmptyString(FilePath path) => path.Path;
    public static explicit operator FilePath(string path) => new((NonEmptyString)path);
}