# BUILD SERVER | Set the working directory to src to copy everything into
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 as build
WORKDIR "/src"

# RESTORE DEPENDENCIES | copy over packages and run restore on them
COPY taskapp/taskapp.sln .
COPY taskapp/taskapp/taskapp.csproj taskapp/taskapp/taskapp.csproj
COPY taskapp/taskapp/packages.config taskapp/taskapp/packages.config
RUN nuget restore taskapp/taskapp/packages.config -PackagesDirectory taskapp/packages

# BUILD THE PROJECT | copy from the curret directory to the target directory inside of the container.  Build your project in release mode on as many processors available. Run MSBuild in release mode and publish the files to the correct folder
COPY . .
WORKDIR /src/taskapp/taskapp
RUN msbuild taskapp.csproj /p:Configuration=Release /m /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

# PRODUCTION RUNTIME IMAGE
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 as deploy

# PUBLISH APP | copy the infomration from the other image you built above into the wwwroot directory
WORKDIR /inetpub/wwwroot
COPY --from=build /src/taskapp/taskapp/bin/Release/Publish .
