using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved;

public record UsableCopyAction(NonEmptyString SourcePath, DirectoryPath DestinationDirectory);
public record DirectoryCopyAction(ExistingDirectory SourceDirectory, DirectoryPath DestinationDirectory, bool Mirror) : UsableCopyAction(SourceDirectory, DestinationDirectory);
public record FileCopyAction(ExistingFile SourceFile, DirectoryPath DestinationDirectory) : UsableCopyAction(SourceFile, DestinationDirectory);
public record ExtensionsCopyAction(ExistingFile SourceFile, DirectoryPath DestinationDirectory) : UsableCopyAction(SourceFile, DestinationDirectory);