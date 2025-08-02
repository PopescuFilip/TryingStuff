namespace TryingBusinessImproved.BussinessLogic;

public static class ApplyDeleteAction
{
    public static void Backup(this UsableDeleteAction action) =>
        action.BackupOption.Match(
            (backup) => Console.WriteLine(),
            (noBackup) => {});
}