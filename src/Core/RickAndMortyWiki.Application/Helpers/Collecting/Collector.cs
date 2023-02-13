using RickAndMortyWiki.Application.Clients.Interfaces;

namespace RickAndMortyWiki.Application.Helpers.Collecting;

public static class Collector<T> where T : class
{
    public static async Task<List<T>> CollectAll(IClient<T> client)
    {
        var result = new List<T>();
        
        var current = 1;
        var response = await client.GetPage(current);
        result.AddRange(response.Response.Results);
        while (response.Response.Info.Next is not null)
        {
            current++;
            response = await client.GetPage(current);
            result.AddRange(response.Response.Results);
        }

        return result;
    }
}