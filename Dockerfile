FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#Copy Csproj

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
EXPOSE 5000 5001
ENV ASPNETCORE_URLS=http://+:5000;https://+:5001

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "customerapi.dll"]
