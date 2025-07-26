using SimpleInjector;
using TryingZip.InjectionHelpers;
using TryingZip.Serivces;

namespace TryingZip;

public class Program
{
    public static void Main(string[] args)
    {
        var container = RegisterAll();
        var bigUnZiper = container.GetInstance<IBigUnZiper>();

        var desktop = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop");
        var source = ExistingDirectory.Create(Path.Combine(desktop, "Source"));
        var destination = ExistingDirectory.Create(Path.Combine(desktop, "FolderDesktop"));

        var zipFiles = GetAllWithExtension(source, new FileExtension(SupportedZipExtensions.SevenZ));
        bigUnZiper.UnzipAll(zipFiles, destination);
    }

    public static List<ExistingPath> GetAllWithExtension(ExistingDirectory existingDirectory, FileExtension extension) =>
        Directory.EnumerateFiles(existingDirectory, extension.ToWildcard(), SearchOption.AllDirectories)
        .Select(f => new ExistingPath(f))
        .ToList();

    public static Container RegisterAll() =>
        new SimpleInjectorContainerBuilder()
        .Register<IUnZiper, SevenZUnZiper>()
        .Register<IBigUnZiper, BigUnZiper>()
        .Build();
}