
<h1 align="center">Rick And Morty Wiki Blazor App</h1>
<p align="center">You can try it on GitHub Pages here <a href="https://the-katsu.github.io/RickAndMortyWiki/">Rick And Morty Wiki</a></p>  
<p align="center">Stack: .NET 7, Blazor WASM App, GraphQL.Client</p>

---  

- Navigation
    - [Pages](#pages)
    - [Containerizing of Blazor WebAssembly App](#containerizing-of-blazor-webassembly-app)
    - [Example of using GraphQL Client](#example-of-using-graphql-client)
    - [Example of GraphQl request/response](#example-of-graphql-request-response)

---

## Pages

<h4 align="center">~ Home ~</h4>

![](https://sun9-42.userapi.com/impg/AmA5XNF4OAQjx7qIO3z6nwMiRldQ_GhKvAnkMQ/PGZrkG8bRRo.jpg?size=1920x927&quality=96&sign=fcf6c1bc275645af543ca53d3fccd582&type=album)  

<h4 align="center">~ Characters ~</h4>

![](https://sun9-62.userapi.com/impg/ilC2BJl7VapUitnu2crBQjseosOX_0Ghl5iAQA/a2snLqrQ-Ws.jpg?size=1900x927&quality=96&sign=9002edf29f2ae5a4d4a940e9539c92f6&type=album)

<h4 align="center">~ Characters search ~</h4>

![](https://sun9-32.userapi.com/impg/KlfmImuiXP6n8rwauL98qEsDfMpiJTx3K8YijA/5eqfzs1brts.jpg?size=1904x931&quality=96&sign=3daa8e0b99c34837913af93e89b46b01&type=album)

<h4 align="center">~ Character ~</h4>

![](https://sun7-9.userapi.com/impg/gsjVEA-AS9qFrwwk3VAz1xPLLOarSobUiINhEg/xHQ1c8D3Z1g.jpg?size=1920x927&quality=96&sign=7557dc17dcbf607e3759d9dbb01d1e50&type=album)

<h4 align="center">~ Pagination ~</h4>

![](https://sun9-72.userapi.com/impg/UiqyjgJaTfpmUsiN697A7yz0KH_hHkOlbTgH8w/GVxGufarFiI.jpg?size=1898x930&quality=96&sign=a7f896b51d280ce4c0fd26126a21fb07&type=album)

<h4 align="center">~ Episodes ~</h4>

![](https://sun9-48.userapi.com/impg/KjztRiL9UKrJAoYDn8GyR1CvXRSmw_ZVTJjnCQ/x75XTa8oeTA.jpg?size=1902x923&quality=96&sign=e660657edd1a3a8a42f68f152bb28c34&type=album)

<h4 align="center">~ Locations ~</h4>

![](https://sun9-23.userapi.com/impg/AzI7YWgJHK8LPeVkZ9S1sOeWThZqBSsIsCV8uQ/ZbuTCJ2e8Ow.jpg?size=1901x919&quality=96&sign=ac810c4f0f928593d9cb6a135d940b3f&type=album)  

<h4 align="center">~ Adaptive :) ~</h4>  

![](https://sun9-72.userapi.com/impg/MeOljW2eK0X6yKURaD9UKcxgvL4k2C6_4ZFU-A/EUU4Xz2IjMg.jpg?size=2206x823&quality=96&sign=b5349a4c3fcbab5b2683d96f15bf7381&type=album)


## Containerizing of Blazor WebAssembly App

*Delete github actions script from index.html & 404.html if you have

1. Create nginx.conf
```javascript
events { }
http {
    include mime.types;

    server {
        listen 80;

        location / {
            root /usr/share/nginx/html;
            try_files $uri $uri/ /index.html =404;
        }
    }
}
```

2. Create Dockerfile

*Invoke from parent directory if you have additional libraries (like Application, Domain, etc)  

```sql
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Presentation/RickAndMortyWiki/RickAndMortyWiki.csproj", "src/Presentation/RickAndMortyWiki/"]
COPY ["src/Core/RickAndMortyWiki.Application/RickAndMortyWiki.Application.csproj", "src/Core/RickAndMortyWiki.Application/"]
COPY ["src/Core/RickAndMortyWiki.Domain/RickAndMortyWiki.Domain.csproj", "src/Core/RickAndMortyWiki.Domain/"]
RUN dotnet restore "src/Presentation/RickAndMortyWiki/RickAndMortyWiki.csproj"
COPY . .
WORKDIR "/src/src/Presentation/RickAndMortyWiki"
RUN dotnet build "RickAndMortyWiki.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RickAndMortyWiki.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
```

3. Create docker-compose.yaml
```yaml
version: '3.4'

services:
  blazorapp:
    image: blazorandmorty
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - 8080:80
```

4. Ron "docker-compose up" command


5. Done  
![](https://sun9-51.userapi.com/impg/8DHMUuhPctlKviuOt1DFy_tOPIyyxsoUUZ-gaQ/__70RVAiXPE.jpg?size=1637x102&quality=96&sign=021163aa4f0b2c5c1707a22dbbe22b50&type=album)

## Example of using GraphQL Client

<p>The strength of GraphQl is that we ourselves determine the values we need</p>

```cs
// Base model for GraphQl response (data : { response: { info: { } results: { } } })
public class Response<T> where T : class
{
    public Information Info { get; set; } = null!;
    public List<T> Results { get; set; } = new();
}

// Base model for response handling
public class GraphQlArrayResponse<T> where T : class
{
    public Response<T> Response { get; set; }
}

// Make the query
public static GraphQLRequest GetPage(int pageNum) =>
    new()
    {
        Query = @$"{{
            response: characters(page: {pageNum}) {{
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

// Handle the data
public async Task<Response<Character>> GetPage(int pageNum)
{
    var graphQlClient = new GraphQLHttpClient(Urls.RickAndMortyGraphQl, new NewtonsoftJsonSerializer());
    var response = 
        await graphQlClient.SendQueryAsync<GraphQlArrayResponse<Character>>(CharacterQueries.GetPage(pageNum));
    return response.Data.Response;
}

```

## Example of GraphQl request response

<h4>Request</h4>

```javascript
{
  response: characters(page: 1) {
    info {
      count
      pages
      next
      prev
    }
    results {
      id
      name
      image
    }
  }
}
```

<h4>Response</h4>

```json
{
  "data": {
    "response": {
      "info": {
        "count": 826,
        "pages": 42,
        "next": 2,
        "prev": null
      },
      "results": [
        {
          "id": "1",
          "name": "Rick Sanchez",
          "image": "https://rickandmortyapi.com/api/character/avatar/1.jpeg"
        },
        {
          "id": "2",
          "name": "Morty Smith",
          "image": "https://rickandmortyapi.com/api/character/avatar/2.jpeg"
        },
        {
          "id": "3",
          "name": "Summer Smith",
          "image": "https://rickandmortyapi.com/api/character/avatar/3.jpeg"
        },
        {
          "id": "4",
          "name": "Beth Smith",
          "image": "https://rickandmortyapi.com/api/character/avatar/4.jpeg"
        },
        {
          "id": "5",
          "name": "Jerry Smith",
          "image": "https://rickandmortyapi.com/api/character/avatar/5.jpeg"
        },
        {
          "id": "6",
          "name": "Abadango Cluster Princess",
          "image": "https://rickandmortyapi.com/api/character/avatar/6.jpeg"
        },
        {
          "id": "7",
          "name": "Abradolf Lincler",
          "image": "https://rickandmortyapi.com/api/character/avatar/7.jpeg"
        },
        {
          "id": "8",
          "name": "Adjudicator Rick",
          "image": "https://rickandmortyapi.com/api/character/avatar/8.jpeg"
        },
        {
          "id": "9",
          "name": "Agency Director",
          "image": "https://rickandmortyapi.com/api/character/avatar/9.jpeg"
        },
        {
          "id": "10",
          "name": "Alan Rails",
          "image": "https://rickandmortyapi.com/api/character/avatar/10.jpeg"
        },
        {
          "id": "11",
          "name": "Albert Einstein",
          "image": "https://rickandmortyapi.com/api/character/avatar/11.jpeg"
        },
        {
          "id": "12",
          "name": "Alexander",
          "image": "https://rickandmortyapi.com/api/character/avatar/12.jpeg"
        },
        {
          "id": "13",
          "name": "Alien Googah",
          "image": "https://rickandmortyapi.com/api/character/avatar/13.jpeg"
        },
        {
          "id": "14",
          "name": "Alien Morty",
          "image": "https://rickandmortyapi.com/api/character/avatar/14.jpeg"
        },
        {
          "id": "15",
          "name": "Alien Rick",
          "image": "https://rickandmortyapi.com/api/character/avatar/15.jpeg"
        },
        {
          "id": "16",
          "name": "Amish Cyborg",
          "image": "https://rickandmortyapi.com/api/character/avatar/16.jpeg"
        },
        {
          "id": "17",
          "name": "Annie",
          "image": "https://rickandmortyapi.com/api/character/avatar/17.jpeg"
        },
        {
          "id": "18",
          "name": "Antenna Morty",
          "image": "https://rickandmortyapi.com/api/character/avatar/18.jpeg"
        },
        {
          "id": "19",
          "name": "Antenna Rick",
          "image": "https://rickandmortyapi.com/api/character/avatar/19.jpeg"
        },
        {
          "id": "20",
          "name": "Ants in my Eyes Johnson",
          "image": "https://rickandmortyapi.com/api/character/avatar/20.jpeg"
        }
      ]
    }
  }
}
```