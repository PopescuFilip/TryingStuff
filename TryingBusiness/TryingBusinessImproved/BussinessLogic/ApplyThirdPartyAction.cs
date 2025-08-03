using UsefullStuff.Extensions;

namespace TryingBusinessImproved.BussinessLogic;

public static class ApplyThirdPartyAction
{
    public static void Apply(this UsableThirdPartyAction action)
    {
        if (UsableThirdPartyAction.SupportedFileExtensions.Contains(action.Executable.GetExtension()))
            Console.WriteLine(action.Executable.GetExtension());
        else
            action.Executable.GetExtension();
    }
}