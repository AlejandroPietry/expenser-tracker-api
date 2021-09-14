#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ExpenserTracker.Presentation/ExpenserTracker.Presentation.csproj", "ExpenserTracker.Presentation/"]
RUN dotnet restore "ExpenserTracker.Presentation/ExpenserTracker.Presentation.csproj"
COPY . .
WORKDIR "/src/ExpenserTracker.Presentation"
RUN dotnet build "ExpenserTracker.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpenserTracker.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpenserTracker.Presentation.dll"]