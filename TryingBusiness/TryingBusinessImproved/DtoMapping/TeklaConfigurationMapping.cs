using TryingBusinessImproved.DTOs;
using static TryingBusinessImproved.BussinessLogic.DefaultFileActionFilters;

namespace TryingBusinessImproved.DtoMapping;

public static class TeklaConfigurationMapping
{
    public static UsableTeklaConfiguration ToUsableTeklaConfiguration(this TeklaConfigurationDto dto) =>
        new(
            dto.DeleteActions.Where(d => IsEnabled(d)).Select(d => d.ToUsableDeleteAction()),
            dto.CopyActions.Where(c => IsEnabled(c)).Select(c => c.ToUsableCopyAction()),
            dto.ThirdPartyActions.Where(r => IsEnabled(r)).Select(r => r.ToUsableThirdPartyAction())
            );
}