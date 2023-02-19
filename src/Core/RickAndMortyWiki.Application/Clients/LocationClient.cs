using GraphQL.Client.Http;
using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Clients.Queries;
using RickAndMortyWiki.Domain.GraphQl;
using RickAndMortyWiki.Domain.GraphQl.Helpers;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Clients;

public sealed class LocationClient : IClient<Location>
{
    private readonly GraphQLHttpClient _graphQlClient;

    public LocationClient(GraphQLHttpClient graphQlClient) => _graphQlClient = graphQlClient;

    public async Task<GraphQlSingleResponse<Location>> GetById(int id)
    {
        var response =
            await _graphQlClient
                .SendQueryAsync<GraphQlSingleResponse<Location>>(LocationQueries.GetById(id));
        return response.Data;
    }

    public async Task<GraphQlMultipleResponse<Location>> GetPage(int page, Filter filter = null!)
    {
        var response =
            await _graphQlClient
                .SendQueryAsync<GraphQlMultipleResponse<Location>>(LocationQueries.GetPage(page));
        return response.Data;
    }
}