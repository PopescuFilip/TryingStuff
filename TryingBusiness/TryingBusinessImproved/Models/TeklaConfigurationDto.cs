namespace TryingBusinessImproved;

public class TeklaConfigurationDto
{
    public bool IsEnabled { get; set; }
    public List<DeleteAction> DeleteActions { get; set; } = [];
    public List<CopyAction> CopyActions { get; set; } = [];
    public List<ThirdPartyAction> ThirdPartyActions { get; set; } = [];
}