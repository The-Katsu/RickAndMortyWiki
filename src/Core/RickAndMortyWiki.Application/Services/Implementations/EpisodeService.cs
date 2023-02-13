using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Helpers.Collecting;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Services.Implementations;

public class EpisodeService : IEpisodeService
{
    private readonly IClient<Episode> _episodeClient;

    public EpisodeService(IClient<Episode> episodeClient) => _episodeClient = episodeClient;

    public async Task<Episode> GetById(int id)
    {
        var response = await _episodeClient.GetById(id);
        return response.Response;
    }

    public async Task<List<Episode>> GetAll() => 
        await Collector<Episode>.CollectAll(_episodeClient);
}