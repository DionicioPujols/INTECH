# INTECH

Proyecto Final de AP1 - INTECH (Ingeniería y Tecnología Hernández).

## Organización

- `INTECH.slnx`: solución en la raíz del repositorio.
- `INTECH/`: proyecto Blazor de la aplicación con .NET 11.
- Los proyectos de pruebas, como `INTECH.Tests`, pueden agregarse a la solución junto a la carpeta de la aplicación.

## Compilar y ejecutar

Desde la raíz del repositorio:

```powershell
dotnet build INTECH.slnx
dotnet run --project INTECH/INTECH.csproj --launch-profile https
```

Para trabajar con migraciones, entra en `INTECH/` e indica el contexto correspondiente:

```powershell
cd INTECH
dotnet ef database update --context Contexto
dotnet ef database update --context ApplicationDbContext
```
