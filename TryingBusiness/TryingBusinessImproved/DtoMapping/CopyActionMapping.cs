using TryingBusinessImproved.DTOs;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved.DtoMapping;

public static class CopyActionMapping
{
    public static UsableCopyAction ToUsableCopyAction(this CopyAction copyAction) =>
        new(copyAction.GetSourceExistingPath(), (DirectoryPath)copyAction.DestinationPath);

    public static ExistingPath GetSourceExistingPath(this CopyAction copyAction) =>
        ExistingFile.TryCreate(copyAction.SourcePath, out var existingFile)
        ? existingFile
        : ExistingDirectory.TryCreate(copyAction.SourcePath, out var existingDirectory)
        ? existingDirectory
        : ExtensionPath.TryCreate(copyAction.SourcePath, out var extensionPath)
        ? extensionPath
        : ExistingPath.NoPath;
}