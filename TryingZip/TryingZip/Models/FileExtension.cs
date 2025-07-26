namespace TryingZip;

public readonly struct FileExtension
{
    private readonly NonEmptyString _value;

    public FileExtension() : this(string.Empty) {}

    public FileExtension(string extension)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(extension, nameof(extension));

        extension = extension[0] == '.'
            ? extension
            : '.' + extension;

        _value = new(extension);
    }

    public static implicit operator string(FileExtension e) => e._value;
    public static implicit operator FileExtension(string extension) => new(extension);

    public WildcardExtension ToWildcard() => new('*' + _value);
}

public readonly struct WildcardExtension(string value)
{
    private readonly NonEmptyString _value = new(value);

    public static implicit operator string(WildcardExtension e) => e._value;
}