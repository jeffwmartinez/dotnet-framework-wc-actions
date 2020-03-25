
#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

# BUILD SERVER | Set the working directory to src to copy everything into
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 as build
WORKDIR "/src"


# RESTORE DEPENDENCIES | copy over packages and run restore on them
COPY taskapp/taskapp.sln .
COPY taskapp/taskapp/taskapp.csproj taskapp/taskapp/taskapp.csproj
COPY taskapp/taskapp/packages.config taskapp/taskapp/packages.config
RUN nuget restore taskapp/taskapp/packages.config -PackagesDirectory taskapp/packages


# BUILD THE PROJECT | # Copy in what's in our source from the current directory ---->>> to the target directory inside of the container | build your project in release mode on as many processors available | Deploy on Build the project so it will do the publish step associated with the build
#WORKDIR "/src"
COPY . .
WORKDIR /src/taskapp/taskapp
RUN msbuild taskapp.csproj /p:Configuration=Release /m /p:DeployOnBuild=true /p:PublishProfile=FolderProfile


# PRODUCTION RUNTIME IMAGE
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 as deploy


# PUBLISH APP | copy the infomration from the other image you built above
WORKDIR /inetpub/wwwroot
COPY --from=build /src/taskapp/taskapp/bin/Release/Publish .


# the launch command is in the base image so there isn't a need for a CMD
# IF WE DONT HAVE A DOCKER IGNORE FILE, IT WILL LOOK FOR THE GITIGNORE FILE AND GO FROM THAT....