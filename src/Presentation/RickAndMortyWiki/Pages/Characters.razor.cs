using Microsoft.AspNetCore.Components;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.GraphQl.Helpers;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Pages;

public partial class Characters
{
    [Inject] private ICharacterService CharacterService { get; set; } = null!;

    private Page<Character> _page = null!;
    private List<Character> _characters = null!;
    private Filter _filter = new();
    private bool _showFilters;
    private int _currentPage = 1;
    private int _maxPage = 1;
    private List<int> _displayedPages = new();

    protected override async Task OnInitializedAsync()
    {
        await UpdatePage();
    }

    private async Task UpdatePage()
    {
        _characters = null!;
        StateHasChanged();
        _page = await CharacterService.GetPage(_currentPage, _filter);
        _maxPage = _page.Total;
        _characters = _page.Units;
        GeneratePagination();
        StateHasChanged();
    }

    private async Task Search() => await UpdatePage();
    
    private async Task Reset()
    {
        _filter = new Filter();
        await UpdatePage();
    }

    private async Task NavigateOnPage(string page)
    {
        switch (page)
        {
            case "prev":
                _currentPage--;
                await UpdatePage();
                break;
            case "next":
                _currentPage++;
                await UpdatePage();
                break;
            default:
                var num = int.Parse(page);
                if (_currentPage == num) break;
                _currentPage = num;
                await UpdatePage();
                break;
        }
    }

    private void GeneratePagination()
    {
        if (_maxPage <= 1) return;
        
        if (_maxPage <= 3) _displayedPages = Enumerable.Range(1, _maxPage).ToList();
        else if (_maxPage - _currentPage < 3) _displayedPages = Enumerable.Range(_maxPage - 3, 3).ToList();
        else if (_currentPage < 3) _displayedPages = Enumerable.Range(_currentPage, 3).ToList();
        else _displayedPages = Enumerable.Range(_currentPage - 1, 3).ToList();
        if(!_displayedPages.Contains(1)) _displayedPages.Insert(0, 1);
        if(!_displayedPages.Contains(_maxPage)) _displayedPages.Add(_maxPage);
    }
}