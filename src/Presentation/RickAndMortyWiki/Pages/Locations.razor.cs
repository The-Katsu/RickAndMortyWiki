using Microsoft.AspNetCore.Components;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Pages;

public partial class Locations
{
    [Inject] private ILocationService LocationService { get; set; } = null!;
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    
    private List<Location> _locations = null!;
    private Location _location = null!;
    private int _selectedLocationId = 1;
    
    protected override async Task OnInitializedAsync()
    {
        _locations = await LocationService.GetAll();
        _location = await LocationService.GetById(_selectedLocationId);
    }
    
    private async Task SelectionChanged(int id)
    {
        if (_selectedLocationId != id)
        {
            _selectedLocationId = id;
            _location = null!;
            _location = await LocationService.GetById(_selectedLocationId);
        }
    }
    
    private void OnCardClick(int id) => Navigation.NavigateTo("character/" + id);
}