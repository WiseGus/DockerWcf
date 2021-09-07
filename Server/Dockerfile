FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2-windowsservercore-ltsc2019 AS build
# FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2 AS build
WORKDIR /app
COPY /. .
RUN msbuild /p:Configuration=Release

FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2-windowsservercore-ltsc2019 AS runtime
# FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2 AS runtime
EXPOSE 80
EXPOSE 808
WORKDIR /app
COPY --from=build /app/bin/Release .
ENTRYPOINT DockerWcfDemo.exe