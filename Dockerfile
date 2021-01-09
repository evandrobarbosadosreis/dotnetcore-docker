# A imagem base do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copia os arquivos .csproj para suas respectivas pastas e restaura os pacotes 
COPY Mensagens.Dominio/*.csproj Mensagens.Dominio/
COPY Mensagens.WebApi/*.csproj Mensagens.WebApi/
RUN dotnet restore Mensagens.WebApi/Mensagens.WebApi.csproj

# Copia todo o conteúdo das pastas e realiza o build do projeto
COPY Mensagens.Dominio/ Mensagens.Dominio/
COPY Mensagens.WebApi/ Mensagens.WebApi/
WORKDIR Mensagens.WebApi/
RUN dotnet build -c release --no-restore

# Após realizar o build, publish da solução no diretório app
FROM build AS publish
RUN dotnet publish -c release --no-build -o app/

# Agora utilizando a imagem do .NET Runtime, copia os assemblies 
# gerados na publicação e executa a nossa aplicação 
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR app/
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mensagens.WebApi.dll"]