using BrickVault.Core.Models;

namespace BrickVault.Api.Services.Rebrickable;

public static class RebrickableMapper
{
    public static LegoSet MapSet(RebrickableSet set, RebrickableTheme theme)
    {
        return new LegoSet
        {
            SetNumber = set.SetNumber,
            Name = set.Name,
            Year = set.Year,
            Theme = theme.Name,
            PartCount = set.NumParts,
            ImageUrl = set.ImageUrl
        };
    }
}