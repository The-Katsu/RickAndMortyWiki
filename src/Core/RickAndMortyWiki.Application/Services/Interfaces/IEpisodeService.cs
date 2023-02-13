using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Services.Interfaces;

public interface IEpisodeService
{
    public Task<Episode> GetById(int id);
    public Task<List<Episode>> GetAll();
}