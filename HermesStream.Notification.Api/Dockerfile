# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY HermesStream.Notification.Api/HermesStream.Notification.Api/HermesStream.Notification.Api.csproj HermesStream.Notification.Api/
COPY HermesStream.Notification.Infrastructure/HermesStream.Notification.Infrastructure/HermesStream.Notification.Infrastructure.csproj HermesStream.Notification.Infrastructure/
COPY HermesStream.Notification.Repository/HermesStream.Notification.Repository/HermesStream.Notification.Repository.csproj HermesStream.Notification.Repository/
COPY HermesStream.Notification.Service/HermesStream.Notification.Service/HermesStream.Notification.Service.csproj HermesStream.Notification.Service/
COPY HermesStream.Notification.Tests/HermesStream.Notification.Tests/HermesStream.Notification.Tests.csproj HermesStream.Notification.Tests/

# Restaurar as dependências
RUN dotnet restore HermesStream.Notification.Api/HermesStream.Notification.Api.csproj

# Copiar o resto do código da aplicação
COPY . .

# Build da aplicação
RUN dotnet build HermesStream.Notification.Api/HermesStream.Notification.Api.csproj -c Release -o /app

# Estágio de publicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
CMD ["dotnet", "HermesStream.Notification.Api.dll"]
