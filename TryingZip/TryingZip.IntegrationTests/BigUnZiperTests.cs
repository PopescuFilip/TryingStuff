using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TryingZip.IntegrationTests.TestHelper;
using TryingZip.Serivces;
using static TryingZip.SupportedZipExtensions;

namespace TryingZip.IntegrationTests;

[TestClass]
public class BigUnZiperTests
{
    private readonly string _source = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop", "Source");

    private BigUnZiper _bigUnZiper;
    private IUnZiper _fileUnZiper;
    private FileCreator _fileCreator;

    [TestInitialize]
    public void Init()
    {
        _fileUnZiper = Substitute.For<IUnZiper>();
        _bigUnZiper = new BigUnZiper(_fileUnZiper);
        _fileCreator = new FileCreator();
        _fileCreator.Init();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _fileCreator.Cleanup();
    }

    [TestMethod]
    public void UnZipAll_ShouldCallAppropriateFunction_WhenCalled()
    {
        var sourceDirectory = ExistingDirectory.Create(_source);
        var count = 100;
        var allFiles = _fileCreator.CreateFiles(SevenZ, count)
            .Select(f => (ExistingPath)f)
            .ToList();

        _bigUnZiper.UnzipAll(allFiles, sourceDirectory);

        _fileUnZiper.ReceivedWithAnyArgs(count).UnZip(Arg.Any<ExistingPath>(), default);
        allFiles.ForEach(file => _fileUnZiper.Received().UnZip(file, sourceDirectory));
    }
}