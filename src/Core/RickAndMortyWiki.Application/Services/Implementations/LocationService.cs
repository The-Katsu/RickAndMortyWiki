using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Helpers.Collecting;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Services.Implementations;

public class LocationService : ILocationService
{
    private readonly IClient<Location> _locationClient;

    public LocationService(IClient<Location> locationClient) => _locationClient = locationClient;

    public async Task<Location> GetById(int id)
    {
        var response = await _locationClient.GetById(id);
        return response.Response;
    }

    public async Task<List<Location>> GetAll()=> 
        await Collector<Location>.CollectAll(_locationClient);
}