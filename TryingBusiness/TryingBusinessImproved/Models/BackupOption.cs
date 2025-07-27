using UsefullStuff.Common;

namespace TryingBusinessImproved;

public record BackupOption(bool Backup);
public sealed record Backup(NonEmptyString BackupPath) : BackupOption(true);
public sealed record NoBackup() : BackupOption(false);