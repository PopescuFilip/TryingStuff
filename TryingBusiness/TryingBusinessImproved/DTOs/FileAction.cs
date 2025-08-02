namespace TryingBusinessImproved.DTOs;

public abstract record FileAction(string FilePath, bool IsEnabled);
public sealed record DeleteAction(string SourcePath, bool IsEnabled, string BackupPath) : FileAction(SourcePath, IsEnabled);
public sealed record CopyAction(string SourcePath, bool IsEnabled, string DestinationPath, bool Mirror) : FileAction(SourcePath, IsEnabled);
public sealed record ThirdPartyAction(string FilePath, bool IsEnabled) : FileAction(FilePath, IsEnabled);

public static class FileActionExtensions
{
    public static T Map<T>(
        this FileAction value,
        Func<DeleteAction, T> mapDelete,
        Func<CopyAction, T> mapCopy,
        Func<ThirdPartyAction, T> mapThirdParty) => value switch
        {
            DeleteAction deleteAction => mapDelete(deleteAction),
            CopyAction copyAction => mapCopy(copyAction),
            ThirdPartyAction thirdPartyAction => mapThirdParty(thirdPartyAction),
            _ => throw new ArgumentException($"{value} is not a supported type", nameof(value))
        };

    public static void Match(
        this FileAction value,
        Action<DeleteAction> onDelete,
        Action<CopyAction> onCopy,
        Action<ThirdPartyAction> onThirdPartyAction)
    {
        switch (value)
        {
            case DeleteAction deleteAction:
                onDelete(deleteAction);
                break;

            case CopyAction copyAction:
                onCopy(copyAction);
                break;

            case ThirdPartyAction thirdPartyAction:
                onThirdPartyAction(thirdPartyAction);
                break;

            default:
                throw new ArgumentException($"{value} is not a supported type", nameof(value));
        }
    }
};