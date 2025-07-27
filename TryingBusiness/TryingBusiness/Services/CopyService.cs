namespace TryingBusiness;

public interface ICopyService
{
    void CopyFile(string source, string destination);
    void CopyFolder(string source, string destination, bool mirror);
    void CopyFilesWithExtension(string sourceDirectory, string destination, List<string> extensions);
}

public class CopyService : ICopyService
{
    public void CopyFile(string source, string destination)
    {
        throw new NotImplementedException();
    }

    public void CopyFilesWithExtension(string sourceDirectory, string destination, List<string> extensions)
    {
        throw new NotImplementedException();
    }

    public void CopyFolder(string source, string destination, bool mirror)
    {
        throw new NotImplementedException();
    }
}