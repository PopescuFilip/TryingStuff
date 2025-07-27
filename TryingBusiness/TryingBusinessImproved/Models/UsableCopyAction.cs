using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved;

public record UsableCopyAction(NonEmptyString SourcePath, ExistingDirectory DestinationDirectory);
public record DirectoryCopyAction(ExistingDirectory SourceDirectory, ExistingDirectory DestinationDirectory, bool Mirror) : UsableCopyAction(SourceDirectory, DestinationDirectory);
public record FileCopyAction(ExistingFile SourceFile, ExistingDirectory DestinationDirectory) : UsableCopyAction(SourceFile, DestinationDirectory);
public record ExtensionsCopyAction(ExistingFile SourceFile, ExistingDirectory DestinationDirectory) : UsableCopyAction(SourceFile, DestinationDirectory);