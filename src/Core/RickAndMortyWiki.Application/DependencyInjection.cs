using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.DependencyInjection;
using RickAndMortyWiki.Application.Clients;
using RickAndMortyWiki.Application.Clients.Interfaces;
using RickAndMortyWiki.Application.Services.Implementations;
using RickAndMortyWiki.Application.Services.Interfaces;
using RickAndMortyWiki.Domain.GraphQl.Base;
using RickAndMortyWiki.Domain.Models;

namespace RickAndMortyWiki.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        // graphQlClient
        services.AddTransient(_ => 
            new GraphQLHttpClient(Urls.RickAndMortyGraphQl, new NewtonsoftJsonSerializer()));
        
        // clients
        services.AddTransient<IClient<Character>, CharacterClient>();
        services.AddTransient<IClient<Episode>, EpisodeClient>();
        services.AddTransient<IClient<Location>, LocationClient>();
        
        // services
        services.AddTransient<ICharacterService, CharacterService>();
        services.AddTransient<IEpisodeService, EpisodeService>();
        services.AddTransient<ILocationService, LocationService>();
    }
}
