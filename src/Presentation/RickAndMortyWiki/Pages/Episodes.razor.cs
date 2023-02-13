using Microsoft.AspNetCore.Components;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Pages;

public partial class Episodes
{
    [Inject] private IEpisodeService EpisodeService { get; set; } = null!;
    [Inject] private NavigationManager Navigation { get; set; } = null!;

    private List<Episode> _episodes = null!;
    private Episode _episode = null!;
    private int _selectedEpisodeId = 1;

    protected override async Task OnInitializedAsync()
    {
        _episodes = await EpisodeService.GetAll();
        _episode = await EpisodeService.GetById(_selectedEpisodeId);
    }

    private async Task SelectionChanged(int id)
    {
        if (_selectedEpisodeId != id)
        {
            _selectedEpisodeId = id;
            _episode = null!;
            _episode = await EpisodeService.GetById(_selectedEpisodeId);
        }
    }
    
    private void OnCardClick(int id) => Navigation.NavigateTo("character/" + id);
}