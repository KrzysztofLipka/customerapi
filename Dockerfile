FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-en
WORKDIR /app

#Copy Csproj

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2:2
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "customerapi.dll"]