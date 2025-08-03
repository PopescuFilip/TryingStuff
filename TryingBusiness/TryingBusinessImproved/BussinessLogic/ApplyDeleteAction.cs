using UsefullStuff.IOModels;

namespace TryingBusinessImproved.BussinessLogic;

public static class ApplyDeleteAction
{
    public static void Apply(this UsableDeleteAction action)
    {
        action.Backup();
        action.Delete();
    }

    private static void Delete(this UsableDeleteAction action) =>
        action.Source.Match(
            (existingFile) => File.Delete(existingFile),
            (existingDirectory) => Directory.Delete(existingDirectory),
            (extensionPath) => DeleteExtensions(extensionPath),
            (_) => {}
            );

    private static void Backup(this UsableDeleteAction action) =>
        action.BackupOption.Match(
            (backup) => new UsableCopyAction(action.Source, backup.BackupPath).Apply(),
            (noBackup) => {}
            );

    private static void DeleteExtensions(ExtensionPath extensionPath)
    {}
}