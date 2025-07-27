namespace TryingBusiness;

public interface IExecuter
{
    void Execute(string filePath);
}

public class Executer : IExecuter
{
    public void Execute(string filePath)
    {
        throw new NotImplementedException();
    }
}