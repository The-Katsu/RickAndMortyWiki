using RickAndMortyWiki.Domain.GraphQl;
using RickAndMortyWiki.Domain.GraphQl.Helpers;

namespace RickAndMortyWiki.Application.Clients.Interfaces;

public interface IClient<T> where T : class
{
    public Task<GraphQlSingleResponse<T>> GetById(int id);
    public Task<GraphQlMultipleResponse<T>> GetPage(int page, Filter filter = null!);
}