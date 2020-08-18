FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#the working directory
WORKDIR /src

#restore nuget packages
COPY *.csproj .
RUN dotnet restore

#copy source code (copy project .CS files and folders to src directory)
COPY . .

#build the source code using the SDK
RUN dotnet publish -c release -o /executable --no-restore

# runs the deployable using a separate image
# that is shipped with the .NET Runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /executable .
ENTRYPOINT ["dotnet", "PostsManager.LogsApi.dll"]