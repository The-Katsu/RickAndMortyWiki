using RickAndMortyWiki.Domain.GraphQl.Base;

namespace RickAndMortyWiki.Domain.GraphQl;

public class GraphQlMultipleResponse<T> where T : class
{
    public Response<T> Response { get; set; } = null!;
}