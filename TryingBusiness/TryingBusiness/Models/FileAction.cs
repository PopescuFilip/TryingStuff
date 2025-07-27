namespace TryingBusiness;

public abstract record FileAction(string FilePath, bool IsEnabled);
public sealed record DeleteAction(string SourcePath, bool IsEnabled, string BackupPath) : FileAction(SourcePath, IsEnabled);
public sealed record CopyAction(string SourcePath, bool IsEnabled, string DestinationPath, bool Mirror) : FileAction(SourcePath, IsEnabled);
public sealed record ThirdPartyAction(string FilePath, bool IsEnabled) : FileAction(FilePath, IsEnabled);