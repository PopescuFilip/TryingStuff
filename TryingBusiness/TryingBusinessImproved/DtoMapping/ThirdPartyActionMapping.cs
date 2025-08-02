using TryingBusinessImproved.DTOs;
using UsefullStuff.IOModels;

namespace TryingBusinessImproved.DtoMapping;

public static class ThirdPartyActionMapping
{
    public static UsableThirdPartyAction ToUsableThirdPartyAction(this ThirdPartyAction thirdPartyAction) =>
        ExistingFile.TryCreate(thirdPartyAction.FilePath, out var existingFile)
        ? new UsableThirdPartyAction(existingFile)
        : throw new InvalidOperationException($"File with path {thirdPartyAction.FilePath} does not exist");
}