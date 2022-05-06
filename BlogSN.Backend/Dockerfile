FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlogSN.Backend/BlogSN.Backend.csproj", "BlogSN.Backend/"]
COPY ["Identity/Identity.csproj", "Identity/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "BlogSN.Backend/BlogSN.Backend.csproj"
COPY . .
WORKDIR "/src/BlogSN.Backend"
RUN dotnet build "BlogSN.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogSN.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogSN.Backend.dll"]
