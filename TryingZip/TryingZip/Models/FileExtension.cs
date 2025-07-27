using UsefullStuff;

namespace TryingZip;

public readonly record struct FileExtension(NonEmptyString Extension)
{
    public NonEmptyString Extension { get; init; } = Extension[0] == '.'
            ? Extension
            : new('.' + Extension);
    public WildcardExtension WildcardExtension { get; init; } = new(new('*' + Extension));

    public static implicit operator string(FileExtension e) => e.Extension;
    public static explicit operator FileExtension(string extension) => new((NonEmptyString)extension);

}

public readonly record struct WildcardExtension(NonEmptyString Value)
{
    public static readonly WildcardExtension Any = new(new("*"));

    public static implicit operator string(WildcardExtension e) => e.Value;
}