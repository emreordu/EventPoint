FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
COPY ./EventPoint.Core/*.csproj ./EventPoint.Core/
COPY ./EventPoint.Domains/*.csproj ./EventPoint.Entity/
COPY ./EventPoint.DataAccess/*.csproj ./EventPoint.DataAccess/
COPY ./EventPoint.Business/*.csproj ./EventPoint.Business/
COPY ./EventPoint.WebUI/*.csproj ./EventPoint.WebUI/
COPY *.sln .
RUN dotnet Restore
COPY . .
RUN dotnet publish ./EventPoint.WebUI/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app 
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*.5009/"
ENTRYPOINT [ "dotnet","EventPoint.WebUI.dll" ]