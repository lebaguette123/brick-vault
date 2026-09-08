namespace BrickVault.Core.Models;

public class LegoSetSearchResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<LegoSet> Results { get; set; } = [];
}