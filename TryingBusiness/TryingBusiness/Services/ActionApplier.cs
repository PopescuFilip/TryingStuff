namespace TryingBusiness;

public interface IActionApplier
{
    void ApplyDeleteActions(List<DeleteAction> actions);
    void ApplyCopyActions(List<CopyAction> actions);
    void ApplyThirdPartyActions(List<ThirdPartyAction> actions);
}

public class ActionApplier(IDeleteService _deleteService, ICopyService _copyService, IExecuter _executer) : IActionApplier
{
    public void ApplyCopyActions(List<CopyAction> actions)
    {
        foreach (var action in actions)
        {
            if (!action.IsEnabled)
                continue;

            _copyService.CopyFolder(action.SourcePath, action.DestinationPath, action.Mirror);
        }
    }

    public void ApplyDeleteActions(List<DeleteAction> actions)
    {
        foreach (var action in actions)
        {
            if (!action.IsEnabled)
                continue;

            // do stuff
            _deleteService.DeleteFile(string.Empty);
        }
    }

    public void ApplyThirdPartyActions(List<ThirdPartyAction> actions)
    {
        foreach (var action in actions)
        {
            if (!action.IsEnabled)
                continue;

            _executer.Execute(action.FilePath);
        }
    }
}