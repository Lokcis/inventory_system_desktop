# Guía de Contribución (CONTRIBUTING)

Gracias por querer contribuir a InventarioApp. Esta guía documenta TODO lo necesario para contribuir de forma efectiva: desde cómo preparar tu entorno, pasar por las convenciones de código, hasta cómo abrir issues y PRs y qué espera el equipo en revisiones y releases.

---

## 1) Antes de empezar 🔎
- Lee el `README.md` para entender la arquitectura general.
- Comprueba si existe un issue abierto que describa lo que quieres hacer; si no, crea uno usando la plantilla de feature/bug correspondiente.

---

## 2) Código de conducta (breve) 🤝
- Respeta a los demás colaboradores. Comportamiento ofensivo o discriminatorio no será tolerado.
- Sé claro y constructivo en comentarios y revisiones.

---

## 3) Flujo de trabajo (ramas y commits) 🌲
- Ramas:
  - `main` — rama protegida, siempre en estado desplegable.
  - `desarrollo` — rama de integración para features en progreso.
  - `feature/<nombre>` — nuevas funcionalidades (ej.: `feature/vistas-inventario`).
  - `fix/<nombre>` — correcciones de bugs.
- Commits:
  - Usa formato: `tipo(scope): descripción corta` (ej.: `feat(ui): agregar pantalla de productos`).
  - Tipos recomendados: `feat`, `fix`, `chore`, `docs`, `style`, `refactor`, `test`.

---

## 4) Configurar entorno de desarrollo 🛠
Requisitos:
- .NET SDK 8.0+ (https://dotnet.microsoft.com/)
- Git
- IDE recomendado: Visual Studio / Rider / VS Code (extensiones C# y Avalonia)

Pasos rápidos:
```bash
git clone https://github.com/Lokcis/inventory_system_desktop.git
cd inventory_system_desktop
dotnet restore
dotnet build
```
Para ejecutar la UI desde IDE: abre `InventarioApp.sln` (o el proyecto de UI) y ejecuta.

---

## 5) Tests y CI ✅
- Ejecuta pruebas locales: `dotnet test` (ejecuta todos los proyectos de test o directamente el proyecto en `tests/`).
- Si agregas nueva lógica, agrega tests unitarios que cubran casos normales y borde.
- El repo tiene un workflow CI (`.github/workflows/ci.yml`) que hace `restore`, `build` y `test` en Windows/macOS/Linux. Asegúrate de que tus cambios pasen en CI antes de solicitar merge.

---

## 6) Convenciones de código y estilo ✨
- Sigue las guías de estilo de C#/.NET (preferiblemente .NET MAUI/Avalonia patterns para UI cuando aplique).
- Mantén el código limpio y con nombres descriptivos.
- Añade comentarios sólo cuando el código no sea auto-explicativo.
- Formato y herramienta:
  - Instala localmente: `dotnet tool install -g dotnet-format`
  - Aplicar formato: `dotnet format`
  - Verificar sin aplicar (CI usa esto): `dotnet format --verify-no-changes`
  - El pipeline CI fallará si hay cambios de formato pendientes; ejecuta `dotnet format` antes de crear la PR.

---

## 7) Pull Request (PR) — cómo preparar una buena PR 📋
- Crea una rama nueva desde `desarrollo`.
- Limita la PR a un único propósito/feature/fix.
- Incluye descripción completa: qué hace, por qué, cómo probarlo.
- Añade capturas o GIFs si afecta la UI.
- Verifica que `dotnet test` pase y que el CI esté verde.
- Agrega etiquetas en la PR si corresponde (bug, enhancement).

Checklist sugerido (inclúyelo en la descripción):
- [ ] Compila sin errores (`dotnet build`).
- [ ] Pruebas: pasan (`dotnet test`).
- [ ] Añadí/actualicé tests relevantes.
- [ ] Actualicé documentación si fue necesario (`README`, `CONTRIBUTING`).

---

## 8) Revisión y Merge 🔁
- Se pedirá al menos una aprobación de revisión (dependiendo de la configuración de protección de rama).
- Evita merges directos en `main` o `desarrollo` sin PR y aprobaciones.
- Resuelve conflictos rebaseando la rama con `desarrollo` o usando merge, según prefieras.

---

## 9) Releases y Publicación 🚀
- Las builds y tests se ejecutan en CI; las publicaciones de releases deben seguir el proceso acordado (tag, changelog, artifacts).
- Si necesitas publicar artefactos (por ejemplo, paquetes o instaladores), documenta el paso en la PR y revisa el workflow de release.

---

## 10) Reporte de seguridad 🔒
- Para vulnerabilidades críticas, abre un issue privado o contacta a los mantenedores directamente.

---

## 11) ¿Necesitas ayuda? 🙋
- Abre un issue y etiqueta `help wanted` o `question`.
- Si es urgente, contacta a los autores del proyecto (usa la sección `Contacto` en el `README`).

---

¡Gracias por contribuir! 🎉
