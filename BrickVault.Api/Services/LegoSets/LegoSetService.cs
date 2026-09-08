using BrickVault.Api.Services.Rebrickable;
using BrickVault.Core.Models;

namespace BrickVault.Api.Services.LegoSets;

public class LegoSetService(RebrickableClient rebrickableClient)
{
    public async Task<LegoSet> GetSetAsync(string setNumber)
    {
        var set = await rebrickableClient.GetSetAsync(setNumber);
        var theme = await rebrickableClient.GetThemeAsync(set.ThemeId);
        return RebrickableMapper.MapSet(set, theme);
    }

    public async Task<LegoSetSearchResponse> SearchSetsAsync(string query)
    {
        var response = await rebrickableClient.SearchSetsAsync(query);

        return new LegoSetSearchResponse
        {
            Count = response.Count,
            Next = response.Next,
            Previous = response.Previous,
            Results =
            [
                .. response.Results
                    .Select(set => RebrickableMapper.MapSet(set))
            ]
        };
    }
}