# Arquitectura — InventarioApp (Front-end)

Este documento describe la arquitectura de alto nivel y las responsabilidades de los componentes del front-end.

## Principios
- Separación de responsabilidades (MVVM): Views (XAML) sólo UI, ViewModels contienen lógica de presentación, Models representan datos del dominio.
- Testabilidad: lógica en ViewModels/Services probado mediante unit tests (xUnit).
- Extensibilidad: Services desacoplados por interfaces para permitir mocks y adaptadores.

## Componentes principales
- `Models/` — objetos POCO con propiedades y validaciones simples. Ejemplo: `Product` (Name, Quantity).
- `ViewModels/` — clases que implementan `INotifyPropertyChanged`, exponen propiedades para binding, comandos y métodos para la UI (Add/Remove en `ProductViewModel`).
- `Services/` — interfaces y clases que encapsulan el acceso a datos (p. ej., `IProductService` con métodos `GetAllAsync`, `CreateAsync`, `UpdateAsync`, `DeleteAsync`).
- `Views/` — XAML y controles Avalonia que enlazan con ViewModels mediante DataContext.
- `Helpers/` — utilidades, convertidores y extensiones (ej.: `AsyncCommand`, `ValueConverters`).

## Flujo típico de datos
1. View muestra la UI y enlaza a propiedades del ViewModel.
2. El usuario interactúa (ej.: pulsa botón para añadir producto); el comando del ViewModel procesa la acción.
3. El ViewModel usa `IProductService` para persistir datos o consultar el backend.
4. Las actualizaciones se propagan a la View mediante binding y PropertyChanged.

## Contratos sugeridos (ejemplo)
```csharp
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task CreateAsync(Product p);
    Task UpdateAsync(Product p);
    Task DeleteAsync(int id);
}
```

## Donde añadir código
- Nuevas entidades → `src/InventarioApp.Core/Models`
- Nuevos servicios e interfaces → `src/InventarioApp.Core/Services`
- ViewModels → `src/InventarioApp.Core/ViewModels`
- Views → `src/InventarioApp/Views` (XAML)
- Estilos y recursos XAML → `src/Styles`

## Observaciones
- Mantén la lógica de UI (animaciones, triggers) dentro de Views y estilos; evita mezclar lógica en code-behind salvo inicialización ligera.
- Añade tests unitarios para la lógica del ViewModel y para la implementación de Services (usa mocks para dependencias externas).
