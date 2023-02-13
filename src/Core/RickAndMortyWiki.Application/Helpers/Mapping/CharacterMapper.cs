using RickAndMortyWiki.Domain.GraphQl;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application.Helpers.Mapping;

public static class CharacterMapper
{
    public static Page<Character> ResponseToPage(GraphQlMultipleResponse<Character> response) =>
        new()
        {
            Total = response.Response.Info.Pages ?? 0,
            Prev = response.Response.Info.Prev,
            Next = response.Response.Info.Next,
            Units = response.Response.Results
        };
}