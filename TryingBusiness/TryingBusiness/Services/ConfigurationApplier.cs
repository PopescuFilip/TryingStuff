namespace TryingBusiness;

public interface IConfigurationApplier
{
    void ApplyConfiguration(TeklaConfiguration configuration);
}

public class ConfigurationApplier(IActionApplier _actionApplier) : IConfigurationApplier
{
    public void ApplyConfiguration(TeklaConfiguration configuration)
    {
        if (configuration.DeleteActions.Count != 0)
            _actionApplier.ApplyDeleteActions(configuration.DeleteActions);

        if (configuration.CopyActions.Count != 0)
            _actionApplier.ApplyCopyActions(configuration.CopyActions);

        if (configuration.ThirdPartyActions.Count != 0)
            _actionApplier.ApplyThirdPartyActions(configuration.ThirdPartyActions);
    }
}