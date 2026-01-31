# InventarioApp 🧾

[![Build Status](https://github.com/Lokcis/inventory_system_desktop/actions/workflows/ci.yml/badge.svg)](https://github.com/Lokcis/inventory_system_desktop/actions/workflows/ci.yml) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

**Sistema de inventarios (front-end)** construido en C# con **Avalonia** para ser multiplataforma (Windows, macOS, Linux). Esta solución contiene la interfaz de usuario de una aplicación de inventario pensada para ejecutarse en cualquier sistema mediante .NET y Avalonia.

---

## 📌 Tabla de contenidos

- [Descripción](#descripción)
- [Características](#características)
- [Tecnologías](#tecnologías)
- [Requisitos](#requisitos)
- [Instalación y ejecución](#instalación-y-ejecución)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Desarrollo y aportes](#desarrollo-y-aportes)
- [Pruebas](#pruebas)
- [Publicación / Empaquetado](#publicación--empaquetado)
- [Licencia](#licencia)
- [Contacto](#contacto)

---

## 📝 Descripción

Interfaz de escritorio para el sistema de inventarios, implementada con **C#** y **Avalonia UI**. El objetivo es proporcionar una aplicación ligera, moderna y multiplataforma capaz de integrarse con un backend (API) que gestione la lógica y el almacenamiento.

## ✅ Características

- UI multiplataforma con Avalonia
- Organización MVVM (Model-View-ViewModel)
- Soporte para temas y estilos (carpeta `Styles`)
- Capas separadas para modelos, servicios y vistas
- Preparada para consumo de APIs REST

## 🔧 Tecnologías

- .NET (recomendado: .NET 6 o superior)
- Avalonia UI
- C#

## ⚙️ Requisitos

- .NET SDK 6.0+ instalado (https://dotnet.microsoft.com/)
- Avalonia (se instala como paquete NuGet en el proyecto)
- Git (para clonar el repositorio)
- Opcional: Visual Studio / Rider / VS Code con extensiones de C# y Avalonia

---

## 🚀 Instalación y ejecución

1. Clona el repositorio:

```bash
git clone https://github.com/Lokcis/inventory_system_desktop.git
cd inventory_system_desktop
```

2. Restaura dependencias y compila:

```bash
dotnet restore
dotnet build
```

3. Ejecuta la aplicación (reemplaza `ProjectName` por el proyecto de UI si aplica):

```bash
dotnet run --project src/ProjectName
```

> Alternativa: abre `InventarioApp.sln` en Visual Studio o Rider y ejecuta desde el IDE.

---

## 📁 Estructura del proyecto

- `src/`
  - `Assets/` – imágenes y recursos
  - `Helpers/` – utilidades y extensiones
  - `Models/` – entidades del dominio (productos, proveedores, etc.)
  - `Services/` – acceso a datos / llamadas a API
  - `Styles/` – temas y recursos XAML
  - `ViewModels/` – lógica de presentación (MVVM)
  - `Views/` – ventanas y controles (XAML)

- `tests/` – pruebas unitarias (pendiente de implementar)

---

## 🛠 Desarrollo y aportes

Lee la guía completa de contribución en [`CONTRIBUTING.md`](CONTRIBUTING.md) para detalles sobre flujo de trabajo, convenciones y PRs.

- Crea una rama con el prefijo `feature/` o `fix/`.
- Abre un issue antes de cambios grandes (usa las plantillas disponibles: bug/feature).
- Envía Pull Requests bien descritos y con cambios pequeños y coherentes.

Sugerencias para commits: **tipo(scope): descripción corta** (ej.: `feat(ui): agregar pantalla de productos`).

---

## ✅ Pruebas

Actualmente la carpeta `tests/` está preparada pero puede estar vacía. Cuando se agreguen pruebas:

```bash
dotnet test
```

Además, el CI ahora comprueba el formato de código con `dotnet format --verify-no-changes`. Para formatear localmente:

```bash
dotnet tool install -g dotnet-format
dotnet format
```

---

## 📦 Publicación / Empaquetado

Ejemplo para publicar una build auto-contenida para Windows x64:

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

Ajusta el `-r` (runtime identifier) según plataforma: `win-x64`, `linux-x64`, `osx-x64`, etc.

---

## 📜 Licencia

Este proyecto está bajo la licencia **MIT** — consulta el archivo `LICENSE` para más detalles.

---

## ✉️ Contacto

Para preguntas o ayuda, abre un issue en el repositorio o contacta al autor del proyecto.

---
