namespace BrickVault.Core.Models;

public class LegoSet
{
    public string SetNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public int ThemeId { get; set; }
    public LegoTheme? Theme { get; set; }
    public int PartCount { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}