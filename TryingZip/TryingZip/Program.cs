using SimpleInjector;
using TryingZip.Serivces;
using UsefullStuff.Common;
using UsefullStuff.InjectionHelpers;
using UsefullStuff.IOModels;

namespace TryingZip;

public class Program
{
    public static void Main(string[] args)
    {
        var container = RegisterAll();
        var bigUnZiper = container.GetInstance<IBigUnZiper>();

        var desktop = Path.Combine("C:", "Users", $"{Environment.GetEnvironmentVariable("Username")}", "Desktop");
        var source = Path.Combine(desktop, "Source").CreateDirectory();
        var destination = Path.Combine(desktop, "FolderDesktop").CreateDirectory();

        var zipFiles = GetAllWithExtension(source, SupportedZipExtensions.SevenZ);
        bigUnZiper.UnzipAll(zipFiles, destination);
    }

    public static List<ExistingPath> GetAllWithExtension(ExistingDirectory existingDirectory, FileExtension extension) =>
        Directory.EnumerateFiles(existingDirectory, extension.WildcardExtension, SearchOption.AllDirectories)
        .Select(f => (ExistingFile)f)
        .Select(f => (ExistingPath)f)
        .ToList();

    public static Container RegisterAll() =>
        new SimpleInjectorContainerBuilder()
        .Register<IUnZiper, SevenZUnZiper>()
        .Register<IBigUnZiper, BigUnZiper>()
        .Build();
}