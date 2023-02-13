using RickAndMortyWiki.Domain.GraphQl.Helpers;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Services.Interfaces;

public interface ICharacterService
{
    public Task<Character> GetById(int id);
    public Task<Page<Character>> GetPage(int page, Filter filter);
}