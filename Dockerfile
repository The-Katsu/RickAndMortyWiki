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