using System.Text.Json.Serialization;

namespace BrickVault.Api.Services.Rebrickable;

public class RebrickableSet
{
    [JsonPropertyName("set_num")]
    public string SetNumber { get; set; } = string.Empty;
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("theme_id")]
    public int ThemeId { get; set; }
    
    [JsonPropertyName("num_parts")]
    public int NumParts{ get; set; }
    
    [JsonPropertyName("set_img_url")]
    public string ImageUrl { get; set; } = string.Empty;
    
    [JsonPropertyName("set_url")]
    public string SetUrl { get; set; } = string.Empty;
    
    [JsonPropertyName("last_modified_dt")]
    public string LastModifiedDate { get; set; } = string.Empty;
}

public class RebrickableSetSearchResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    
    [JsonPropertyName("next")]
    public string? Next { get; set; }
    
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }
    
    [JsonPropertyName("results")]
    public List<RebrickableSet> Results { get; set; } = [];
}

public class RebrickableTheme
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("parent_id")]
    public int? ParentId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}