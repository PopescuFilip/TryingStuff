using TryingBusinessImproved.DTOs;
using static TryingBusinessImproved.BussinessLogic.DefaultFileActionFilters;

namespace TryingBusinessImproved.DtoMapping;

public static class TeklaConfigurationMapping
{
    public static UsableTeklaConfiguration ToUsableTeklaConfiguration(this TeklaConfigurationDto dto) =>
        new(
            dto.DeleteActions.Where(IsEnabled).Select(d => d.ToUsableDeleteAction()),
            dto.CopyActions.Where(IsEnabled).Select(c => c.ToUsableCopyAction()),
            dto.ThirdPartyActions.Where(IsEnabled).Select(r => r.ToUsableThirdPartyAction())
            );
}