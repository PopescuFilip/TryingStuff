using TryingBusinessImproved.DTOs;
using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved.Mappers;

public static class DeleteActionMapping
{
    public static UsableDeleteAction ToUsableDeleteAction(this DeleteAction deleteAction) =>
        new(deleteAction.GetDeleteSource(), deleteAction.GetBackupOption());

    public static BackupOption GetBackupOption(this DeleteAction deleteAction) =>
        NonEmptyString.TryCreate(deleteAction.BackupPath, out var nonEmptyString)
        ? new Backup(new(nonEmptyString))
        : new NoBackup();

    public static ExistingPath GetDeleteSource(this DeleteAction deleteAction) =>
        ExistingFile.TryCreate(deleteAction.SourcePath, out var file)
        ? file
        : ExtensionPath.TryCreate(deleteAction.SourcePath, out var extensions)
        ? extensions
        : ExistingPath.NoPath;
}