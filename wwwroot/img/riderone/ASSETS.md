# Rider One — Assets necesarios

La carpeta `img/riderone/` está lista para recibir los recursos del proyecto.
**No se han generado imágenes de placeholder** para no inventar contenido.

## Archivos que debés agregar vos

| Archivo              | Ruta esperada                             | Uso                                                                       |
| -------------------- | ----------------------------------------- | ------------------------------------------------------------------------- |
| `rider-one-logo.png` | `wwwroot/img/riderone/rider-one-logo.png` | Logo/imagen principal de Rider One. Se muestra en el HERO de `/riderone`. |
| `portada.jpg`        | `wwwroot/img/riderone/portada.jpg`        | Portada de la card de Rider One en la sección Diseño.                     |
| Imágenes 2024        | `wwwroot/img/riderone/2024/*.png`         | Fotos del prototipo 2024 (si se desean mostrar en la página interna).     |
| Imágenes 2025        | `wwwroot/img/riderone/2025/*.png`         | Fotos de la evolución 2025 (si se desean mostrar en la página interna).   |

## PDF

| Archivo               | Ruta esperada                      | Uso                                                                                            |
| --------------------- | ---------------------------------- | ---------------------------------------------------------------------------------------------- |
| `RiderOneInforme.pdf` | `wwwroot/docs/RiderOneInforme.pdf` | Informe/case study. Desde `/riderone` se muestra el botón **Ver informe** y **Descargar PDF**. |

## Videos de YouTube

No hay que copiar archivos. En `Pages/RiderOne.razor`, dentro de la lista `Videos`, se deben pegar los IDs de YouTube:

```csharp
new RiderVideo("VIDEO_ID", "Título", "Descripción")
```

Los videos se renderizan como iframe embebido 16:9 dentro del portfolio.
