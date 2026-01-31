# Guía de pruebas (Testing Guide)

Esta guía explica cómo escribir y ejecutar pruebas en InventarioApp.

## Herramientas
- xUnit (ya configurado en `tests/InventarioApp.Tests`).
- `dotnet test` para ejecutar pruebas.
- (Opcional) herramientas para cobertura (coverlet, reportgenerator) si decides añadir badge de cobertura.

## Convenciones
- Nombres: `<Clase>Tests` (ej.: `ProductViewModelTests`).
- Métodos de prueba: `NombreAccion_Escenario_Resultado` (ej.: `Add_IncreasesQuantity`).
- Tests unitarios: prueban ViewModels y servicios en aislamiento (mock de dependencias).

## Cómo añadir una prueba
1. Crear test en `tests/InventarioApp.Tests` con `Fact` o `Theory`.
2. Referenciar el proyecto core: ya hay `ProjectReference` en el csproj de tests.
3. Ejecutar `dotnet test` y confirmar que las pruebas pasan.

## Best practices
- Testea la lógica del ViewModel y no la UI directamente.
- Cubre casos normales y bordes (input inválido, errores de servicio, excepciones esperadas).
- Mantén las pruebas deterministas y rápidas; evita dependencias externas (usa mocks).

## Ejemplo rápido
```csharp
[Fact]
public void Add_IncreasesQuantity()
{
    var product = new Product { Name = "Test", Quantity = 5 };
    var vm = new ProductViewModel(product);

    vm.Add(3);

    Assert.Equal(8, vm.Quantity);
}
```
