namespace UsefullStuff.Common;

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
    public NonEmptyString Value { get; init; } = Value[0] == '*'
        ? Value
        : throw new ArgumentException("Value should start with *", nameof(Value));
    public static readonly WildcardExtension Any = new(new("*"));

    public static implicit operator string(WildcardExtension e) => e.Value;
}