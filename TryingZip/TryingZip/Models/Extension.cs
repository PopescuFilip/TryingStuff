namespace TryingZip.Models;

public readonly struct Extension(string extension)
{
    private readonly string _value = extension.All(char.IsLetterOrDigit) ? extension : throw new ArgumentException($"invalid extension {extension}.");

    public static implicit operator string(Extension e) => e._value;
    public static implicit operator Extension(string extension) => new(extension);
    public WildcardExtension ToWildcard() => new(this);
}

public readonly struct WildcardExtension(Extension e)
{
    private readonly string _value = "*." + e;

    public static implicit operator string(WildcardExtension e) => e._value;
}