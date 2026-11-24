# INTECH

Proyecto Final de AP1 - INTECH (Ingeniería y Tecnología Hernández).

## Organización

La solución `INTECH.slnx` está en la raíz y contiene estos proyectos de .NET 11:

- `INTECH/`: portal Blazor, páginas, layouts, configuración e inicio de sesión.
- `INTECH.Data/`: Class Library con `Models/`, `Context/` y las migraciones. Incluye los contextos del negocio y de Identity.
- `INTECH.Services/`: Class Library con los servicios del negocio dentro de `Services/`.
- `INTECH.Test/`: proyecto xUnit con el test original de la plantilla.

El portal referencia `INTECH.Data` e `INTECH.Services`. Los servicios referencian `INTECH.Data`.
Se conservan los namespaces existentes y la base `INTECHDb` en SQL Server.

## Compilar y ejecutar

Desde la raíz del repositorio:

```powershell
dotnet build INTECH.slnx
dotnet run --project INTECH/INTECH.csproj --launch-profile https
```

## Migraciones

`INTECH.Data` contiene los contextos y migraciones; `INTECH` proporciona la configuración de arranque y la conexión `SqlConStr`.

```powershell
dotnet ef database update --project INTECH.Data --startup-project INTECH --context Contexto
dotnet ef database update --project INTECH.Data --startup-project INTECH --context ApplicationDbContext
```

Para agregar una migración del negocio:

```powershell
dotnet ef migrations add NombreDelCambio --project INTECH.Data --startup-project INTECH --context Contexto --output-dir Migrations
```

Las migraciones de Identity van en `Migrations/Identity`, usando `--context ApplicationDbContext`.
