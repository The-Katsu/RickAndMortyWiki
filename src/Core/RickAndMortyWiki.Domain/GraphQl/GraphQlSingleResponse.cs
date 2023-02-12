namespace RickAndMortyWiki.Domain.GraphQl;

public class GraphQlSingleResponse<T> where T : class
{
    public T Response { get; set; } = null!;
}