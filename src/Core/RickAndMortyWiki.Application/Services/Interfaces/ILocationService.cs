using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Services.Interfaces;

public interface ILocationService
{
    public Task<Location> GetById(int id);
    public Task<List<Location>> GetAll();
}