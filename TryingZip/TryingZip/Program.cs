﻿using SimpleInjector;
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
        var source = ExistingDirectory.Create(Path.Combine(desktop, "Source"));
        var destination = ExistingDirectory.Create(Path.Combine(desktop, "FolderDesktop"));

        var zipFiles = GetAllWithExtension(source, SupportedZipExtensions.SevenZ);
        bigUnZiper.UnzipAll(zipFiles, destination);
    }

    public static List<ExistingPath> GetAllWithExtension(ExistingDirectory existingDirectory, FileExtension extension) =>
        Directory.EnumerateFiles(existingDirectory, extension.WildcardExtension, SearchOption.AllDirectories)
        .Select(f => new ExistingPath(f))
        .ToList();

    public static Container RegisterAll() =>
        new SimpleInjectorContainerBuilder()
        .Register<IUnZiper, SevenZUnZiper>()
        .Register<IBigUnZiper, BigUnZiper>()
        .Build();
}