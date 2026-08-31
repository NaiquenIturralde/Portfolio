# Portfolio Naiquen Iturralde

Portfolio profesional desarrollado con **Blazor WebAssembly** para mostrar mis proyectos de desarrollo de software, diseño de videojuegos, UI/UX y arquitectura de bases de datos.

## Sobre el Proyecto

Este portfolio combina una estética moderna con tonos lila oscuro, efectos de glassmorphism y animaciones fluidas, todo sin necesidad de JavaScript adicional. Creado 100% con Blazor WebAssembly y CSS puro para ofrecer una experiencia visual impactante y profesional.

## Secciones del Sitio

- **Home**: Página de bienvenida con hero section, stats y vista previa de categorías
- **Games**: Proyectos de desarrollo de videojuegos (Oceánida, Bosque Encantado, Pac Team)
- **Software**: Aplicaciones y sistemas (CryptoView, TCP Server, Perceptrón, Proyectos Tecnicatura)
- **Design**: Galería de diseños UI/UX con flyers y composiciones gráficas
- **Databases**: Soluciones de bases de datos (Gestión Académica, Auditoría de Notas)

## Tecnologías Utilizadas

- **Blazor WebAssembly** (.NET 9.0.101)
- **CSS3** con variables personalizadas y glassmorphism
- **Google Fonts** (Poppins)
- **Navigation Manager** para enrutamiento SPA
- **Scoped CSS** para estilos por componente

### Paleta de Colores

```css
--bg-primary: #0f0b1f --accent-primary: #7c3aed --accent-secondary: #a78bfa
  --accent-tertiary: #d946ef --accent-cyan: #06b6d4;
```

## Cómo Ejecutar el Proyecto

### Requisitos Previos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) o superior
- Visual Studio 2022 / VS Code (opcional pero recomendado)

### Pasos para Correr Localmente

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/tuusuario/portfolio-naiquen.git
   cd portfolio-naiquen/PortfolioNaiquen
   ```

2. **Restaurar dependencias**

   ```bash
   dotnet restore
   ```

3. **Ejecutar la aplicación**

   ```bash
   dotnet run
   ```

4. **Abrir en el navegador**
   - Navega a `https://localhost:5205` o el puerto que se muestre en la terminal

## Publicación en GitHub Pages

### Método 1: GitHub Actions (Recomendado)

1. **Crear workflow de GitHub Actions**

   Crea el archivo `.github/workflows/deploy.yml`:

   ```yaml
   name: Deploy to GitHub Pages

   on:
     push:
       branches: [main]
     workflow_dispatch:

   jobs:
     deploy:
       runs-on: ubuntu-latest
       steps:
         - uses: actions/checkout@v3

         - name: Setup .NET
           uses: actions/setup-dotnet@v3
           with:
             dotnet-version: 9.0.x

         - name: Publish
           run: dotnet publish PortfolioNaiquen/PortfolioNaiquen.csproj -c Release -o release --nologo

         - name: Change base-tag in index.html
           run: sed -i 's/<base href="\/" \/>/<base href="\/portfolio-naiquen\/" \/>/g' release/wwwroot/index.html

         - name: Add .nojekyll file
           run: touch release/wwwroot/.nojekyll

         - name: Deploy to GitHub Pages
           uses: JamesIves/github-pages-deploy-action@v4
           with:
             folder: release/wwwroot
   ```

2. **Configurar GitHub Pages**
   - Ve a Settings → Pages en tu repositorio
   - Selecciona `gh-pages` como branch
   - Guarda los cambios

3. **Push al repositorio**
   ```bash
   git add .
   git commit -m "Add GitHub Actions deployment"
   git push origin main
   ```

### Método 2: Publicación Manual

1. **Publicar el proyecto**

   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Modificar base href en `index.html`**

   ```html
   <base href="/nombre-repositorio/" />
   ```

3. **Agregar archivo `.nojekyll`**

   ```bash
   touch ./publish/wwwroot/.nojekyll
   ```

4. **Subir a branch `gh-pages`**
   ```bash
   git subtree push --prefix publish/wwwroot origin gh-pages
   ```

## Estructura del Proyecto

```
PortfolioNaiquen/
├── Pages/
│   ├── Home.razor
│   ├── Games.razor
│   ├── Software.razor
│   ├── Design.razor
│   └── Databases.razor
├── Shared/
│   ├── Components/
│   │   ├── MagicButton.razor
│   │   └── ProjectCard.razor
│   └── MainLayout.razor
├── wwwroot/
│   ├── css/
│   │   └── app.css
│   └── index.html
├── App.razor
├── Program.cs
└── _Imports.razor
```

## Próximos Pasos

- [ ] Agregar imágenes reales de los proyectos
- [ ] Implementar modo claro/oscuro
- [ ] Agregar página de contacto con formulario
- [ ] Integrar analytics (Google Analytics / Plausible)
- [ ] Agregar animaciones de scroll con Intersection Observer
- [ ] Implementar blog técnico
- [ ] Optimizar SEO con meta tags personalizados
- [ ] Agregar sitemap.xml
- [ ] Implementar Progressive Web App (PWA)
- [ ] Agregar tests unitarios con bUnit

## Licencia

Este proyecto es de uso personal. Si deseas usar el código como base para tu propio portfolio, siéntete libre de hacerlo con atribución.

## Contacto

**Naiquen Iturralde**

- GitHub: [@NaiquenIturralde](https://github.com/NaiquenIturralde)
- LinkedIn: [Naiquen Iturralde](https://www.linkedin.com/in/naiquen-iturralde-5a4a4021a/)
- Email: iturraldenaiquen@gmail.com

---

Hecho con Blazor WebAssembly
