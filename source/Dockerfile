FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["DasBlog.Web/DasBlog.Web.csproj", "DasBlog.Web/"]
COPY ["DasBlog.Core/DasBlog.Core.csproj", "DasBlog.Core/"]
COPY ["newtelligence.DasBlog.Runtime/newtelligence.DasBlog.Runtime.csproj", "newtelligence.DasBlog.Runtime/"]
COPY ["DasBlog.Services/DasBlog.Services.csproj", "DasBlog.Services/"]
COPY ["DasBlog.Managers/DasBlog.Managers.csproj", "DasBlog.Managers/"]
RUN dotnet restore "DasBlog.Web/DasBlog.Web.csproj"
COPY . .
WORKDIR "/src/DasBlog.Web"
RUN dotnet build "DasBlog.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DasBlog.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
# ⭐ Default environment variables for runtime
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://0.0.0.0:5000
ENV APPLICATIONINSIGHTS_CONNECTION_STRING="InstrumentationKey=00000000-0000-0000-0000-000000000000"

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DasBlog.Web.dll"]
