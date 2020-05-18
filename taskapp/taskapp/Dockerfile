# Set the base image
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 as build
WORKDIR "/src"

# Copy packages to your image and restore them
COPY taskapp/taskapp.sln .
COPY taskapp/taskapp/taskapp.csproj taskapp/taskapp/taskapp.csproj
COPY taskapp/taskapp/packages.config taskapp/taskapp/packages.config
RUN nuget restore taskapp/taskapp/packages.config -PackagesDirectory taskapp/packages

# Add files from source to the current directory and publish the deployment files to the folder profile
COPY . .
WORKDIR /src/taskapp/taskapp
RUN msbuild taskapp.csproj /p:Configuration=Release /m /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

# Layer the production runtime image
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 as deploy

# Add the publish files into the right directory
WORKDIR /inetpub/wwwroot
COPY --from=build /src/taskapp/taskapp/bin/Release/Publish .
