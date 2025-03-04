# Proyecto de Prueba Técnica

Este es un proyecto de ejemplo que utiliza ASP.NET Core, Dapper y MemoryCache para gestionar una lista de asignaturas.

## Requisitos

- .NET 6 SDK o superior
- SQL Server

## Configuración

1. Clona el repositorio:

```sh
git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio
```
2. Crea un archivo .env con los datos de tu conexion a la base de datos:

```sh
DB_NAME=tu_nombre_de_base_de_datos
DB_USER=tu_usuario
DB_PASSWORD=tu_contraseña
DB_HOST=localhost
```
3. Ejecuta en tu BD el script de la carpeta sql.

4. Restaura los paquetes NuGet:

```sh
dotnet restore
```

5. Ejecuta el programa:

```sh
dotnet run
```

