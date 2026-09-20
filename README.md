# Naiquen Iturralde — Portfolio

Portfolio profesional desarrollado con **Blazor WebAssembly (.NET 8)** que reúne proyectos de
desarrollo de software, videojuegos, diseño UX/UI y bases de datos.

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![Blazor WebAssembly](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?logo=blazor&logoColor=white)
![Deploy](https://img.shields.io/badge/Deploy-GitHub%20Pages-222222?logo=githubpages&logoColor=white)

**[▶ Ver demo en vivo](https://naiqueniturralde.github.io/Portfolio/)** ·
**[GitHub](https://github.com/NaiquenIturralde)** ·
**[LinkedIn](https://www.linkedin.com/in/naiquen-iturralde-5a4a4021a/)**

---

## Sobre el proyecto

Soy **desarrolladora web en formación**, enfocada en crear interfaces claras, funcionales y fáciles
de usar. Este portfolio es mi proyecto propio de desarrollo: una SPA en **Blazor WebAssembly** que
presenta mis trabajos de software, videojuegos, diseño UX/UI y modelado de bases de datos.

El sitio es **bilingüe (Español / English)** con un sistema de traducción propio, y toda la interfaz
—layout, componentes, animaciones y estilos— está construida con **CSS puro y Scoped CSS de Blazor**,
sin frameworks de UI ni dependencias de npm.

---

## Tecnologías

| Categoría            | Tecnología                                                                   |
| -------------------- | ---------------------------------------------------------------------------- |
| Framework            | Blazor WebAssembly (`.NET 8`)                                                |
| Lenguaje             | C# (Nullable e ImplicitUsings habilitados)                                   |
| Estilos              | CSS3 con variables, glassmorphism y **Scoped CSS** por componente            |
| Tipografía           | Google Fonts — Poppins                                                       |
| Internacionalización | Servicio propio `LanguageService` (ES/EN) con persistencia en `localStorage` |
| Interoperabilidad JS | `IJSRuntime` para `localStorage` y Clipboard API                             |
| Routing              | Router de Blazor + `NavigationManager` (SPA)                                 |
| Despliegue           | GitHub Actions → GitHub Pages                                                |

### Paleta de colores

Definida como variables CSS en `wwwroot/css/app.css`:

```css
--primary-dark: #0f0b1f;
--secondary-dark: #1a1530;
--tertiary-dark: #251d3d;
--accent-purple: #7c3aed;
--accent-purple-light: #a78bfa;
--accent-purple-dark: #5b21b6;
--accent-pink: #d946ef;
--accent-cyan: #06b6d4;
--light: #f8fafc;
```

---

## Secciones del sitio

| Ruta                   | Sección        | Contenido                                                                |
| ---------------------- | -------------- | ------------------------------------------------------------------------ |
| `/`                    | Inicio         | Hero, métricas, perfil extendido, CryptoView destacado y accesos rápidos |
| `/games`               | Games          | Oceánida, Bosque Encantado y Pac Team                                    |
| `/software`            | Software       | CryptoView                                                               |
| `/design`              | Diseño         | Rider One                                                                |
| `/riderone`            | Rider One      | Caso de estudio: informe en carrusel, evolución, arquitectura y videos   |
| `/databases`           | Bases de Datos | Modelado relacional, DER y casos de uso de CryptoView                    |
| `/certificados`        | Certificados   | Formación complementaria y certificaciones obtenidas                     |
| `/pacteampresentation` | Pac Team       | Presentación del proyecto en slides                                      |

---

## Proyectos destacados

### CryptoView

Sistema web de seguimiento de criptomonedas con dashboard de mercado, gráficos, gestión de usuarios
y roles, notas personales, preferencias y modo claro/oscuro.

**Stack:** Blazor Server · ASP.NET Core · SQL Server · API REST externa · CRUD · autenticación y roles.

→ [Ver demo](https://youtu.be/Ly_RvPX1kv4) · [Ver código](https://github.com/NaiquenIturralde/CryptoView)

### Rider One

Sistema inteligente de señalización vial y seguridad para ciclistas. Combina diseño UX/UI, diseño 3D,
software, electrónica y prototipado físico.

**Stack:** UX/UI · Figma · diseño 3D · ESP32 · IoT · hardware.

→ [Ver caso de estudio](https://naiqueniturralde.github.io/Portfolio/riderone)

### Oceánida

Juego educativo de exploración submarina inspirado en los avistamientos del CONICET en Mar del Plata.
Las decisiones del jugador impactan en el ecosistema marino. Desarrollado junto a Mateo Lemes.

**Stack:** GDevelop · 2D · diseño narrativo.

→ [Jugar](https://naiquen-anael-iturralde.itch.io/ocenidaweb)

### Bosque Encantado

Aventura narrativa donde cada decisión afecta las relaciones con los habitantes del bosque y
desbloquea distintos finales. Colaboración con alumnas MetJam.

**Stack:** RPG Playground · narrativa ramificada.

→ [Jugar](https://rpgplayground.com/game/bosque-encantado-4/)

### Pac Team

Juego cooperativo de puzzles para móvil, actualmente en desarrollo.

**Stack:** Unity · 3D · multijugador.

→ [Ver presentación](https://naiqueniturralde.github.io/Portfolio/pacteampresentation)

---

## Características principales

- **Bilingüe ES/EN** con un servicio de traducción propio; la preferencia se conserva en `localStorage`.
- **Scoped CSS por componente**, para estilos aislados y mantenibles.
- **Sin frameworks JS de terceros**: no hay npm, bundlers ni librerías de UI.
- **Componentes reutilizables**: cards de proyecto, carrusel de imágenes, visor fullscreen, embed de
  YouTube, modal de contacto, botón animado, selector de idioma y footer de navegación cruzada.
- **Navegación cruzada** entre todas las secciones y navbar responsive con menú móvil.
- **Accesibilidad**: foco en el título al navegar, `aria-label` en controles, navegación por teclado
  en el carrusel y scroll suave.

---

## Ejecución local

**Requisitos**

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (el proyecto fija la versión del SDK
  mediante `global.json`)
- Un navegador moderno. Visual Studio 2022 o VS Code son opcionales.

**Pasos**

```bash
# 1. Clonar el repositorio
git clone https://github.com/NaiquenIturralde/Portfolio.git
cd Portfolio

# 2. Restaurar dependencias
dotnet restore

# 3. Ejecutar
dotnet run
```

La aplicación queda disponible en la URL que muestra la consola. Para usar el perfil HTTPS del
DevServer con hot reload:

```bash
dotnet run --launch-profile https
```

---

## Deploy

El despliegue es automático con **GitHub Actions + GitHub Pages** (`.github/workflows/deploy.yml`).
En cada push a `main` el workflow compila el proyecto en Release, ajusta el `base href` del sitio
publicado, genera un `404.html` para que el router de Blazor resuelva las rutas SPA y publica el
artefacto en GitHub Pages.

No requiere ramas adicionales ni configuración manual. El sitio publicado está en
**https://naiqueniturralde.github.io/Portfolio/**

---

## Estructura del proyecto

```
PortfolioNaiquen/
├── PortfolioNaiquen.csproj      # Proyecto Blazor WebAssembly (.NET 8)
├── global.json                  # Fija la versión del SDK de .NET
├── Program.cs                   # Arranque y registro de servicios
├── App.razor                    # Router principal y layout por defecto
│
├── Pages/                       # Páginas enrutadas, una por sección del sitio
├── Services/                    # LanguageService: traducciones ES/EN
├── Shared/                      # Layout principal y bloques de contenido
│   └── Components/              # Componentes reutilizables (cada uno con su .razor.css)
├── wwwroot/                     # index.html, css/, img/, certificados/, docs/ y PDFs
└── .github/workflows/           # Build y deploy automático a GitHub Pages
```

---

## Contacto

¿Querés sumar mi perfil a tu equipo o consultarme por alguno de los proyectos?

**Email:** [iturraldenaiquen@gmail.com](mailto:iturraldenaiquen@gmail.com)

---

## Uso del código

Este repositorio contiene mi portfolio personal: el diseño, los textos, las imágenes y los proyectos
mostrados son de mi autoría. El código está disponible públicamente con fines de consulta y
referencia. Si querés reutilizar alguna parte, contactame por email.
