FROM mcr.microsoft.com/dotnet/aspnet:8.0.8-azurelinux3.0-distroless-amd64 AS base
USER app
WORKDIR /usr/app

FROM mcr.microsoft.com/dotnet/sdk:8.0.402-azurelinux3.0-amd64 AS build
WORKDIR /usr/app

FROM debian:bullseye-slim AS intermediate
RUN apt-get update && apt-get install -y libicu-dev && rm -rf /var/lib/apt/lists/*

FROM build AS final-build
COPY --from=intermediate /usr/lib/x86_64-linux-gnu/libicu* /usr/lib/x86_64-linux-gnu/

COPY ["./Estoque/Magalu.API/Magalu.API.csproj", "./Magalu.API/"]
RUN dotnet restore "./Magalu.API/Magalu.API.csproj"

COPY ./Estoque/Magalu.API/ ./Magalu.API
COPY ./Estoque/Magalu.Estoque/ ./Magalu.Estoque

RUN dotnet publish "./Magalu.API/Magalu.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /usr/app

COPY --from=final-build /app/publish .
COPY --from=final-build /usr/lib/x86_64-linux-gnu/libicu* /usr/lib/x86_64-linux-gnu/

EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT [ "dotnet", "Magalu.API.dll" ]