using GraphQL.Client.Http;
using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Clients.Queries;
using RickAndMortyWiki.Domain.GraphQl;
using RickAndMortyWiki.Domain.GraphQl.Helpers;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Clients;

public sealed class CharacterClient : IClient<Character>
{
    private readonly GraphQLHttpClient _graphQlClient;

    public CharacterClient(GraphQLHttpClient graphQlClient) => _graphQlClient = graphQlClient;

    public async Task<GraphQlSingleResponse<Character>> GetById(int id)
    {
        var response = 
            await _graphQlClient
                .SendQueryAsync<GraphQlSingleResponse<Character>>(CharacterQueries.GetById(id));
        return response.Data;
    }

    public async Task<GraphQlMultipleResponse<Character>> GetPage(int page, Filter filter = null!)
    {
        var response = 
            await _graphQlClient
                .SendQueryAsync<GraphQlMultipleResponse<Character>>(CharacterQueries.GetPage(page, filter));
        return response.Data;
    }
}