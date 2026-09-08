using BrickVault.Core.Models;

namespace BrickVault.Api.Services.Rebrickable;

public static class RebrickableMapper
{
    public static LegoSet MapSet(RebrickableSet set, RebrickableTheme? theme = null)
    {
        return new LegoSet
        {
            SetNumber = set.SetNumber,
            Name = set.Name,
            Year = set.Year,
            ThemeId = set.ThemeId,
            Theme = theme is null
                ? null
                : new LegoTheme
                {
                    Id = theme.Id,
                    ParentId = theme.ParentId,
                    Name = theme.Name
                },
            PartCount = set.NumParts,
            ImageUrl = set.ImageUrl
        };
    }
}