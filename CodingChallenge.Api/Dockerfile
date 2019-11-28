FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CodingChallenge.Api/CodingChallenge.Api.csproj", "CodingChallenge.Api/"]
RUN dotnet restore "CodingChallenge.Api/CodingChallenge.Api.csproj"
COPY . .
WORKDIR "/src/CodingChallenge.Api"
RUN dotnet build "CodingChallenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodingChallenge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodingChallenge.Api.dll"]