# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS ms_dotnet_core_build
WORKDIR /app

#Install nodejs
RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_14.x  | bash -
RUN apt-get -y install nodejs

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
# FROM microsoft/aspnetcore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY --from=ms_dotnet_core_build /app/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MD.Accountella.WebApp.dll
