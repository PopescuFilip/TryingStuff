using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace TryingZip.IntegrationTests.TestHelper;

public class FileCreator
{
    private const string FileName = "file";
    private readonly string _source = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop", "Source");

    private readonly List<ExistingFile> _files = [];

    public void Init()
    {
        Directory.CreateDirectory(_source);
    }

    public IEnumerable<ExistingFile> CreateFiles(FileExtension extension, int fileCount)
    {
        var basePath = Path.Combine(_source, FileName);

        for (int i = 0; i < fileCount; i++)
        {
            var currentPath = basePath + i + extension;
            File.Create(currentPath).Close();
            var newFile = (ExistingFile)currentPath;
            _files.Add(newFile);
            yield return newFile;
        }
    }

    public void Cleanup()
    {
        _files.ForEach(f => File.Delete(f));
        _files.Clear();
        Directory.Delete(_source);
    }
}