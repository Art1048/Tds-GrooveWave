# Imagem base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Configuração da aplicação
WORKDIR /app
COPY . .

# Restaurar dependências e compilar
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Imagem final
FROM postgres:latest

# Variáveis de ambiente
ENV POSTGRES_USER Art
ENV POSTGRES_PASSWORD 4Vfl4AtYdFMrxNq
ENV POSTGRES_DB meu_postgres

# Copiar a web API para a imagem
COPY --from=build /app/out /app

# Executar scripts SQL ao iniciar o contêiner do PostgreSQL
COPY init.sql /docker-entrypoint-initdb.d/

# Porta exposta
EXPOSE 5432

# Comando para iniciar a aplicação
CMD ["postgres"]