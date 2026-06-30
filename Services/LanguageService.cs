using Microsoft.JSInterop;

namespace PortfolioNaiquen.Services
{
    public class LanguageService
    {
        private readonly IJSRuntime _js;
        private bool _initialized;

        public string CurrentLanguage { get; private set; } = "es";
        public event Action? OnChange;

        private static readonly Dictionary<string, Dictionary<string, string>> Texts = new()
        {
            ["es"] = new()
            {
                // ── General / Shared ──
                ["siteTitle"] = "Naiquen - Portfolio",
                ["loading"] = "Cargando...",
                ["close"] = "Cerrar",
                ["back"] = "Volver",
                ["copySuccess"] = "Correo copiado ✓",

                // ── Nav ──
                ["navHome"] = "Inicio",
                ["navGames"] = "Games",
                ["navSoftware"] = "Software",
                ["navDesign"] = "Diseño",
                ["navDatabases"] = "Bases de Datos",
                ["navCertificados"] = "Certificados",
                ["navAbout"] = "Acerca de mí",
                ["menuOpen"] = "Cerrar menú",
                ["menuClosed"] = "Abrir menú",
                ["brandSubtitle"] = "Portfolio",
                ["toggleNav"] = "Toggle navigation",

                // ── Language Toggle ──
                ["langLabel"] = "Español / English",
                ["langSelectorAria"] = "Seleccionar idioma",
                ["langEsAria"] = "Español",
                ["langEnAria"] = "English",

                // ── Hero / Home ──
                ["pageTitle"] = "Naiquen - Portfolio",
                ["heroSubtitle"] = "Desarrolladora web en formación, enfocada en crear interfaces claras, funcionales y fáciles de usar.",

                ["heroDescription"] = "Soy desarrolladora web en formación, con interés en el diseño UX/UI y la creación de interfaces simples, claras y funcionales. Actualmente desarrollo proyectos propios para aplicar lo aprendido, mejorar mi criterio técnico y seguir creciendo profesionalmente. Mi objetivo es conseguir mi primera experiencia laboral en tecnología, sumar experiencia real y continuar perfeccionándome en equipo.",

                ["viewProjects"] = "Ver Proyectos",
                ["contact"] = "Contactar",

                // ── Stats ──
                ["stat1Title"] = "Formación avanzada",
                ["stat1Label"] = "3er año de la Tecnicatura en desarrollo de software- ITES",
                ["stat2Title"] = "Game Dev en desarrollo",
                ["stat2Label"] = "Juegos propios en construcción",
                ["stat3Title"] = "UX & Figma colaborativo",
                ["stat3Label"] = "Diseños modernos + trabajo en equipo",
                ["stat4Title"] = "Prototipos 3D y creatividad",
                ["stat4Label"] = "Ideas, arte y modelos propios",

                // ── Home · Quick Access ──
                ["homeQuickTitle"] = "Explorar portfolio",
                ["homeQuickSubtitle"] = "Accesos rápidos a las principales áreas de trabajo.",
                ["homeQuickSoftwareTitle"] = "Software",
                ["homeQuickSoftwareDesc"] = "Proyectos web y aplicaciones desarrolladas con enfoque funcional y técnico.",
                ["homeQuickGamesTitle"] = "Videojuegos",
                ["homeQuickGamesDesc"] = "Proyectos interactivos, prototipos y experiencias desarrolladas en videojuegos.",
                ["homeQuickDatabasesTitle"] = "Bases de datos",
                ["homeQuickDatabasesDesc"] = "Modelado, diagramas DER y documentación de bases de datos relacionales.",
                ["homeQuickCertificatesTitle"] = "Certificados",
                ["homeQuickCertificatesDesc"] = "Formación complementaria, cursos y certificaciones obtenidas.",
                ["homeQuickButton"] = "Ver sección",

                // ── Featured Project (CryptoView) ──
                ["featuredSectionTitle"] = "Proyecto",
                ["featuredHighlight"] = "Destacado",
                ["featuredSectionDesc"] = "Sistema real desarrollado con foco en experiencia de usuario y arquitectura completa",
                ["featuredBadge"] = "Software Development",
                ["featuredProjectDesc"] = "Sistema web desarrollado en Blazor Server .NET 8 para seguimiento de criptomonedas, gestión de usuarios, notas personales, estadísticas, gráficos y preferencias personalizadas. Diseñado con foco en experiencia de usuario, visualización clara de datos y arquitectura completa.",
                ["featuredFeature1"] = "Dashboard principal con información de mercado en tiempo real.",
                ["featuredFeature2"] = "Gestión de criptomonedas con opciones para editar, eliminar y crear notas.",
                ["featuredFeature3"] = "Estadísticas y gráficos para analizar precios, volumen y variaciones.",
                ["featuredFeature4"] = "Sistema de usuarios, roles, login, perfil editable y preferencias.",
                ["featuredFeature5"] = "Interfaz responsive con modo claro/oscuro y foco en UX.",
                ["viewDemo"] = "Ver demo",
                ["viewCode"] = "Ver código",

                // ── About Extended (collapsible) ──
                ["aboutButton"] = "Perfil extendido",
                ["aboutExtendedP1"] = "Soy estudiante avanzada de la Tecnicatura Superior en Desarrollo de Software en el ITES, y estoy construyendo mi camino dentro del diseño UX y el desarrollo de software a través de proyectos reales, investigación constante, prototipos y experiencias digitales. Mi enfoque está en aprender de manera continua, mejorar mis habilidades y aplicar mis conocimientos en contextos prácticos, creativos y centrados en las personas.",
                ["aboutExtendedP2"] = "Soy una persona muy comunicativa, social y abierta. Me encanta conversar con personas nuevas, generar conexiones genuinas y crear un ambiente positivo en cualquier lugar donde voy. Mis habilidades sociales me permiten trabajar en equipo con naturalidad, escuchar activamente, comprender diferentes puntos de vista y comunicar ideas de manera clara, empática y accesible.",
                ["aboutExtendedP3"] = "También poseo un liderazgo natural. Cuando un grupo necesita dirección o claridad, me nace tomar la iniciativa: organizar, guiar, motivar y acompañar a los demás para avanzar. Me siento cómoda coordinando, proponiendo soluciones y ayudando a que el equipo encuentre rumbo incluso en momentos de incertidumbre.",
                ["aboutExtendedP4"] = "Estoy abierta a participar en proyectos, colaborar con equipos, asumir desafíos y trabajar en propuestas donde pueda aportar diseño accesible, pensamiento crítico, comunicación efectiva y soluciones intuitivas. Mi objetivo es crecer profesionalmente, adquirir experiencia real y conectar con oportunidades que impulsen tanto mi aprendizaje como mis capacidades creativas.",
                ["aboutExtendedP5"] = "Además de mis estudios tecnológicos, cursé 13 materias de Abogacía en la UNLPam, una formación que me brindó habilidades complementarias que potencian mi desempeño en tecnología:",
                ["aboutExtendedLaw1"] = "Redacción e interpretación de textos jurídicos",
                ["aboutExtendedLaw2"] = "Análisis preciso y pensamiento estructurado",
                ["aboutExtendedLaw3"] = "Capacidad dialéctica y construcción de discursos convincentes",
                ["aboutExtendedLaw4"] = "Comunicación clara, inclusiva y accesible de ideas complejas",
                ["aboutExtendedP6"] = "Esta combinación de tecnología + diseño + formación jurídica me permite presentar proyectos con solidez, fundamentar decisiones y crear documentación profesional comprensible para cualquier persona.",
                ["aboutExtendedInterestsTitle"] = "Mis intereses y pasiones",
                ["aboutExtendedInterestsP1"] = "Fuera del desarrollo y el diseño, soy una persona muy activa, creativa y curiosa. Me apasionan las artes marciales —especialmente el kickboxing y el jiu-jitsu— porque me ayudan a mantener disciplina, foco mental y una conexión fuerte con mi cuerpo. También disfruto del running y de subir montañas: la combinación de esfuerzo físico, naturaleza y desafío personal me da una sensación única de claridad y libertad.",
                ["aboutExtendedInterestsP2"] = "La pintura y el canto son otras formas importantes de expresión en mi vida. Estas actividades alimentan mi sensibilidad artística, mi creatividad y mi capacidad para observar los detalles desde otra perspectiva. Todo esto influye directamente en cómo diseño, cómo creo experiencias y cómo pienso soluciones digitales más humanas y sensibles.",

                // ── About Page ──
                ["aboutTitle"] = "Acerca de mí",
                ["aboutP1"] = "Soy Naiquen Anael Iturralde, estudiante avanzada de la Tecnicatura Superior en Desarrollo de Software en el ITES. Estoy construyendo mi camino dentro del diseño UX y el desarrollo de software a través de proyectos reales, investigación constante, prototipos y experiencias digitales. Mi enfoque está en aprender de manera continua, mejorar mis habilidades y aplicar mis conocimientos en contextos prácticos, creativos y centrados en las personas.",
                ["aboutP2"] = "Soy una persona muy comunicativa, social y abierta. Me encanta conversar con personas nuevas, generar conexiones genuinas y crear un ambiente positivo donde sea que vaya. Tengo habilidades sociales naturales que me permiten trabajar en equipo con fluidez, escuchar activamente, comprender diferentes perspectivas y comunicar ideas con claridad, empatía y accesibilidad.",
                ["aboutP3"] = "También poseo un liderazgo natural. Cuando un equipo necesita dirección o claridad, me nace tomar la iniciativa: organizar, guiar, motivar y acompañar a los demás para avanzar con seguridad. Me siento cómoda coordinando, proponiendo soluciones y ayudando a que un grupo encuentre rumbo incluso en momentos de incertidumbre.",
                ["aboutP4"] = "Además de mis estudios tecnológicos, cursé 13 materias de Abogacía en la UNLPam. Esta formación me brindó habilidades complementarias como la redacción e interpretación de textos jurídicos, el análisis estructurado, la dialéctica y la comunicación clara de ideas complejas. Esta mezcla de tecnología + diseño + formación jurídica me permite fundamentar decisiones, presentar proyectos con solidez y crear documentación profesional accesible para cualquier persona.",
                ["aboutP5"] = "Fuera del desarrollo y el diseño, soy una persona muy activa y creativa. Practico kickboxing y jiu-jitsu, disciplinas que me ayudan a liberar el estrés, mantener el foco mental y fortalecer mi conexión física y emocional. También disfruto del running y de subir montañas, actividades que me dan una sensación única de claridad y libertad. Me apasionan la pintura y el canto, que alimentan mi sensibilidad artística y mi forma de observar el mundo desde una perspectiva más humana.",

                // ── Games Page ──
                ["gamesPageTitle"] = "Desarrollo de Juegos",
                ["gamesPageIntro"] = "Exploro la narrativa interactiva y el diseño de mecánicas únicas para crear experiencias memorables. Desde aventuras ambientales hasta juegos cooperativos, cada proyecto busca conectar emocionalmente con el jugador. A futuro deseo crear juegos inclusivos, pensados para que todas las personas puedan disfrutar, jugar y hacer nuevos amigos.",
                ["oceánidaMeta"] = "Desarrollado junto a Mateo Lemes.",
                ["oceánidaDesc"] = "Juego educativo de exploración submarina inspirado en los avistamientos del CONICET en Mar del Plata. Los jugadores descubren los misterios del océano mientras toman decisiones que impactan en el ecosistema marino y su historia personal.",
                ["bosqueEncantadoMeta"] = "Colaboración con alumnas MetJam.",
                ["bosqueEncantadoDesc"] = "Aventura narrativa protagonizada por una gatita curiosa que explora un bosque mágico. Cada decisión del jugador afecta las relaciones con los habitantes del bosque y desbloquea diferentes finales.",
                ["pacTeamMeta"] = "Proyecto futuro — 3D Mobile.",
                ["pacTeamDesc"] = "Juego cooperativo donde los jugadores deben trabajar en equipo para avanzar por laberintos llenos de desafíos. La comunicación y coordinación son esenciales para superar obstáculos y alcanzar la meta juntos.",
                ["figmaInProcess"] = "Figma en proceso",

                // ── Software Page ──
                ["softwarePageTitle"] = "Software Development",
                ["softwarePageSubtitle"] = "Aplicaciones robustas · Full-stack · Arquitecturas escalables",
                ["softwarePageIntro"] = "Estoy en proceso de formación como desarrolladora full-stack, enfocándome en crear aplicaciones intuitivas y centradas en el usuario. Me interesa especialmente el desarrollo de soluciones accesibles, y sigo aprendiendo para acercar mis experiencias digitales a la mayor cantidad de personas posible.",
                ["love2readMetaLabel"] = "Sistema de biblioteca virtual completo",
                ["love2readProblemLabel"] = "Problema que resuelve",
                ["love2readProblemText"] = "Digitaliza la gestión integral de bibliotecas: préstamos, devoluciones, control de inventario y administración de usuarios en un único sistema centralizado.",
                ["love2readFeaturesLabel"] = "Características principales",
                ["love2readFeature1"] = "Gestión de libros",
                ["love2readFeature2"] = "Sistema de préstamos",
                ["love2readFeature3"] = "Roles diferenciados (Admin, Bibliotecario, Usuario)",
                ["love2readFeature4"] = "Dashboard con métricas",
                ["love2readFeature5"] = "Sistema de multas y pagos",
                ["love2readArchLabel"] = "Arquitectura",
                ["cryptoviewMetaLabel"] = "Dashboard de criptomonedas en tiempo real",
                ["cryptoviewDesc"] = "Aplicación full-stack para visualización y análisis de criptomonedas. Integración con APIs externas, CRUD completo y dashboard interactivo para monitoreo de mercados.",
                ["cryptoviewProblemLabel"] = "Problema que resuelve",
                ["cryptoviewProblemText"] = "Centraliza el seguimiento de criptomonedas, permitiendo visualizar precios, métricas de mercado, notas personales y preferencias de usuario desde un dashboard interactivo.",
                ["cryptoviewFeaturesLabel"] = "Características principales",
                ["cryptoviewFeature1"] = "Dashboard con métricas principales",
                ["cryptoviewFeature2"] = "Visualización de criptomonedas en tiempo real",
                ["cryptoviewFeature3"] = "Gestión de notas personales por moneda",
                ["cryptoviewFeature4"] = "Perfil de usuario editable",
                ["cryptoviewFeature5"] = "Preferencias de moneda y actualización",
                ["cryptoviewFeature6"] = "Integración con API externa",
                ["cryptoviewArchLabel"] = "Arquitectura",
                ["verDemo"] = "Ver Demo",
                ["verCodigo"] = "Ver Código",
                ["verCasosDeUso"] = "Casos de uso",
                ["verDER"] = "Diagrama DER",

                // ── Cross Navigation Footer ──
                ["crossNavTitle"] = "Explora mis otras especialidades",
                ["crossNavSubtitle"] = "Descubre el resto de mi trabajo y encuentra lo que mejor se conecta con tu interés.",
                ["crossNavGamesDesc"] = "Narrativas interactivas, mecánicas únicas y experiencias pensadas para conectar con cada jugador.",
                ["crossNavSoftwareDesc"] = "Aplicaciones full-stack, APIs y arquitecturas escalables con foco en experiencia de usuario.",
                ["crossNavDatabasesDesc"] = "Modelado relacional, normalización, triggers y stored procedures con foco en integridad y rendimiento.",

                // ── Design Page ──
                ["designPageTitle"] = "UI/UX Design",
                ["designPageIntro"] = "Creo experiencias visuales que comunican, inspiran y conectan. Mi trabajo abarca desde diseño de interfaces digitales hasta composiciones gráficas para medios impresos, siempre buscando el equilibrio perfecto entre estética y funcionalidad.",
                ["designGalleryTitle"] = "Galería de Diseños",
                ["designFlyer1"] = "Branding Digital",
                ["designFlyer2"] = "Event Poster",
                ["designFlyer3"] = "Social Media",
                ["designFlyer4"] = "UI Mockup",
                ["designFlyer5"] = "Logo Design",
                ["designFlyer6"] = "Print Design",
                ["designCtaTitle"] = "¿Interesado en arquitectura de datos?",
                ["designCtaText"] = "Explora mis soluciones de bases de datos y diseño de esquemas",
                ["designCtaButton"] = "Ver Databases",

                // ── Databases Page ──
                ["databasesPageTitle"] = "Database Lab",
                ["databasesPageSubtitle"] = "Modelado de datos y análisis funcional de sistemas demo.",
                ["databasesPageIntro"] = "En esta sección presento diagramas DER y casos de uso de proyectos desarrollados, mostrando cómo se estructuran sus entidades, relaciones, actores y procesos principales.",
                ["databasesSkillsTitle"] = "Habilidades aplicadas",
                // Card 1 — Love2Read
                ["dbL2RTitle"] = "Love2Read",
                ["dbL2RMeta"] = "Sistema de gestión bibliotecaria",
                ["dbL2RDesc"] = "Documentación técnica de una base de datos relacional orientada a usuarios, libros, préstamos, reservas, multas, pagos, comprobantes y suscripciones digitales.",
                ["dbL2RFeaturesLabel"] = "Características principales",
                ["dbL2RFeature1"] = "Modelo relacional en SQL Server",
                ["dbL2RFeature2"] = "Diagramas DER por módulo",
                ["dbL2RFeature3"] = "Casos de uso por actor",
                ["dbL2RFeature4"] = "Gestión de préstamos, reservas y pagos",
                ["dbL2RFeature5"] = "Módulo digital y administración",
                ["dbL2RToolsLabel"] = "Herramientas",
                ["dbL2RTool1"] = "SQL Server",
                ["dbL2RTool2"] = "SSMS",
                ["dbL2RTool3"] = "DER",
                ["dbL2RTool4"] = "Casos de uso",
                ["dbL2RTool5"] = "Modelo relacional",
                ["dbL2RDerButton"] = "Ver DER",
                ["dbL2RUcButton"] = "Ver casos de uso",
                // Card 2 — CryptoView
                ["dbCVTitle"] = "CryptoView",
                ["dbCVMeta"] = "Sistema de seguimiento de criptomonedas",
                ["dbCVDesc"] = "Documentación técnica de una base de datos aplicada a una app de criptomonedas, con foco en usuarios, perfiles, activos digitales, notas, preferencias y organización funcional del sistema.",
                ["dbCVFeaturesLabel"] = "Características principales",
                ["dbCVFeature1"] = "Modelo relacional aplicado a una app .NET",
                ["dbCVFeature2"] = "Persistencia de usuarios y datos funcionales",
                ["dbCVFeature3"] = "Diagramas DER",
                ["dbCVFeature4"] = "Casos de uso por actor",
                ["dbCVFeature5"] = "Organización de módulos principales",
                ["dbCVToolsLabel"] = "Herramientas",
                ["dbCVTool1"] = "SQL Server",
                ["dbCVTool2"] = ".NET",
                ["dbCVTool3"] = "DER",
                ["dbCVTool4"] = "Casos de uso",
                ["dbCVTool5"] = "Modelo relacional",
                ["dbCVDerButton"] = "Ver DER",
                ["dbCVUcButton"] = "Ver casos de uso",
                ["databasesNote"] = "Todos los scripts SQL, diagramas ER y documentación técnica de estos proyectos están disponibles en mi repositorio de GitHub. Incluyen DDL completo, stored procedures, triggers y casos de prueba.",
                ["databasesCtaTitle"] = "¿Quieres conocer más sobre mi trabajo?",
                ["databasesCtaText"] = "Explora todos mis proyectos y habilidades",
                ["databasesCtaButton"] = "Volver al Inicio",

                // ── Certificados Page ──
                ["certificadosPageTitle"] = "Certificados",
                ["certificadosPageSubtitle"] = "Formación complementaria y certificaciones obtenidas",
                ["certificadosPageIntro"] = "Aquí encontrarás los certificados y reportes de cursos que complementan mi formación principal en desarrollo de software y diseño UX/UI.",
                ["certVerCertificado"] = "Ver certificado",
                ["certCard1Meta"] = "Diseño",
                ["certCard1Title"] = "Diseño Gráfico con Canva",
                ["certCard1Desc"] = "Certificación en diseño gráfico, composición visual, jerarquía tipográfica y creación de piezas para medios digitales e impresos.",
                ["certCard2Meta"] = "UX/UI",
                ["certCard2Title"] = "UX/UI con Figma",
                ["certCard2Desc"] = "Formación en diseño de interfaces, prototipado interactivo, sistemas de diseño y trabajo colaborativo en Figma.",
                ["certCard3Meta"] = "Backend",
                ["certCard3Title"] = "ASP.NET Core MVC y C#",
                ["certCard3Desc"] = "Curso de ASP.NET Core MVC y C# cubriendo el ciclo completo de desarrollo backend y full-stack con .NET.",
                ["certCard4Meta"] = "Herramientas",
                ["certCard4Title"] = "Excel Profesional",
                ["certCard4Desc"] = "Certificación en Excel profesional: fórmulas avanzadas, tablas dinámicas, análisis de datos y automatización.",
                ["certCard5Meta"] = "Reporte",
                ["certCard5Title"] = "Reporte Edutin Academy",
                ["certCard5Desc"] = "Reporte de avance y finalización de cursos en Edutin Academy como parte de la formación continua.",
                ["certificadosCtaText"] = "Volver al inicio y recorrer todas mis secciones",
                ["crossNavCertificadosDesc"] = "Certificaciones, cursos y formación complementaria en diseño, herramientas y desarrollo.",

                // ── Contact Modal ──
                ["contactTitle"] = "Contacto",
                ["contactPhoneLabel"] = "Llamar al +54 9 2954 400270",
                ["contactLocationLabel"] = "Ver Santa Rosa, La Pampa en Google Maps",
                ["contactEmailLabel"] = "Enviar correo a iturraldenaiquen@gmail.com",
                ["contactInstagramLabel"] = "Abrir perfil de Instagram @Naiiiquiii",

                // ── Footer ──
                ["footerText"] = "© 2026 Naiquen Iturralde. Creado con dedicación, accesibilidad e innovación.",

                // ── Error UI ──
                ["errorText"] = "Un error inesperado ha ocurrido.",
                ["errorReload"] = "Recargar",
                ["errorBoundary"] = "Ha ocurrido un error.",
            },
            ["en"] = new()
            {
                // ── General / Shared ──
                ["siteTitle"] = "Naiquen - Portfolio",
                ["loading"] = "Loading...",
                ["close"] = "Close",
                ["back"] = "Back",
                ["copySuccess"] = "Email copied ✓",

                // ── Nav ──
                ["navHome"] = "Home",
                ["navGames"] = "Games",
                ["navSoftware"] = "Software",
                ["navDesign"] = "Design",
                ["navDatabases"] = "Databases",
                ["navCertificados"] = "Certificates",
                ["navAbout"] = "About Me",
                ["menuOpen"] = "Close menu",
                ["menuClosed"] = "Open menu",
                ["brandSubtitle"] = "Portfolio",
                ["toggleNav"] = "Toggle navigation",

                // ── Language Toggle ──
                ["langLabel"] = "Spanish / English",
                ["langSelectorAria"] = "Select language",
                ["langEsAria"] = "Spanish",
                ["langEnAria"] = "English",

                // ── Hero / Home ──
                ["pageTitle"] = "Naiquen - Portfolio",
                ["heroSubtitle"] = "Web developer in training, focused on creating clear, functional and easy-to-use interfaces.",
                ["heroDescription"] = "I am a web developer in training, interested in UX/UI design and in creating simple, clear and functional interfaces. I currently build personal projects to apply what I have learned, improve my technical judgment and continue growing professionally. My goal is to gain my first work experience in tech, build real-world experience and keep improving as part of a team.",
                ["viewProjects"] = "View Projects",
                ["contact"] = "Contact",

                // ── Stats ──
                ["stat1Title"] = "Advanced Training",
                ["stat1Label"] = "3rd year of the Software Development Technician program — ITES",
                ["stat2Title"] = "Game Dev in Progress",
                ["stat2Label"] = "Building my own games",
                ["stat3Title"] = "UX & Collaborative Figma",
                ["stat3Label"] = "Modern designs + teamwork",
                ["stat4Title"] = "3D Prototypes & Creativity",
                ["stat4Label"] = "Ideas, art, and custom models",

                // ── Home · Quick Access ──
                ["homeQuickTitle"] = "Explore portfolio",
                ["homeQuickSubtitle"] = "Quick access to the main work areas.",
                ["homeQuickSoftwareTitle"] = "Software",
                ["homeQuickSoftwareDesc"] = "Web projects and applications built with a functional and technical approach.",
                ["homeQuickGamesTitle"] = "Games",
                ["homeQuickGamesDesc"] = "Interactive projects, prototypes and game development experiences.",
                ["homeQuickDatabasesTitle"] = "Databases",
                ["homeQuickDatabasesDesc"] = "Modeling, ER diagrams and documentation for relational databases.",
                ["homeQuickCertificatesTitle"] = "Certificates",
                ["homeQuickCertificatesDesc"] = "Additional training, courses and earned certifications.",
                ["homeQuickButton"] = "View section",

                // ── Featured Project (CryptoView) ──
                ["featuredSectionTitle"] = "Featured",
                ["featuredHighlight"] = "Project",
                ["featuredSectionDesc"] = "Real system developed with focus on user experience and complete architecture",
                ["featuredBadge"] = "Software Development",
                ["featuredProjectDesc"] = "Web system built with Blazor Server .NET 8 for cryptocurrency tracking, user management, personal notes, statistics, charts and custom preferences. Designed with a strong focus on user experience, clear data visualization and complete architecture.",
                ["featuredFeature1"] = "Main dashboard with real-time market information.",
                ["featuredFeature2"] = "Cryptocurrency management with edit, delete and note creation features.",
                ["featuredFeature3"] = "Statistics and charts to analyze prices, volume and market changes.",
                ["featuredFeature4"] = "User system with roles, login, editable profile and preferences.",
                ["featuredFeature5"] = "Responsive interface with light/dark mode and UX focus.",
                ["viewDemo"] = "Watch demo",
                ["viewCode"] = "View code",

                // ── About Extended (collapsible) ──
                ["aboutButton"] = "Extended Profile",
                ["aboutExtendedP1"] = "I am an advanced student in the Higher Technician Program in Software Development at ITES, and I am building my path in UX design and software development through real projects, continuous research, prototypes, and digital experiences. My focus is on learning constantly, improving my skills, and applying my knowledge in practical, creative, and human-centered contexts.",
                ["aboutExtendedP2"] = "I am a very communicative, social, and open person. I love talking with new people, creating genuine connections, and bringing a positive atmosphere wherever I go. My social abilities allow me to collaborate naturally, listen actively, understand different perspectives, and communicate ideas in a clear, empathetic, and accessible way.",
                ["aboutExtendedP3"] = "I also have a natural leadership style. When a group needs direction or clarity, I tend to step forward: organizing, guiding, motivating, and supporting others so we can move ahead together. I feel comfortable coordinating, proposing solutions, and helping the team maintain direction even in moments of uncertainty.",
                ["aboutExtendedP4"] = "I am open to participating in projects, collaborating with teams, and taking on challenges where I can learn and contribute. My goal is to keep growing professionally, gain real experience, and connect with opportunities that enhance both my learning and my creative abilities.",
                ["aboutExtendedP5"] = "In addition to my technological studies, I completed 13 Law subjects at UNLPam, a background that gave me complementary skills that strengthen my performance in technology:",
                ["aboutExtendedLaw1"] = "Legal writing and interpretation",
                ["aboutExtendedLaw2"] = "Precise analysis and structured thinking",
                ["aboutExtendedLaw3"] = "Dialectical reasoning and persuasive communication",
                ["aboutExtendedLaw4"] = "Clear, inclusive, and accessible communication of complex ideas",
                ["aboutExtendedP6"] = "This combination of technology, design and legal training helps me communicate ideas clearly, structure my work, and create documentation that is accessible to anyone.",
                ["aboutExtendedInterestsTitle"] = "My interests and passions",
                ["aboutExtendedInterestsP1"] = "Outside of development and design, I am an active, creative, and curious person. I am passionate about martial arts —especially kickboxing and jiu-jitsu— because they help me maintain discipline, mental focus, and a strong connection with my body. I also enjoy running and climbing mountains: the mix of physical effort, nature, and personal challenge gives me a unique sense of clarity and freedom.",
                ["aboutExtendedInterestsP2"] = "Painting and singing are also important forms of expression in my life. They nurture my artistic sensitivity, creativity, and my ability to observe details from different perspectives. All of this directly influences how I design, create experiences, and approach more human-centered digital solutions.",

                // ── About Page ──
                ["aboutTitle"] = "About Me",
                ["aboutP1"] = "I am Naiquen Anael Iturralde, an advanced student in the Higher Technician Program in Software Development at ITES. I am building my path in UX design and software development through real projects, constant research, prototypes, and digital experiences. My focus is on learning continuously, improving my skills, and applying my knowledge in practical, creative, and people-centered contexts.",
                ["aboutP2"] = "I am a very communicative, social, and open person. I love talking with new people, creating genuine connections, and bringing a positive atmosphere wherever I go. I have natural social skills that allow me to work in teams fluidly, listen actively, understand different perspectives, and communicate ideas with clarity, empathy, and accessibility.",
                ["aboutP3"] = "I also have a natural leadership style. When a team needs direction or clarity, I tend to step forward: organizing, guiding, motivating, and supporting others so we can move forward confidently. I feel comfortable coordinating, proposing solutions, and helping a group find direction even in moments of uncertainty.",
                ["aboutP4"] = "In addition to my technology studies, I completed 13 Law subjects at UNLPam. This background gave me complementary skills such as legal writing and interpretation, structured analysis, dialectics, and clear communication of complex ideas. This blend of technology, design and legal training helps me communicate ideas clearly, structure my work, and create documentation that is accessible to anyone.",
                ["aboutP5"] = "Outside of development and design, I am a very active and creative person. I practice kickboxing and jiu-jitsu, disciplines that help me release stress, maintain mental focus, and strengthen my physical and emotional connection. I also enjoy running and climbing mountains, activities that give me a unique sense of clarity and freedom. I am passionate about painting and singing, which fuel my artistic sensitivity and my way of seeing the world from a more human perspective.",

                // ── Games Page ──
                ["gamesPageTitle"] = "Game Development",
                ["gamesPageIntro"] = "I explore interactive storytelling and unique mechanics design to create memorable experiences. From environmental adventures to cooperative games, each project seeks to emotionally connect with the player. In the future, I want to create inclusive games, designed so that everyone can enjoy, play and make new friends.",
                ["oceánidaMeta"] = "Developed with Mateo Lemes.",
                ["oceánidaDesc"] = "Educational underwater exploration game inspired by CONICET sightings in Mar del Plata. Players discover ocean mysteries while making decisions that impact the marine ecosystem and their personal story.",
                ["bosqueEncantadoMeta"] = "Collaboration with MetJam students.",
                ["bosqueEncantadoDesc"] = "Narrative adventure starring a curious kitten exploring a magical forest. Each player decision affects relationships with forest inhabitants and unlocks different endings.",
                ["pacTeamMeta"] = "Future project — 3D Mobile.",
                ["pacTeamDesc"] = "Cooperative game where players must work as a team to advance through challenging mazes. Communication and coordination are essential to overcome obstacles and reach the goal together.",
                ["figmaInProcess"] = "Figma in progress",

                // ── Software Page ──
                ["softwarePageTitle"] = "Software Development",
                ["softwarePageSubtitle"] = "Robust applications · Full-stack · Scalable architectures",
                ["softwarePageIntro"] = "I am training as a full-stack developer, focusing on creating intuitive, user-centered applications. I am especially interested in building accessible solutions, and I keep learning so my digital experiences can reach as many people as possible.",
                ["love2readMetaLabel"] = "Complete virtual library system",
                ["love2readProblemLabel"] = "Problem it solves",
                ["love2readProblemText"] = "Digitizes comprehensive library management: loans, returns, inventory control, and user administration in a single centralized system.",
                ["love2readFeaturesLabel"] = "Key features",
                ["love2readFeature1"] = "Book management",
                ["love2readFeature2"] = "Loan system",
                ["love2readFeature3"] = "Differentiated roles (Admin, Librarian, User)",
                ["love2readFeature4"] = "Dashboard with metrics",
                ["love2readFeature5"] = "Fine and payment system",
                ["love2readArchLabel"] = "Architecture",
                ["cryptoviewMetaLabel"] = "Real-time cryptocurrency dashboard",
                ["cryptoviewDesc"] = "Full-stack application for cryptocurrency visualization and analysis. Integration with external APIs, complete CRUD, and interactive dashboard for market monitoring.",
                ["cryptoviewProblemLabel"] = "Problem it solves",
                ["cryptoviewProblemText"] = "Centralizes cryptocurrency tracking, allowing users to view prices, market metrics, personal notes, and user preferences from an interactive dashboard.",
                ["cryptoviewFeaturesLabel"] = "Key features",
                ["cryptoviewFeature1"] = "Dashboard with main metrics",
                ["cryptoviewFeature2"] = "Real-time cryptocurrency visualization",
                ["cryptoviewFeature3"] = "Personal note management per coin",
                ["cryptoviewFeature4"] = "Editable user profile",
                ["cryptoviewFeature5"] = "Currency and refresh preferences",
                ["cryptoviewFeature6"] = "External API integration",
                ["cryptoviewArchLabel"] = "Architecture",
                ["verDemo"] = "View Demo",
                ["verCodigo"] = "View Code",
                ["verCasosDeUso"] = "Use cases",
                ["verDER"] = "ERD diagram",

                // ── Cross Navigation Footer ──
                ["crossNavTitle"] = "Explore my other specialties",
                ["crossNavSubtitle"] = "Discover the rest of my work and find what best connects with your interest.",
                ["crossNavGamesDesc"] = "Interactive storytelling, unique mechanics and experiences designed to connect with every player.",
                ["crossNavSoftwareDesc"] = "Full-stack applications, APIs and scalable architectures focused on user experience.",
                ["crossNavDatabasesDesc"] = "Relational modeling, normalization, triggers and stored procedures focused on integrity and performance.",

                // ── Design Page ──
                ["designPageTitle"] = "UI/UX Design",
                ["designPageIntro"] = "I create visual experiences that communicate, inspire, and connect. My work ranges from digital interface design to graphic compositions for print media, always seeking the perfect balance between aesthetics and functionality.",
                ["designGalleryTitle"] = "Design Gallery",
                ["designFlyer1"] = "Digital Branding",
                ["designFlyer2"] = "Event Poster",
                ["designFlyer3"] = "Social Media",
                ["designFlyer4"] = "UI Mockup",
                ["designFlyer5"] = "Logo Design",
                ["designFlyer6"] = "Print Design",
                ["designCtaTitle"] = "Interested in data architecture?",
                ["designCtaText"] = "Explore my database solutions and schema designs",
                ["designCtaButton"] = "View Databases",

                // ── Databases Page ──
                ["databasesPageTitle"] = "Database Lab",
                ["databasesPageSubtitle"] = "Data modeling and functional analysis of demo systems.",
                ["databasesPageIntro"] = "This section presents ER diagrams and use case diagrams from developed projects, showing how their entities, relationships, actors, and main processes are structured.",
                ["databasesSkillsTitle"] = "Applied skills",
                // Card 1 — Love2Read
                ["dbL2RTitle"] = "Love2Read",
                ["dbL2RMeta"] = "Library management system",
                ["dbL2RDesc"] = "Technical documentation for a relational database focused on users, books, loans, reservations, fines, payments, receipts, and digital subscriptions.",
                ["dbL2RFeaturesLabel"] = "Main features",
                ["dbL2RFeature1"] = "Relational model in SQL Server",
                ["dbL2RFeature2"] = "ER diagrams by module",
                ["dbL2RFeature3"] = "Use cases by actor",
                ["dbL2RFeature4"] = "Loan, reservation, and payment management",
                ["dbL2RFeature5"] = "Digital and administration modules",
                ["dbL2RToolsLabel"] = "Tools",
                ["dbL2RTool1"] = "SQL Server",
                ["dbL2RTool2"] = "SSMS",
                ["dbL2RTool3"] = "ERD",
                ["dbL2RTool4"] = "Use cases",
                ["dbL2RTool5"] = "Relational model",
                ["dbL2RDerButton"] = "View ERD",
                ["dbL2RUcButton"] = "View use cases",
                // Card 2 — CryptoView
                ["dbCVTitle"] = "CryptoView",
                ["dbCVMeta"] = "Cryptocurrency tracking system",
                ["dbCVDesc"] = "Technical documentation for a database applied to a cryptocurrency app, focused on users, profiles, digital assets, notes, preferences, and functional organization.",
                ["dbCVFeaturesLabel"] = "Main features",
                ["dbCVFeature1"] = "Relational model applied to a .NET app",
                ["dbCVFeature2"] = "User and functional data persistence",
                ["dbCVFeature3"] = "ER diagrams",
                ["dbCVFeature4"] = "Use cases by actor",
                ["dbCVFeature5"] = "Main module organization",
                ["dbCVToolsLabel"] = "Tools",
                ["dbCVTool1"] = "SQL Server",
                ["dbCVTool2"] = ".NET",
                ["dbCVTool3"] = "ERD",
                ["dbCVTool4"] = "Use cases",
                ["dbCVTool5"] = "Relational model",
                ["dbCVDerButton"] = "View ERD",
                ["dbCVUcButton"] = "View use cases",
                ["databasesNote"] = "All SQL scripts, ER diagrams and technical documentation for these projects are available in my GitHub repository. They include complete DDL, stored procedures, triggers and test cases.",
                ["databasesCtaTitle"] = "Want to know more about my work?",
                ["databasesCtaText"] = "Explore all my projects and skills",
                ["databasesCtaButton"] = "Back to Home",

                // ── Certificates Page ──
                ["certificadosPageTitle"] = "Certificates",
                ["certificadosPageSubtitle"] = "Complementary training and obtained certifications",
                ["certificadosPageIntro"] = "Here you will find the certificates and course reports that complement my main training in software development and UX/UI design.",
                ["certVerCertificado"] = "View certificate",
                ["certCard1Meta"] = "Design",
                ["certCard1Title"] = "Graphic Design with Canva",
                ["certCard1Desc"] = "Certification in graphic design, visual composition, typographic hierarchy and creating pieces for digital and print media.",
                ["certCard2Meta"] = "UX/UI",
                ["certCard2Title"] = "UX/UI with Figma",
                ["certCard2Desc"] = "Training in interface design, interactive prototyping, design systems, and collaborative work in Figma.",
                ["certCard3Meta"] = "Backend",
                ["certCard3Title"] = "ASP.NET Core MVC & C#",
                ["certCard3Desc"] = "Course on ASP.NET Core MVC and C# covering the complete backend and full-stack development cycle with .NET.",
                ["certCard4Meta"] = "Tools",
                ["certCard4Title"] = "Professional Excel",
                ["certCard4Desc"] = "Certification in professional Excel: advanced formulas, pivot tables, data analysis, and automation.",
                ["certCard5Meta"] = "Report",
                ["certCard5Title"] = "Edutin Academy Report",
                ["certCard5Desc"] = "Progress and completion report of courses on Edutin Academy as part of continuous learning.",
                ["certificadosCtaText"] = "Go back home and explore all my sections",
                ["crossNavCertificadosDesc"] = "Certifications, courses and complementary training in design, tools and development.",

                // ── Contact Modal ──
                ["contactTitle"] = "Contact",
                ["contactPhoneLabel"] = "Call +54 9 2954 400270",
                ["contactLocationLabel"] = "View Santa Rosa, La Pampa on Google Maps",
                ["contactEmailLabel"] = "Send email to iturraldenaiquen@gmail.com",
                ["contactInstagramLabel"] = "Open Instagram profile @Naiiiquiii",

                // ── Footer ──
                ["footerText"] = "© 2026 Naiquen Iturralde. Created with dedication, accessibility, and innovation.",

                // ── Error UI ──
                ["errorText"] = "An unexpected error has occurred.",
                ["errorReload"] = "Reload",
                ["errorBoundary"] = "An error has occurred.",
            }
        };

