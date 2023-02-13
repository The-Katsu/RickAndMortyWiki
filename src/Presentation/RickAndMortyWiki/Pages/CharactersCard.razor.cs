using Microsoft.AspNetCore.Components;
using RickAndMortyWiki.Application.Helpers.Filling;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Pages;

public partial class CharactersCard
{
    [Inject] private ICharacterService CharacterService { get; set; } = null!;
    
    [Parameter] public int Id { get; set; }

    private Character _character = null!;
    
    protected override async Task OnInitializedAsync()
    {
        _character = await CharacterService.GetById(Id);
        Filler<Character>.FillEmptyString(_character);
    }
}