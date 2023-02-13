using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Helpers.Mapping;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.GraphQl.Helpers;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Services.Implementations;

public sealed class CharacterService : ICharacterService
{
    private readonly IClient<Character> _characterClient;

    public CharacterService(IClient<Character> characterClient) => _characterClient = characterClient;

    public async Task<Character> GetById(int id)
    {
        var response = await _characterClient.GetById(id);
        return response.Response;
    }

    public async Task<Page<Character>> GetPage(int page, Filter filter)
    {
        var requestFilter = FilterMapper.MapToRequestFilter(filter);
        var response = await _characterClient.GetPage(page, requestFilter);
        var charactersPage = CharacterMapper.ResponseToPage(response);
        return charactersPage;
    }
}