        public LanguageService(IJSRuntime js)
        {
            _js = js;
        }

        /// <summary>Look up a translated string by key.</summary>
        public string T(string key) =>
            Texts.TryGetValue(CurrentLanguage, out var dict) && dict.TryGetValue(key, out var val)
                ? val
                : $"[{key}]";

        /// <summary>Load persisted language from localStorage (call once in OnInitializedAsync).</summary>
        public async Task InitializeAsync()
        {
            if (_initialized) return;
            _initialized = true;
            try
            {
                var saved = await _js.InvokeAsync<string>("localStorage.getItem", "lang");
                if (saved is "es" or "en" && saved != CurrentLanguage)
                {
                    CurrentLanguage = saved;
                    NotifyStateChanged();
                }
            }
            catch { /* localStorage not available */ }
        }

        /// <summary>Switch language AND persist to localStorage.</summary>
        public async Task SetLanguageAsync(string lang)
        {
            if (lang != "es" && lang != "en") return;
            if (CurrentLanguage == lang) return;
            CurrentLanguage = lang;
            try { await _js.InvokeVoidAsync("localStorage.setItem", "lang", lang); } catch { }
            NotifyStateChanged();
        }

        /// <summary>Switch language synchronously (does NOT persist to localStorage).</summary>
        public void SetLanguage(string lang)
        {
            if (lang != "es" && lang != "en") return;
            if (CurrentLanguage == lang) return;
            CurrentLanguage = lang;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
