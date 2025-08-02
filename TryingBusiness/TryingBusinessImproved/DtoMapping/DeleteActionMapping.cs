using TryingBusinessImproved.DTOs;
using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved.DtoMapping;

public static class DeleteActionMapping
{
    public static UsableDeleteAction ToUsableDeleteAction(this DeleteAction deleteAction) =>
        new(deleteAction.GetDeleteSource(), deleteAction.GetBackupOption());

    private static BackupOption GetBackupOption(this DeleteAction deleteAction) =>
        NonEmptyString.TryCreate(deleteAction.BackupPath, out var nonEmptyString)
        ? new Backup(new(nonEmptyString))
        : new NoBackup();

    private static ExistingPath GetDeleteSource(this DeleteAction deleteAction) =>
        ExistingFile.TryCreate(deleteAction.SourcePath, out var file)
        ? file
        : ExtensionPath.TryCreate(deleteAction.SourcePath, out var extensions)
        ? extensions
        : ExistingPath.NoPath;
}