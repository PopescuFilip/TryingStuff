namespace TryingZip;

public readonly struct FileExtension
{
    private readonly NonEmptyString _value;

    public FileExtension() : this(string.Empty) {}

    public static FileExtension From(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
            throw new ArgumentException($"{nameof(extension)} cannot be null or whitespace");

        extension = extension[0] == '.'
            ? extension
            : '.' + extension;

        return new FileExtension(extension);
    }

    private FileExtension(string extension) { _value = new(extension); }

    public static implicit operator string(FileExtension e) => e._value;
    public static implicit operator FileExtension(string extension) => new(extension);

    public WildcardExtension ToWildcard() => new('*' + _value);
}

public readonly struct WildcardExtension(string value)
{
    private readonly NonEmptyString _value = new(value);

    public static implicit operator string(WildcardExtension e) => e._value;
}