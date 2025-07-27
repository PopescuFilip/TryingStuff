namespace TryingBusiness;

public interface IDeleteService
{
    void DeleteFile(string filePath, string backupPath = "");
    void DeleteFilesWithExtensions(string parentDirectory, List<string> extensions, string backupPath = "");
}

public class DeleteService : IDeleteService
{
    public void DeleteFile(string filePath, string backupPath = "")
    {
        throw new NotImplementedException();
    }

    public void DeleteFilesWithExtensions(string parentDirectory, List<string> extensions, string backupPath = "")
    {
        throw new NotImplementedException();
    }
}