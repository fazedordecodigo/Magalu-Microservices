FROM mcr.microsoft.com/dotnet/aspnet:8.0.8-azurelinux3.0-distroless-amd64 AS base
USER app
WORKDIR /usr/app

FROM mcr.microsoft.com/dotnet/sdk:8.0.402-azurelinux3.0-amd64 AS build
WORKDIR /usr/app

COPY ["./Estoque/Magalu.API/Magalu.API.csproj", "./Magalu.API/"]
RUN dotnet restore "./Magalu.API/Magalu.API.csproj"

COPY ./Estoque/Magalu.API/ ./Magalu.API
COPY ./Estoque/Magalu.Estoque/ ./Magalu.Estoque

RUN dotnet publish "./Magalu.API/Magalu.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /usr/app

COPY --from=build /app/publish .
COPY --from=ghcr.io/ufoscout/docker-compose-wait:latest /wait /wait

EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT=Development

ENV WAIT_COMMAND="dotnet Magalu.API.dll"

ENTRYPOINT [ "/wait" ]