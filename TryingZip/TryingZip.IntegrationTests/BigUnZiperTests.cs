using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TryingZip.Serivces;
using static TryingZip.SupportedZipExtensions;

namespace TryingZip.IntegrationTests;

[TestClass]
public class BigUnZiperTests
{
    private const string FileName = "file";
    private readonly string _source = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop", "Source");

    private BigUnZiper _bigUnZiper;
    private IUnZiper _fileUnZiper;

    [TestInitialize]
    public void Init()
    {
        _fileUnZiper = Substitute.For<IUnZiper>();
        _bigUnZiper = new BigUnZiper(_fileUnZiper);
    }

    [TestMethod]
    public void UnZipAll_ShouldCallAppropriateFunction_WhenCalled()
    {
        var sourceDirectory = ExistingDirectory.Create(_source);
        var count = 100;
        var allFiles = CreateAllFiles(SevenZ, count);

        _bigUnZiper.UnzipAll(allFiles, sourceDirectory);

        _fileUnZiper.ReceivedWithAnyArgs(count).UnZip(default, default);
        allFiles.ForEach(file => _fileUnZiper.Received().UnZip(file, sourceDirectory));
    }

    private List<ExistingPath> CreateAllFiles(FileExtension extension, int fileCount)
    {
        var basePath = Path.Combine(_source, FileName);
        var list = new List<ExistingPath>(fileCount);

        for (int i = 0; i < fileCount; i++)
        {
            var currentPath = basePath + i + extension;
            File.Create(currentPath).Close();
            list.Add(new(currentPath));
        }
        return list;
    }
}