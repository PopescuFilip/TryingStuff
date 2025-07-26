namespace TryingZip;

public readonly record struct NonEmptyString(string Value)
{
    public string Value { get; init; } = !string.IsNullOrWhiteSpace(Value)
        ? Value
        : throw new ArgumentException($"string cannot be null or whitespace", nameof(Value));

    public char this[int index] => Value[index];

    public static implicit operator string (NonEmptyString nonEmptyString) => nonEmptyString.Value;
    public static explicit operator NonEmptyString (string @string) => new(@string);
}