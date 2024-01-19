# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY HermesStream.Notification.Api/HermesStream.Notification.Api.csproj HermesStream.Notification.Api/
COPY HermesStream.Notification.Infrastructure/HermesStream.Notification.Infrastructure.csproj HermesStream.Notification.Infrastructure/
COPY HermesStream.Notification.Repository/HermesStream.Notification.Repository.csproj HermesStream.Notification.Repository/
COPY HermesStream.Notification.Service/HermesStream.Notification.Service.csproj HermesStream.Notification.Service/

RUN dotnet restore "HermesStream.Notification.Api/HermesStream.Notification.Api.csproj"

# Copie o restante do código e construa a aplicação
COPY . .
WORKDIR "/src/HermesStream.Notification.Api"
RUN dotnet build "HermesStream.Notification.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HermesStream.Notification.Api.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HermesStream.Notification.Api.dll"]