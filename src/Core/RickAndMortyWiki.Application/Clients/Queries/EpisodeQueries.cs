using GraphQL;

namespace RickAndMortyWiki.Application.Clients.Queries;

public static class EpisodeQueries
{
    public static GraphQLRequest GetById(int id) =>
        new()
        {
            Query = @$"{{
                response: episode(id: {id}){{
                id
                name
                releaseDate: air_date
                series: episode
                created
                    characters{{
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
                response: episodes(page: {page}) {{
                    info {{
                      count
                      pages
                      next
                      prev
                    }}
                    results {{
                      id
                      series: episode
                    }}
                }}
            }}"
        };
}