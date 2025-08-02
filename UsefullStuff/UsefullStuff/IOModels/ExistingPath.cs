namespace UsefullStuff.IOModels;

public abstract record ExistingPath
{
    public static readonly NoPath NoPath = new();
};

public sealed record NoPath : ExistingPath { internal NoPath() {} }

public sealed partial record ExistingFile : ExistingPath;
public sealed partial record ExistingDirectory : ExistingPath;
public sealed partial record ExtensionPath : ExistingPath;