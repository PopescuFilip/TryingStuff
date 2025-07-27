namespace UsefullStuff.IOModels;

public class IOObjectCreationException(string message, string path) : ArgumentException(message)
{
    public string InvalidPath { get; init; } = path;
}