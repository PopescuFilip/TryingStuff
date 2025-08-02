using TryingBusinessImproved.DTOs;

namespace TryingBusinessImproved.Mappers;

public static class DeleteActionMapping
{
    public static UsableDeleteAction ToUsableDeleteAction(this DeleteAction deleteAction) =>
        new(deleteAction.GetDeleteSource(), deleteAction.GetBackupOption());

    public static BackupOption GetBackupOption(this DeleteAction deleteAction) =>
        string.IsNullOrWhiteSpace(deleteAction.BackupPath)
        ? new Backup(new(deleteAction.BackupPath))
        : new NoBackup();

    public static DeleteSource GetDeleteSource(this DeleteAction deleteAction) =>
        File.TryCreate(deleteAction.SourcePath, out var file)
        ? file
        : Extensions.TryCreate(deleteAction.SourcePath, out var extensions)
        ? extensions
        : new NonExistent();
}