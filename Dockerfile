# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución
COPY . ./

# Listar contenido para depuración
RUN ls -la

# Restaurar dependencias y publicar la API
RUN dotnet restore "API_Estudiantes_Test/API_Estudiantes_Test.csproj" || \
    dotnet restore "*/API_Estudiantes_Test.csproj" || \
    echo "No se encontró el proyecto API_Estudiantes_Test.csproj"

# Publicar la API
RUN dotnet publish "API_Estudiantes_Test/API_Estudiantes_Test.csproj" -c Release -o /app/out || \
    dotnet publish "*/API_Estudiantes_Test.csproj" -c Release -o /app/out || \
    echo "No se pudo publicar el proyecto API"

# Verificar que se generó un archivo DLL válido
RUN ls -la /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer puertos
EXPOSE 80
EXPOSE 443
EXPOSE 8080
EXPOSE 5000

# Configuración de variables de entorno para Render
ENV ASPNETCORE_URLS=http://+:8080

# Punto de entrada específico
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]