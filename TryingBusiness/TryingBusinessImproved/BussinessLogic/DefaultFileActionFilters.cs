using TryingBusinessImproved.DTOs;

namespace TryingBusinessImproved.BussinessLogic;

public delegate bool FileActionFilter(FileAction fileAction);

public static class DefaultFileActionFilters
{
    public static readonly FileActionFilter IsEnabled = fileAction => fileAction.IsEnabled;
}