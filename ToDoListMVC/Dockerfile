#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ToDoListMVC/ToDoListMVC.csproj", "ToDoListMVC/"]
RUN dotnet restore "ToDoListMVC/ToDoListMVC.csproj"
COPY . .
WORKDIR "/src/ToDoListMVC"
RUN dotnet build "ToDoListMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoListMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
# COPY ToDoListMVC/app.db .
# COPY ToDoListMVC/ToDoListMVC.db .
ENTRYPOINT ["dotnet", "ToDoListMVC.dll"]

# build
# docker build -t todo-list-mvc -f .\Dockerfile ./../

# run
# docker run -it --rm todo-list-mvc -p 80:80
# docker run -dt -v "C:\Users\JohnPC\vsdbg\vs2017u5:/remote_debugger:rw" -v "E:\WORK\2_Practice\ToDoListMVC\ToDoListMVC:/app" -v "E:\WORK\2_Practice\ToDoListMVC:/src" -v "C:\Users\JohnPC\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro" -v "C:\Users\JohnPC\.nuget\packages\:/root/.nuget/fallbackpackages2" -v "C:\Program Files\dotnet\sdk\NuGetFallbackFolder:/root/.nuget/fallbackpackages" -e "DOTNET_USE_POLLING_FILE_WATCHER=1" -e "ASPNETCORE_ENVIRONMENT=Development" -e "NUGET_PACKAGES=/root/.nuget/fallbackpackages2" -e "NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages;/root/.nuget/fallbackpackages2" -p 1072:80 --name ToDoListMVC_1 --entrypoint tail todolistmvc:dev -f /dev/null

# docker exec -i -w "/app" df6750fac1389b8e8719b3c41e913fb8f20c2797731bd414e535aace5d019c22 sh -c ""dotnet" --additionalProbingPath /root/.nuget/fallbackpackages2 --additionalProbingPath /root/.nuget/fallbackpackages  "bin/Debug/netcoreapp3.1/ToDoListMVC.dll" | tee /dev/console"