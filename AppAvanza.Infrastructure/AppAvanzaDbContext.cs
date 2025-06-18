using AppAvanza.Domain.Entities;
using AppAvanza.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppAvanza.Infrastructure
{
    public class AppAvanzaDbContext : DbContext
    {
        public AppAvanzaDbContext(DbContextOptions<AppAvanzaDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aprendiz> Aprendices { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<HitoDeDominio> HitosDeDominio { get; set; }
        public DbSet<ProgresoHito> ProgresosHitos { get; set; }
        public DbSet<ActividadSemanal> ActividadesSemanales { get; set; }
        public DbSet<RegistroDiario> RegistrosDiarios { get; set; }
        public DbSet<ElementoParkingFrustracion> ElementosParkingFrustracion { get; set; }
        public DbSet<Logro> Logros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Índices
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configuración de Relaciones
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Aprendices)
                .WithOne(a => a.Facilitador)
                .HasForeignKey(a => a.FacilitadorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nivel>()
                .HasMany(n => n.AprendicesEnEsteNivel)
                .WithOne(a => a.NivelActual)
                .HasForeignKey(a => a.NivelActualId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nivel>()
                .HasMany(n => n.HitosDeDominio)
                .WithOne(h => h.Nivel)
                .HasForeignKey(h => h.NivelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Nivel>()
                .HasMany(n => n.ActividadesSemanales)
                .WithOne(ac => ac.Nivel)
                .HasForeignKey(ac => ac.NivelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aprendiz>()
                .HasMany(a => a.ProgresosHitos)
                .WithOne(p => p.Aprendiz)
                .HasForeignKey(p => p.AprendizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HitoDeDominio>()
                .HasMany(h => h.ProgresosHitos)
                .WithOne(p => p.HitoDeDominio)
                .HasForeignKey(p => p.HitoDeDominioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aprendiz>()
                .HasMany(a => a.RegistrosDiarios)
                .WithOne(r => r.Aprendiz)
                .HasForeignKey(r => r.AprendizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aprendiz>()
                .HasMany(a => a.ElementosParking)
                .WithOne(e => e.Aprendiz)
                .HasForeignKey(e => e.AprendizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aprendiz>()
                .HasMany(a => a.Logros)
                .WithOne(l => l.Aprendiz)
                .HasForeignKey(l => l.AprendizId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de Propiedades de Entidad
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<Aprendiz>()
                .Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Nivel>()
                .Property(n => n.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Nivel>()
                .Property(n => n.ObjetivoCentral)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<HitoDeDominio>()
                .Property(h => h.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<ActividadSemanal>()
                .Property(ac => ac.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<ActividadSemanal>()
                .Property(ac => ac.DescripcionPractica)
                .HasMaxLength(1000);

            modelBuilder.Entity<ActividadSemanal>()
                .Property(ac => ac.LogroEsperado)
                .HasMaxLength(500);

            modelBuilder.Entity<RegistroDiario>()
                .Property(r => r.Observaciones)
                .HasMaxLength(2000);

            modelBuilder.Entity<ElementoParkingFrustracion>()
                .Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(1000);

            modelBuilder.Entity<Logro>()
                .Property(l => l.Descripcion)
                .IsRequired()
                .HasMaxLength(1000);

            // Configuración de Enums como string
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<HitoDeDominio>()
                .Property(h => h.Area)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<ActividadSemanal>()
                .Property(ac => ac.DiaSemana)
                .HasConversion<string>()
                .HasMaxLength(20);

            // --- SEED DATA ---

            // NIVELES
            modelBuilder.Entity<Nivel>().HasData(
                new Nivel { Id = 1, Nombre = "Nivel 1: Cimientos y Confianza", ObjetivoCentral = "Fomentar la seguridad en sí mismo y establecer las bases de la lectoescritura y el pensamiento matemático inicial." },
                new Nivel { Id = 2, Nombre = "Nivel 2: Descubrimiento y Expansión", ObjetivoCentral = "Ampliar el conocimiento del mundo, desarrollar la comprensión lectora y las habilidades matemáticas funcionales." },
                new Nivel { Id = 3, Nombre = "Nivel 3: Consolidación y Despegue", ObjetivoCentral = "Afianzar la autonomía en el aprendizaje, prepararse para retos académicos más complejos y fomentar el pensamiento crítico." }
            );

            int hitoIdCounter = 1;
            // HITOS DE DOMINIO - NIVEL 1
            modelBuilder.Entity<HitoDeDominio>().HasData(
                // Lectoescritura N1 (pág. 3)
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Reconoce al instante un banco de 40-50 palabras funcionales (globales)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Asocia el sonido con la grafía de las vocales y algunas consonantes clave (m, p, l, s, t, d, n, f, r suave)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Comienza a leer y escribir sílabas directas (consonante-vocal)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Lee y escribe palabras sencillas con sílabas directas." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Comprende frases cortas y sencillas apoyadas en imágenes." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Realiza trazos preparatorios para la escritura (líneas, círculos, bucles) con direccionalidad adecuada." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Lectoescritura, Descripcion = "Escribe su nombre con apoyo (modelo o reseguir)." },
                // Matemáticas N1 (pág. 3)
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Matematicas, Descripcion = "Cuenta hasta 20-30 y reconoce los números del 1 al 10 (cantidad y grafía)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Matematicas, Descripcion = "Asocia cantidad con número (hasta 10)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Matematicas, Descripcion = "Realiza seriaciones sencillas con dos o tres elementos." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Matematicas, Descripcion = "Clasifica objetos por un atributo (color, forma, tamaño)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Matematicas, Descripcion = "Comprende conceptos básicos espaciales (arriba/abajo, dentro/fuera, cerca/lejos) y temporales (antes/después, día/noche)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Matematicas, Descripcion = "Inicia la resolución de problemas sencillos de juntar o quitar (manipulativo, hasta 5)." },
                // Actitud y Autonomía N1 (pág. 3) - Combinados ya que el PDF los agrupa visualmente
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Actitud, Descripcion = "Muestra curiosidad y disposición para participar en las actividades." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Actitud, Descripcion = "Mantiene la atención en tareas cortas (5-10 minutos) con apoyo." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Actitud, Descripcion = "Tolera la frustración en pequeños retos con ayuda del adulto." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Autonomia, Descripcion = "Sigue instrucciones sencillas de dos o tres pasos." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Autonomia, Descripcion = "Es capaz de organizar su material de trabajo inmediato con supervisión." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 1, Area = AreaHito.Autonomia, Descripcion = "Pide ayuda cuando la necesita de forma adecuada." }
            );

            int actividadIdCounter = 1;
            // ACTIVIDADES SEMANALES - NIVEL 1 (pág. 4)
            modelBuilder.Entity<ActividadSemanal>().HasData(
                // Lunes N1
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Lunes, Titulo = "Taller de Palabras y Sonidos", DescripcionPractica = "Juegos con tarjetas de palabras (memory, emparejar imagen-palabra). Presentación de nuevas letras/sonidos con apoyo visual y gestual. Canciones de fonemas.", LogroEsperado = "Identificar nuevas palabras y asociar sonidos con letras presentadas." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Lunes, Titulo = "Mis Primeros Trazos", DescripcionPractica = "Ejercicios de grafomotricidad en pizarra, papel grande y fichas. Uso de diferentes materiales (tizas, ceras, rotuladores gruesos).", LogroEsperado = "Mejorar la coordinación viso-motora y la correcta direccionalidad del trazo." },
                // Martes N1
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Martes, Titulo = "Aventura Numérica", DescripcionPractica = "Contar objetos cotidianos (juguetes, lápices). Juegos de clasificación por color/forma/tamaño. Puzzles numéricos sencillos. Introducción a la recta numérica (hasta 10).", LogroEsperado = "Practicar el conteo y reconocer números en diferentes contextos." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Martes, Titulo = "Exploradores del Entorno", DescripcionPractica = "Observación de láminas o vídeos sobre temas de interés (animales, transportes). Conversación guiada. Dibujo libre sobre lo observado.", LogroEsperado = "Ampliar vocabulario y conocimiento del medio cercano." },
                // Miércoles N1
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Miercoles, Titulo = "Creamos con las Manos", DescripcionPractica = "Actividades de manualidades (rasgado, pegado, pintura de dedos, modelado con plastilina) relacionadas con la letra o tema de la semana.", LogroEsperado = "Desarrollar la motricidad fina y la creatividad." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Miercoles, Titulo = "Leemos Juntos", DescripcionPractica = "Lectura compartida de cuentos con pictogramas o imágenes muy claras. Preguntas sencillas sobre la historia.", LogroEsperado = "Fomentar el gusto por la lectura y la comprensión oral." },
                // Jueves N1
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Jueves, Titulo = "Juegos de Lógica y Percepción", DescripcionPractica = "Encontrar diferencias, seguir series de colores o formas, rompecabezas sencillos. Juegos de mesa adaptados (oca, parchís simplificado).", LogroEsperado = "Estimular el razonamiento lógico y la percepción visual." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Jueves, Titulo = "Escribo mi Nombre y Palabras", DescripcionPractica = "Práctica de la escritura del nombre. Copia de palabras sencillas trabajadas. Rellenar letras punteadas.", LogroEsperado = "Avanzar en la escritura del nombre y palabras significativas." },
                // Viernes N1
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Viernes, Titulo = "Celebramos lo Aprendido", DescripcionPractica = "Repaso lúdico de los conceptos de la semana (canciones, juegos interactivos en pizarra digital). Entrega y explicación de tareas para casa (fichas sencillas).", LogroEsperado = "Consolidar lo aprendido y establecer un puente con el hogar." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 1, DiaSemana = DiaSemana.Viernes, Titulo = "Rincón de Juego Simbólico", DescripcionPractica = "Juego libre en rincones temáticos (cocinita, médicos, construcciones) fomentando la interacción y el lenguaje espontáneo.", LogroEsperado = "Desarrollar habilidades sociales y de comunicación en un contexto lúdico." }
            );

            // HITOS DE DOMINIO - NIVEL 2
            modelBuilder.Entity<HitoDeDominio>().HasData(
                // Lectoescritura N2 (pág. 5)
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Lectoescritura, Descripcion = "Lee y escribe palabras con sílabas inversas (vocal-consonante) y mixtas (consonante-vocal-consonante)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Lectoescritura, Descripcion = "Lee y escribe frases sencillas con significado completo (sujeto-verbo-complemento)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Lectoescritura, Descripcion = "Comprende textos cortos (3-5 frases) y responde a preguntas literales sobre ellos." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Lectoescritura, Descripcion = "Utiliza mayúsculas al inicio de frase y en nombres propios de forma incipiente." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Lectoescritura, Descripcion = "Muestra interés por diferentes tipos de texto (cuentos, poesías, informativos adaptados)." },
                // Matemáticas N2 (pág. 5)
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Matematicas, Descripcion = "Cuenta hasta 100 y reconoce números hasta el 50-100 (cantidad y grafía)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Matematicas, Descripcion = "Realiza sumas y restas sencillas sin llevada (hasta el 20) de forma manipulativa y escrita." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Matematicas, Descripcion = "Comprende el concepto de decena y unidad." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Matematicas, Descripcion = "Resuelve problemas de suma y resta sencillos (enunciados cortos, con apoyo visual)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Matematicas, Descripcion = "Identifica figuras geométricas básicas (círculo, cuadrado, triángulo, rectángulo) y cuerpos sencillos (cubo, esfera)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Matematicas, Descripcion = "Maneja monedas de euro de bajo valor (1, 2, 5, 10, 20, 50 céntimos y 1, 2 euros) en contextos de juego." },
                // Actitud y Autonomía N2 (pág. 5)
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Actitud, Descripcion = "Muestra iniciativa en la elección de actividades y materiales." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Actitud, Descripcion = "Persiste en tareas de mayor duración (15-20 minutos) con menor supervisión." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Actitud, Descripcion = "Comienza a auto-corregir errores evidentes en sus trabajos." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Autonomia, Descripcion = "Planifica tareas sencillas con ayuda (qué hacer primero, qué después)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Autonomia, Descripcion = "Cuida sus materiales y es responsable de su espacio de trabajo." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 2, Area = AreaHito.Autonomia, Descripcion = "Colabora en tareas grupales sencillas y respeta turnos." }
            );

            // ACTIVIDADES SEMANALES - NIVEL 2 (pág. 6)
            modelBuilder.Entity<ActividadSemanal>().HasData(
                // Lunes N2
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Lunes, Titulo = "Detectives de Palabras", DescripcionPractica = "Búsqueda de palabras con sílabas inversas o mixtas en textos cortos. Formación de palabras con tarjetas de sílabas. Juegos de 'veo-veo' fonético.", LogroEsperado = "Afianzar la lectura y escritura de sílabas complejas." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Lunes, Titulo = "Creamos Historias", DescripcionPractica = "Escritura de frases sencillas a partir de una imagen o tema. Inicio de la escritura de pequeños textos (2-3 frases) con coherencia.", LogroEsperado = "Desarrollar la capacidad de expresar ideas por escrito." },
                // Martes N2
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Martes, Titulo = "Calculamos y Resolvemos", DescripcionPractica = "Ejercicios de suma y resta con apoyo manipulativo (ábaco, regletas) y en papel. Introducción a problemas con enunciado corto.", LogroEsperado = "Consolidar el cálculo básico y la resolución de problemas." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Martes, Titulo = "Viajeros del Conocimiento", DescripcionPractica = "Proyectos temáticos sencillos (el espacio, los inventos, el cuerpo humano). Búsqueda de información en libros adaptados o internet (guiada).", LogroEsperado = "Ampliar conocimientos sobre el mundo y fomentar la curiosidad." },
                // Miércoles N2
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Miercoles, Titulo = "Laboratorio de Ideas", DescripcionPractica = "Experimentos científicos sencillos y seguros. Actividades de construcción (Lego, material reciclado) siguiendo un plan.", LogroEsperado = "Fomentar el pensamiento científico y la creatividad aplicada." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Miercoles, Titulo = "Biblioteca Activa", DescripcionPractica = "Lectura individual silenciosa de libros adecuados a su nivel. Fichas de comprensión lectora sencillas (dibujar, responder V/F).", LogroEsperado = "Mejorar la fluidez y comprensión lectora autónoma." },
                // Jueves N2
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Jueves, Titulo = "Mente en Juego", DescripcionPractica = "Juegos de mesa que impliquen estrategia (damas, conecta 4). Sudokus infantiles. Problemas de lógica visual.", LogroEsperado = "Desarrollar el pensamiento estratégico y la resolución de problemas." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Jueves, Titulo = "Pequeños Escritores", DescripcionPractica = "Escritura de un diario personal (frases sencillas sobre su día). Invención de finales para cuentos conocidos. Uso incipiente de mayúsculas y punto.", LogroEsperado = "Practicar la escritura creativa y funcional." },
                // Viernes N2
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Viernes, Titulo = "Expo-Proyectos y Debate", DescripcionPractica = "Presentación de los trabajos o proyectos de la semana. Pequeños debates sobre temas de interés. Autoevaluación y coevaluación sencilla.", LogroEsperado = "Compartir aprendizajes, expresar opiniones y reflexionar sobre el propio progreso." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 2, DiaSemana = DiaSemana.Viernes, Titulo = "Desafíos en Equipo", DescripcionPractica = "Juegos cooperativos que requieran planificación y reparto de tareas. Resolución de acertijos en grupo.", LogroEsperado = "Fomentar el trabajo en equipo y la comunicación." }
            );

            // HITOS DE DOMINIO - NIVEL 3 (pág. 7)
            modelBuilder.Entity<HitoDeDominio>().HasData(
                // Lectoescritura N3
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Lectoescritura, Descripcion = "Lee con fluidez y entonación adecuada textos narrativos e informativos sencillos." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Lectoescritura, Descripcion = "Realiza inferencias sencillas y comprende el significado global de un texto." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Lectoescritura, Descripcion = "Escribe textos narrativos y expositivos cortos con una estructura básica (inicio, desarrollo, fin)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Lectoescritura, Descripcion = "Utiliza correctamente los signos de puntuación básicos (punto, coma, interrogación, exclamación)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Lectoescritura, Descripcion = "Planifica la escritura de un texto (lluvia de ideas, esquema sencillo) y lo revisa con ayuda." },
                // Matemáticas N3
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Matematicas, Descripcion = "Domina las operaciones de suma y resta con llevadas." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Matematicas, Descripcion = "Inicia el concepto de multiplicación y división (manipulativo y con apoyo gráfico)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Matematicas, Descripcion = "Resuelve problemas de dos operaciones combinadas (suma y resta)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Matematicas, Descripcion = "Utiliza unidades de medida convencionales (metro, litro, kilo) en contextos funcionales." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Matematicas, Descripcion = "Interpreta gráficos sencillos (barras, pictogramas)." },
                // Actitud y Autonomía N3 & Habilidades Sociales y Emocionales (pág. 7)
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Actitud, Descripcion = "Muestra una actitud proactiva y responsable hacia su aprendizaje." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Autonomia, Descripcion = "Trabaja de forma autónoma durante periodos más largos (25-30 minutos)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Autonomia, Descripcion = "Busca información de forma autónoma en fuentes variadas (diccionarios, internet con supervisión)." },
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Actitud, Descripcion = "Desarrolla estrategias para la resolución de conflictos de forma pacífica." }, // Podría ser AreaHito.HabilidadesSocialesEmocionales
                new HitoDeDominio { Id = hitoIdCounter++, NivelId = 3, Area = AreaHito.Actitud, Descripcion = "Expresa sus emociones de forma asertiva y comprende las de los demás." } // Podría ser AreaHito.HabilidadesSocialesEmocionales
            );

            // ACTIVIDADES SEMANALES - NIVEL 3 (pág. 7)
            modelBuilder.Entity<ActividadSemanal>().HasData(
                // Lunes N3
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Lunes, Titulo = "Club de Lectores Expertos", DescripcionPractica = "Lectura de novelas cortas o capítulos de libros. Tertulias literarias. Análisis de personajes y trama.", LogroEsperado = "Fomentar la lectura crítica y el gusto por la literatura." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Lunes, Titulo = "Taller de Escritura Creativa", DescripcionPractica = "Creación de cuentos, poesías, noticias. Uso de diferentes técnicas narrativas. Planificación y revisión de textos.", LogroEsperado = "Desarrollar la expresión escrita avanzada y la creatividad." },
                // Martes N3
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Martes, Titulo = "Desafíos Matemáticos", DescripcionPractica = "Resolución de problemas con varias operaciones. Introducción a la multiplicación y división con material manipulativo y juegos. Geometría aplicada.", LogroEsperado = "Afianzar el cálculo avanzado y la resolución de problemas complejos." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Martes, Titulo = "Pequeños Investigadores", DescripcionPractica = "Proyectos de investigación sobre temas de su interés. Búsqueda y selección de información. Elaboración de informes sencillos.", LogroEsperado = "Fomentar la autonomía en la búsqueda y gestión de información." },
                // Miércoles N3
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Miercoles, Titulo = "Debate y Pensamiento Crítico", DescripcionPractica = "Debates sobre temas actuales o dilemas morales adaptados. Análisis de noticias. Identificación de fake news (nivel básico).", LogroEsperado = "Desarrollar el pensamiento crítico y la argumentación." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Miercoles, Titulo = "STEAM en Acción", DescripcionPractica = "Proyectos que integren ciencia, tecnología, ingeniería, arte y matemáticas. Robótica educativa básica. Diseño de prototipos.", LogroEsperado = "Fomentar la creatividad, la innovación y el pensamiento computacional." },
                // Jueves N3
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Jueves, Titulo = "Ciudadanos del Mundo", DescripcionPractica = "Conocimiento de diferentes culturas. Proyectos sobre problemas sociales o medioambientales. Fomento de la empatía y la solidaridad.", LogroEsperado = "Desarrollar la conciencia social y ciudadana." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Jueves, Titulo = "Organizo mi Aprendizaje", DescripcionPractica = "Uso de agendas. Planificación del estudio personal. Técnicas de estudio básicas (subrayado, esquemas).", LogroEsperado = "Mejorar la organización y las estrategias de aprendizaje autónomo." },
                // Viernes N3
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Viernes, Titulo = "Presentación de Talentos", DescripcionPractica = "Exposición oral de los proyectos de investigación. Presentación de trabajos creativos. Portfolio de aprendizajes.", LogroEsperado = "Comunicar eficazmente los aprendizajes y valorar el propio progreso." },
                new ActividadSemanal { Id = actividadIdCounter++, NivelId = 3, DiaSemana = DiaSemana.Viernes, Titulo = "Mentoría y Colaboración", DescripcionPractica = "Actividades de tutoría entre iguales (los más avanzados ayudan a otros). Proyectos colaborativos complejos.", LogroEsperado = "Fomentar la colaboración, el liderazgo y la responsabilidad compartida." }
            );
        }
    }
}
