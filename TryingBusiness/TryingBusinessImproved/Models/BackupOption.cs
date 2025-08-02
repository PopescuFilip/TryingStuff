using UsefullStuff.IOModels;

namespace TryingBusinessImproved;

public record BackupOption(bool Backup);
public sealed record Backup(DirectoryPath BackupPath) : BackupOption(true);
public sealed record NoBackup() : BackupOption(false);

public static class BackupOptionExtensions
{
    public static void Match(
        this BackupOption value,
        Action<Backup> onBackup,
        Action<NoBackup> onNoBackup)
    {
        switch (value)
        {
            case Backup backup:
                onBackup(backup);
                break;
            case NoBackup noBackup:
                onNoBackup(noBackup);
                break;
            default:
                throw new ArgumentException($"{value} is not a supported type", nameof(value));
        }
    }
}