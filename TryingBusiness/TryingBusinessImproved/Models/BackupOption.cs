using UsefullStuff.IOModels;

namespace TryingBusinessImproved;

public record BackupOption(bool Backup);
public sealed record Backup(DirectoryPath BackupPath) : BackupOption(true);
public sealed record NoBackup() : BackupOption(false);