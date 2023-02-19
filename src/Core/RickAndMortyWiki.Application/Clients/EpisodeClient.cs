using GraphQL.Client.Http;
using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Clients.Queries;
using RickAndMortyWiki.Domain.GraphQl;
using RickAndMortyWiki.Domain.GraphQl.Helpers;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Clients;

public sealed class EpisodeClient : IClient<Episode>
{
    private readonly GraphQLHttpClient _graphQlClient;

    public EpisodeClient(GraphQLHttpClient graphQlClient) => _graphQlClient = graphQlClient;

    public async Task<GraphQlSingleResponse<Episode>> GetById(int id)
    {
        var response =
            await _graphQlClient
                .SendQueryAsync<GraphQlSingleResponse<Episode>>(EpisodeQueries.GetById(id));
        return response.Data;
    }

    public async Task<GraphQlMultipleResponse<Episode>> GetPage(int page, Filter filter = null!)
    {
        var response =
            await _graphQlClient
                .SendQueryAsync<GraphQlMultipleResponse<Episode>>(EpisodeQueries.GetPage(page));
        return response.Data;
    }
}