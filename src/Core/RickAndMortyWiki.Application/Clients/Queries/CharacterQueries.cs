using GraphQL;
using RickAndMortyWiki.Domain.GraphQl.Helpers;

namespace RickAndMortyWiki.Application.Clients.Queries;

public static class CharacterQueries
{
    public static GraphQLRequest GetById(int id) =>
        new()
        {
            Query = @$"{{
                response: character(id: {id}) {{
                    name
                    status
                    species
                    type
                    gender
                    image
                    origin {{
                        name
                    }}
                    location {{
                        name
                    }}
                }}
            }}"
        };

    public static GraphQLRequest GetPage(int page, Filter filter) =>
        new()
        {
            Query = $@"{{
                response: characters(
                    page: {page}
                    filter: {{
                        name: {filter.Name}, 
                        status: {filter.Status}, 
                        species: {filter.Species}, 
                        type: {filter.Type}, 
                        gender: {filter.Gender}}}
                    ) 
                {{
                    info {{
                        count
                        pages
                        next
                        prev
                    }}
                    results {{
                        id
                        name
                        image
                    }}
                }}
            }}"
        };
}