using Microsoft.AspNetCore.Components;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Components;

public partial class CardsWrapper
{
    [Parameter] public List<Character> Characters { get; set; } = new();
    [Parameter] public EventCallback<int> OnClick { get; set; }
}