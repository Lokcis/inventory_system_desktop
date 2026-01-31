# Guía de desarrollo — InventarioApp (Front-end)

Esta guía documenta toda la información necesaria para desarrollar, probar y mantener el front-end (Avalonia + C#) del proyecto.

## 1. Visión general del proyecto
- Proyecto: InventarioApp (interfaz de escritorio multiplataforma usando Avalonia).
- Objetivo: UI ligera y modular que consuma un backend (API REST) para gestionar inventario.

## 2. Estructura del repositorio (explicada)
- `InventarioApp.sln` — solución que agrupa los proyectos.
- `src/InventarioApp.Core/` — lógica compartida, modelos y ViewModels.
  - `Models/` — entidades (Product, Supplier, etc.).
  - `ViewModels/` — lógica de presentación (implementan INotifyPropertyChanged).
- `src/InventarioApp/` — proyecto de UI (Avalonia XAML, por crear en fases siguientes).
- `src/Views/`, `src/Styles/`, `src/Helpers/`, `src/Services/` — carpetas para UI, recursos, utilidades y servicios (API).
- `Assets/` — imágenes y recursos del repo (diagramas, logos).
- `tests/InventarioApp.Tests/` — pruebas unitarias (xUnit).
- `.github/` — workflows y plantillas de PR/Issue.

## 3. Flujo de trabajo (resumen, ampliado)
- Ramas:
  - `main` — protegida; sólo merge vía PR, CI y 1 aprobación.
  - `desarrollo` — integración; PRs con CI requeridos, sin aprobaciones obligatorias.
  - `feature/<nombre>` / `fix/<nombre>` — ramas de trabajo individuales.
- Reglas de commits: convención `tipo(scope): descripción` (ej.: `feat(ui): agregar lista de productos`).

## 4. Cómo añadir una nueva pantalla (paso a paso)
1. Crea una rama: `git checkout -b feature/vista-productos` desde `desarrollo`.
2. Añade ViewModel en `src/InventarioApp.Core/ViewModels`.
   - Debe implementar `INotifyPropertyChanged` y lógica pura (sin referencias a Avalonia).
   - Añade pruebas unitarias en `tests/InventarioApp.Tests` para la lógica del ViewModel.
3. Crea la vista XAML en `src/InventarioApp/Views` y enlaza con el ViewModel (DataContext).
4. Añade estilos en `src/Styles` si necesitas theme o recursos XAML.
5. Ejecuta localmente:
```bash
dotnet restore
dotnet build
dotnet test
```
6. Aplica formato: `dotnet format`.
7. Haz push y abre PR hacia `desarrollo` (usa template). Espera CI (checks) y mergea cuando pase.

## 5. Services / API (cómo integrar)
- Implementa interfaces en `src/InventarioApp.Core/Services` que representen llamadas a API (ej.: `IProductService`).
- Añade implementaciones "mock" para pruebas locales y un adaptador para llamadas HTTP (HttpClient) para producción.

## 6. Tests
- Proyectos de tests viven en `tests/` y usan xUnit.
- Recomendación: unit tests para ViewModels, servicios y helpers; evitar pruebas UI a menos que implementes integraciones específicas para Avalonia.
- Ejecutar: `dotnet test`.

## 7. CI
- Workflow `.github/workflows/ci.yml` se encarga de `restore`, `dotnet format --verify-no-changes`, `build` y `test` en Ubuntu/Windows/macOS.
- Si agregas nuevos checks (p. ej. cobertura), actualiza el workflow y las reglas de branch protection.

## 8. Formato y estilo
- Usa `dotnet format` antes de crear PRs.
- Sigue guía de estilos de C# y patrones MVVM.

## 9. Releases
- Proceso manual o automático (podemos añadir workflow de release más adelante).
- Para publicar builds auto-contenidas: `dotnet publish -c Release -r <RID> --self-contained true -p:PublishSingleFile=true`.

## 10. Documentación adicional y recursos
- `README.md` — resumen y comandos principales.
- `CONTRIBUTING.md` — guía de contribución (flow, PR, tests, etc.).
- `CODE_OF_CONDUCT.md` — conducta del proyecto.

---

Si quieres, puedo:
- añadir una plantilla de `IProductService` y una implementación mock con tests; o
- crear el proyecto `src/InventarioApp` (Avalonia app) con una ventana básica y enlazado al `ProductViewModel` para mostrar la lista básica.

Dime qué prefieres y lo implemento. ¡Documenté cada sección con pasos concretos para que no quede nada suelto! 🎯