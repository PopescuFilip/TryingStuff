using UsefullStuff.IOModels;

namespace TryingBusinessImproved.BussinessLogic;

public static class ApplyCopyAction
{
    public static void Apply(this UsableCopyAction action) =>
        action.SourcePath.Match(
            (existingFile) => File.Copy(existingFile, action.DestinationDirectory),
            (existingDirectory) => CopyDirectory(existingDirectory, action.DestinationDirectory),
            (extensionPath) => CopyExtensionPath(extensionPath, action.DestinationDirectory),
            (_) => {}
            );

    private static void CopyDirectory(ExistingDirectory source, DirectoryPath destination)
    {}

    private static void CopyExtensionPath(ExtensionPath source, DirectoryPath destination)
    {}
}