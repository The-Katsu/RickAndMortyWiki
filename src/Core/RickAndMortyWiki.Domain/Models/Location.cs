namespace RickAndMortyWiki.Domain.Models;

public class Location
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Dimension { get; set; } = string.Empty;
    public List<Character> Residents { get; set; } = new();
}