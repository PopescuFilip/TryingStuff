using SimpleInjector;
using TryingZip.InjectionHelpers;
using TryingZip.Serivces;

namespace TryingZip;

public class Program
{
    public static void Main(string[] args)
    {
        var container = RegisterAll();
        var directoryCreator = container.GetInstance<IDirectoryCreator>();
        var unZiper = container.GetInstance<IFileUnZiper>();
        var bigUnZiper = container.GetInstance<IBigUnZiper>();

        var desktop = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop");
        var source = new ExistingDirectory(Path.Combine(desktop, "Source"));
        var destination = directoryCreator.Create(Path.Combine(desktop, "FolderDesktop"));

        //var zipFiles = GetAllWithExtension(source, new Extension("7z"));
        //var resultingDirectories = bigUnZiper.UnzipAll(zipFiles, destination);
    }

    public static List<ExistingFile> GetAllWithExtension(ExistingDirectory existingDirectory, FileExtension extension) =>
        Directory.EnumerateFiles(existingDirectory, extension.ToWildcard(), SearchOption.AllDirectories)
        .Select(f => new ExistingFile(f))
        .ToList();


    public static void ReadFromFile(string filePath)
    {

    }

    public static Container RegisterAll() =>
        new SimpleInjectorContainerBuilder()
        .Register<IDirectoryCreator, DirectoryCreator>()
        .Register<IFileUnZiper, SevenZUnZiper>()
        .Register<IBigUnZiper, BigUnZiper>()
        .VerifyAndGetContainer();
}