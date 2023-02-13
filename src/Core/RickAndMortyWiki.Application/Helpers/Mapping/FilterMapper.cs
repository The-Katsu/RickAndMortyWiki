using RickAndMortyWiki.Domain.GraphQl.Helpers;

namespace RickAndMortyWiki.Application.Helpers.Mapping;

public static class FilterMapper
{
    // graphQl filter requires " " instead of empty string or "name" instead of name 
    public static Filter MapToRequestFilter(Filter filter) =>
        new()
        {
            Name = filter.Name == string.Empty ? "\" \"" : "\"" + filter.Name + "\"",
            Gender = filter.Gender == string.Empty ? "\" \"" : "\"" + filter.Gender + "\"",
            Species = filter.Species == string.Empty ? "\" \"" : "\"" + filter.Species + "\"",
            Status = filter.Status == string.Empty ? "\" \"" : "\"" + filter.Status + "\"",
            Type = filter.Type == string.Empty ? "\" \"" : "\"" + filter.Type + "\""
        };
}