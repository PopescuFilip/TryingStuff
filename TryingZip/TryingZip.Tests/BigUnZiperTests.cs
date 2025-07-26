using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TryingZip.Serivces;

namespace TryingZip.Tests;

[TestClass]
public class BigUnZiperTests
{
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
        var sourcePath = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop", "Source");
        var sourceDirectory = ExistingDirectory.Create(sourcePath);

        _bigUnZiper.UnzipAll();
    }


}