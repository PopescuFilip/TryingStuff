namespace TryingBusinessImproved;

public record UsableTeklaConfiguration(
    IEnumerable<UsableDeleteAction> UsableDeleteActions,
    IEnumerable<UsableCopyAction> UsableCopyActions,
    IEnumerable<UsableThirdPartyAction> UsableThirdPartyActions
    );