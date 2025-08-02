using TryingBusinessImproved.DTOs;

namespace TryingBusinessImproved.BussinessLogic;

public delegate bool FileActionFilter(FileAction fileAction);

public static class DefaultFileActionFilters
{
    public static IEnumerable<F> Where<F>(this IEnumerable<F> fileActions, FileActionFilter filter)
        where F : FileAction
        =>
        fileActions.Where(f => filter(f));

    public static readonly FileActionFilter IsEnabled = fileAction => fileAction.IsEnabled;
}