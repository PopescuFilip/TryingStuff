namespace UsefullStuff.IOModels;

public abstract record BasePath(string Path);
public sealed record NonExistent() : BasePath(string.Empty)
{
}