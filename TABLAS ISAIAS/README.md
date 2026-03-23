# FitLife - Sistema de Gestión de Miembros (Gimnasio)

Este proyecto es una aplicación de consola para la gestión de miembros en el gimnasio "FitLife". Permite registrar, listar, buscar, actualizar y eliminar miembros utilizando una base de datos SQLite.

## Estructura del Proyecto

El proyecto sigue una arquitectura por capas, organizada de la siguiente manera:

- **Database**: Contiene el inicializador de la base de datos y la configuración de conexión.
- **Models**: Contiene la clase de entidad `Miembro`.
- **Repositories**: Clases encargadas del acceso a datos utilizando ADO.NET con SQLite.
- **Services**: Lógica de negocio para las operaciones CRUD.
- **Screens**: Interfaz de usuario de consola interactiva con Spectre.Console.
- **queries.sql**: Script de creación de tablas e inserción de datos iniciales.
- **fitlife.db**: Archivo de base de datos SQLite generado por la aplicación.

## Funcionalidades del Sistema

1. **Registrar un nuevo miembro**: Agrega nombre completo, cédula y teléfono.
2. **Listar todos los miembros**: Muestra la información de todos los afiliados.
3. **Buscar un miembro por cédula**: Localización mediante identificación personal.
4. **Actualizar el teléfono**: Modifica el contacto de un miembro existente.
5. **Eliminar un miembro**: Remueve registros con confirmación de usuario.

## Requisitos

- .NET 6.0 o superior
- SQLite

## Ejecución

Para ejecutar la aplicación, use el siguiente comando en la raíz del proyecto:

```bash
dotnet run
```

## Tecnologías Utilizadas

- **C#**
- **SQLite** (Microsoft.Data.Sqlite)
- **Spectre.Console** (Interfaz de consola moderna)
