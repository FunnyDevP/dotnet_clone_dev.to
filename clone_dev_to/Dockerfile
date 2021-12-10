FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["clone_dev_to/clone_dev_to.csproj", "clone_dev_to/"]
RUN dotnet restore "clone_dev_to/clone_dev_to.csproj"
COPY . .
WORKDIR "/src/clone_dev_to"
RUN dotnet build "clone_dev_to.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "clone_dev_to.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clone_dev_to.dll"]
