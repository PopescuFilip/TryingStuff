using UsefullStuff.Common;

namespace UsefullStuff.IOModels;

public record DirectoryPath(NonEmptyString Path)
{
    public static implicit operator string(DirectoryPath path) => path.Path;
    public static implicit operator NonEmptyString(DirectoryPath path) => path.Path;
    public static explicit operator DirectoryPath(string path) => new((NonEmptyString)path);
}