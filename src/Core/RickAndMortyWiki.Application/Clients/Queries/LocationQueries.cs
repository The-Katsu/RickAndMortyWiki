using GraphQL;

namespace RickAndMortyWiki.Application.Clients.Queries;

public static class LocationQueries
{
    public static GraphQLRequest GetById(int id) =>
        new()
        {
            Query = $@"{{
                response: location(id: {id}) {{
                    id
                    name
                    type
                    dimension
                    residents {{
                        id
                        name
                        image
                    }}
                }}
            }}"
        };

    public static GraphQLRequest GetPage(int page) =>
        new()
        {
            Query = $@"{{
                response: locations(page: {page}) {{
                    info {{
                        pages
                        next
                        prev
                    }}
                    results {{
                        id
                        name
                    }}
                }}
            }}"
        };
}