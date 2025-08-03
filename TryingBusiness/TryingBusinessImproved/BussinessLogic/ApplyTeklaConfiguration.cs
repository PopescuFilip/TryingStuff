namespace TryingBusinessImproved.BussinessLogic;

public static class ApplyTeklaConfiguration
{
    public static void Apply(this UsableTeklaConfiguration teklaConfiguration)
    {
        foreach(var action in teklaConfiguration.UsableDeleteActions)
            action.Apply();

        foreach(var action in teklaConfiguration.UsableCopyActions)
            action.Apply();

        foreach (var action in teklaConfiguration.UsableThirdPartyActions)
            action.Apply();
    }
}