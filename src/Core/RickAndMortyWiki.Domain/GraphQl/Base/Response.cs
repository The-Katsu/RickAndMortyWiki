namespace RickAndMortyWiki.Domain.GraphQl.Base;

public class Response<T> where T : class
{
    public Information Info { get; set; } = null!;
    public List<T> Results { get; set; } = new();
}