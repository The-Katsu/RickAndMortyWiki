using RickAndMortyWiki.Domain.GraphQl.Base;

namespace RickAndMortyWiki.Domain.Models;

public class Page<T> where T : class
{
    public int Total { get; set; }
    public int? Prev { get; set; }
    public int? Next { get; set; }
    public List<T> Units { get; set; } = null!;
}