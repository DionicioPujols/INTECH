# INTECH

Proyecto Final de AP1 - INTECH (Ingeniería y Tecnología Hernández).

Blazor Web App con .NET 11, cuentas individuales de ASP.NET Core Identity e interactividad Server global.
Requiere el SDK 11.0.100 o un parche compatible. Abre `INTECH.slnx` en esta carpeta.

## Base de datos

SQL Server Express: `.\SQLEXPRESS`, base `INTECHDb`, autenticación de Windows.
Las conexiones se configuran en `appsettings.json` y `appsettings.Development.json`:

- `SqlConStr`: conexión compartida por Identity (`ApplicationDbContext`, migraciones en `Data/Migrations`) y las entidades del negocio (`Contexto`, migraciones en `Migrations`).

```powershell
dotnet ef database update --context ApplicationDbContext
dotnet ef database update --context Contexto
dotnet run --launch-profile https
```

Migraciones iniciales: `CreateIdentitySchema` para Identity y `ConfigurarSqlServer` para el negocio.

## Autenticación

Se conservan las páginas de registro, inicio de sesión, recuperación y administración de cuenta de la plantilla.
La plantilla exige confirmación de cuenta y usa `IdentityNoOpEmailSender` para desarrollo; configura un envío real de correo antes de publicar.
La página `/auth` requiere iniciar sesión. Los roles y la protección de todas las páginas del negocio todavía deben configurarse.

## Desarrollo

Los modelos, servicios, componentes y paquetes del proyecto anterior se conservan junto con la nueva base de autenticación.
Las instrucciones locales de asistentes siguen disponibles y permanecen excluidas de Git según `.gitignore`.