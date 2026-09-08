namespace BrickVault.Core.Models;

public class LegoTheme
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
}