# Guía de Releases

Esta guía explica cómo preparar e publicar una release para InventarioApp.

## 1. Preparación
- Asegúrate de que `desarrollo` esté estable y que todas las PRs pendientes hayan pasado CI.
- Actualiza `CHANGELOG.md` (usa estilo "Keep a Changelog").
- Aumenta la versión en el proyecto (si aplica) y documenta cambios.

## 2. Crear una release manual
1. Abre PR desde `desarrollo` hacia `main` y consigue aprobaciones (1 o más) y que CI esté verde.
2. Mergea la PR en `main`.
3. Crea un tag semántico: `git tag -a vX.Y.Z -m "Release vX.Y.Z"` seguido de `git push origin vX.Y.Z`.
4. En GitHub, ve a la sección Releases → Draft a new release → selecciona el tag y pega el changelog.

## 3. Automatizar releases (opcional)
- Podemos añadir un workflow que publique automáticamente al crear un tag o al merge en `main`.
- Ejemplo de pasos: compilar, ejecutar tests, empaquetar artefactos y subir a GitHub Releases.

## 4. Publicar artefactos
- Para generar builds auto-contenidas por plataforma:
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```
- Sube los artefactos a la release en GitHub.

---

Si quieres que cree un workflow de `release.yml` que automatice parte de esto, dímelo y lo preparo para la repo (puede correr en tags o cuando se mergea a `main`).