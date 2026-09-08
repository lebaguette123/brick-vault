namespace BrickVault.Api.Services.Rebrickable;

public class RebrickableClient
{
    private readonly HttpClient _httpClient;

    public RebrickableClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        var apiKey = configuration["Rebrickable:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("Rebrickable API key is not configured.");
        }
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"key {apiKey}");
    }

    public async Task<RebrickableSet> GetSetAsync(string setNumber)
    {
        var response = await _httpClient.GetAsync($"lego/sets/{setNumber}/");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Rebrickable API returned {(int)response.StatusCode} " 
                + $"{response.ReasonPhrase}");
        }

        var result = await response.Content.ReadFromJsonAsync<RebrickableSet>();
        return result ?? throw new InvalidOperationException($"Rebrickable returned an empty set response.");
    }
    
    public async Task<RebrickableSetSearchResponse> SearchSetsAsync(
        string query)
    {
        var encodedQuery = Uri.EscapeDataString(query);

        var response = await _httpClient.GetAsync(
            $"lego/sets/?search={encodedQuery}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Rebrickable API returned {(int)response.StatusCode} " +
                $"{response.ReasonPhrase}");
        }

        var result = await response.Content
            .ReadFromJsonAsync<RebrickableSetSearchResponse>();

        return result ?? throw new InvalidOperationException(
            "Rebrickable returned an empty search response.");
    }

    public async Task<RebrickableTheme> GetThemeAsync(int themeId)
    {
        var response = await _httpClient.GetAsync(
            $"lego/themes/{themeId}/");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Rebrickable API returned {(int)response.StatusCode} " +
                $"{response.ReasonPhrase}");
        }

        var result = await response.Content
            .ReadFromJsonAsync<RebrickableTheme>();

        return result ?? throw new InvalidOperationException(
            "Rebrickable returned an empty theme response.");
    }
}