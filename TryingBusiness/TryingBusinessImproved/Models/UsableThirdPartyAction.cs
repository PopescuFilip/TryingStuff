using UsefullStuff.Common;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved;

public record UsableThirdPartyAction(ExistingFile Executable)
{
    public readonly FileExtension[] SupportedFileExtensions =
    [
        new((NonEmptyString)"exe")
    ];
}