# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiamos solo el archivo de proyecto y restauramos las dependencias primero para aprovechar el caché de Docker
COPY *.csproj ./
RUN dotnet restore

# Copiamos el resto de los archivos de la aplicación y compilamos la aplicación en modo Release
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiamos solo los archivos publicados desde la etapa de compilación para reducir el tamaño de la imagen
COPY --from=build /app/out ./

# Exponemos el puerto en el que se ejecutará la aplicación (asegúrate de que coincida con el puerto de tu aplicación)
EXPOSE 80

# Configuración del usuario no root para mejorar la seguridad
RUN useradd -r -u 1001 appuser
USER appuser

# Iniciamos la aplicación ASP.NET Core cuando se ejecute el contenedor
ENTRYPOINT ["dotnet", "DockerDotNetLearning.Api.dll"]
