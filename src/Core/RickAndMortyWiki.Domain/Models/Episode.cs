namespace RickAndMortyWiki.Domain.Models;

public class Episode
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public string Series { get; set; } = string.Empty;
    public List<Character> Characters { get; set; } = new();
}