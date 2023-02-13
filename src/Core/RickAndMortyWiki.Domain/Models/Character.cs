namespace RickAndMortyWiki.Domain.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public Location Origin { get; set; } = null!;
    public Location Location { get; set; } = null!;
    public string Image { get; set; } = string.Empty;
    public List<Episode> Episode { get; set; } = new();
}