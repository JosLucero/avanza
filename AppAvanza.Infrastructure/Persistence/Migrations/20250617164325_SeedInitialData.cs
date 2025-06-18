using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppAvanza.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Niveles",
                columns: new[] { "Id", "Nombre", "ObjetivoCentral" },
                values: new object[,]
                {
                    { 1, "Nivel 1: Cimientos y Confianza", "Fomentar la seguridad en sí mismo y establecer las bases de la lectoescritura y el pensamiento matemático inicial." },
                    { 2, "Nivel 2: Descubrimiento y Expansión", "Ampliar el conocimiento del mundo, desarrollar la comprensión lectora y las habilidades matemáticas funcionales." },
                    { 3, "Nivel 3: Consolidación y Despegue", "Afianzar la autonomía en el aprendizaje, prepararse para retos académicos más complejos y fomentar el pensamiento crítico." }
                });

            migrationBuilder.InsertData(
                table: "ActividadesSemanales",
                columns: new[] { "Id", "DescripcionPractica", "DiaSemana", "LogroEsperado", "NivelId", "Titulo" },
                values: new object[,]
                {
                    { 1, "Juegos con tarjetas de palabras (memory, emparejar imagen-palabra). Presentación de nuevas letras/sonidos con apoyo visual y gestual. Canciones de fonemas.", "Lunes", "Identificar nuevas palabras y asociar sonidos con letras presentadas.", 1, "Taller de Palabras y Sonidos" },
                    { 2, "Ejercicios de grafomotricidad en pizarra, papel grande y fichas. Uso de diferentes materiales (tizas, ceras, rotuladores gruesos).", "Lunes", "Mejorar la coordinación viso-motora y la correcta direccionalidad del trazo.", 1, "Mis Primeros Trazos" },
                    { 3, "Contar objetos cotidianos (juguetes, lápices). Juegos de clasificación por color/forma/tamaño. Puzzles numéricos sencillos. Introducción a la recta numérica (hasta 10).", "Martes", "Practicar el conteo y reconocer números en diferentes contextos.", 1, "Aventura Numérica" },
                    { 4, "Observación de láminas o vídeos sobre temas de interés (animales, transportes). Conversación guiada. Dibujo libre sobre lo observado.", "Martes", "Ampliar vocabulario y conocimiento del medio cercano.", 1, "Exploradores del Entorno" },
                    { 5, "Actividades de manualidades (rasgado, pegado, pintura de dedos, modelado con plastilina) relacionadas con la letra o tema de la semana.", "Miercoles", "Desarrollar la motricidad fina y la creatividad.", 1, "Creamos con las Manos" },
                    { 6, "Lectura compartida de cuentos con pictogramas o imágenes muy claras. Preguntas sencillas sobre la historia.", "Miercoles", "Fomentar el gusto por la lectura y la comprensión oral.", 1, "Leemos Juntos" },
                    { 7, "Encontrar diferencias, seguir series de colores o formas, rompecabezas sencillos. Juegos de mesa adaptados (oca, parchís simplificado).", "Jueves", "Estimular el razonamiento lógico y la percepción visual.", 1, "Juegos de Lógica y Percepción" },
                    { 8, "Práctica de la escritura del nombre. Copia de palabras sencillas trabajadas. Rellenar letras punteadas.", "Jueves", "Avanzar en la escritura del nombre y palabras significativas.", 1, "Escribo mi Nombre y Palabras" },
                    { 9, "Repaso lúdico de los conceptos de la semana (canciones, juegos interactivos en pizarra digital). Entrega y explicación de tareas para casa (fichas sencillas).", "Viernes", "Consolidar lo aprendido y establecer un puente con el hogar.", 1, "Celebramos lo Aprendido" },
                    { 10, "Juego libre en rincones temáticos (cocinita, médicos, construcciones) fomentando la interacción y el lenguaje espontáneo.", "Viernes", "Desarrollar habilidades sociales y de comunicación en un contexto lúdico.", 1, "Rincón de Juego Simbólico" },
                    { 11, "Búsqueda de palabras con sílabas inversas o mixtas en textos cortos. Formación de palabras con tarjetas de sílabas. Juegos de 'veo-veo' fonético.", "Lunes", "Afianzar la lectura y escritura de sílabas complejas.", 2, "Detectives de Palabras" },
                    { 12, "Escritura de frases sencillas a partir de una imagen o tema. Inicio de la escritura de pequeños textos (2-3 frases) con coherencia.", "Lunes", "Desarrollar la capacidad de expresar ideas por escrito.", 2, "Creamos Historias" },
                    { 13, "Ejercicios de suma y resta con apoyo manipulativo (ábaco, regletas) y en papel. Introducción a problemas con enunciado corto.", "Martes", "Consolidar el cálculo básico y la resolución de problemas.", 2, "Calculamos y Resolvemos" },
                    { 14, "Proyectos temáticos sencillos (el espacio, los inventos, el cuerpo humano). Búsqueda de información en libros adaptados o internet (guiada).", "Martes", "Ampliar conocimientos sobre el mundo y fomentar la curiosidad.", 2, "Viajeros del Conocimiento" },
                    { 15, "Experimentos científicos sencillos y seguros. Actividades de construcción (Lego, material reciclado) siguiendo un plan.", "Miercoles", "Fomentar el pensamiento científico y la creatividad aplicada.", 2, "Laboratorio de Ideas" },
                    { 16, "Lectura individual silenciosa de libros adecuados a su nivel. Fichas de comprensión lectora sencillas (dibujar, responder V/F).", "Miercoles", "Mejorar la fluidez y comprensión lectora autónoma.", 2, "Biblioteca Activa" },
                    { 17, "Juegos de mesa que impliquen estrategia (damas, conecta 4). Sudokus infantiles. Problemas de lógica visual.", "Jueves", "Desarrollar el pensamiento estratégico y la resolución de problemas.", 2, "Mente en Juego" },
                    { 18, "Escritura de un diario personal (frases sencillas sobre su día). Invención de finales para cuentos conocidos. Uso incipiente de mayúsculas y punto.", "Jueves", "Practicar la escritura creativa y funcional.", 2, "Pequeños Escritores" },
                    { 19, "Presentación de los trabajos o proyectos de la semana. Pequeños debates sobre temas de interés. Autoevaluación y coevaluación sencilla.", "Viernes", "Compartir aprendizajes, expresar opiniones y reflexionar sobre el propio progreso.", 2, "Expo-Proyectos y Debate" },
                    { 20, "Juegos cooperativos que requieran planificación y reparto de tareas. Resolución de acertijos en grupo.", "Viernes", "Fomentar el trabajo en equipo y la comunicación.", 2, "Desafíos en Equipo" },
                    { 21, "Lectura de novelas cortas o capítulos de libros. Tertulias literarias. Análisis de personajes y trama.", "Lunes", "Fomentar la lectura crítica y el gusto por la literatura.", 3, "Club de Lectores Expertos" },
                    { 22, "Creación de cuentos, poesías, noticias. Uso de diferentes técnicas narrativas. Planificación y revisión de textos.", "Lunes", "Desarrollar la expresión escrita avanzada y la creatividad.", 3, "Taller de Escritura Creativa" },
                    { 23, "Resolución de problemas con varias operaciones. Introducción a la multiplicación y división con material manipulativo y juegos. Geometría aplicada.", "Martes", "Afianzar el cálculo avanzado y la resolución de problemas complejos.", 3, "Desafíos Matemáticos" },
                    { 24, "Proyectos de investigación sobre temas de su interés. Búsqueda y selección de información. Elaboración de informes sencillos.", "Martes", "Fomentar la autonomía en la búsqueda y gestión de información.", 3, "Pequeños Investigadores" },
                    { 25, "Debates sobre temas actuales o dilemas morales adaptados. Análisis de noticias. Identificación de fake news (nivel básico).", "Miercoles", "Desarrollar el pensamiento crítico y la argumentación.", 3, "Debate y Pensamiento Crítico" },
                    { 26, "Proyectos que integren ciencia, tecnología, ingeniería, arte y matemáticas. Robótica educativa básica. Diseño de prototipos.", "Miercoles", "Fomentar la creatividad, la innovación y el pensamiento computacional.", 3, "STEAM en Acción" },
                    { 27, "Conocimiento de diferentes culturas. Proyectos sobre problemas sociales o medioambientales. Fomento de la empatía y la solidaridad.", "Jueves", "Desarrollar la conciencia social y ciudadana.", 3, "Ciudadanos del Mundo" },
                    { 28, "Uso de agendas. Planificación del estudio personal. Técnicas de estudio básicas (subrayado, esquemas).", "Jueves", "Mejorar la organización y las estrategias de aprendizaje autónomo.", 3, "Organizo mi Aprendizaje" },
                    { 29, "Exposición oral de los proyectos de investigación. Presentación de trabajos creativos. Portfolio de aprendizajes.", "Viernes", "Comunicar eficazmente los aprendizajes y valorar el propio progreso.", 3, "Presentación de Talentos" },
                    { 30, "Actividades de tutoría entre iguales (los más avanzados ayudan a otros). Proyectos colaborativos complejos.", "Viernes", "Fomentar la colaboración, el liderazgo y la responsabilidad compartida.", 3, "Mentoría y Colaboración" }
                });

            migrationBuilder.InsertData(
                table: "HitosDeDominio",
                columns: new[] { "Id", "Area", "Descripcion", "NivelId" },
                values: new object[,]
                {
                    { 1, "Lectoescritura", "Reconoce al instante un banco de 40-50 palabras funcionales (globales).", 1 },
                    { 2, "Lectoescritura", "Asocia el sonido con la grafía de las vocales y algunas consonantes clave (m, p, l, s, t, d, n, f, r suave).", 1 },
                    { 3, "Lectoescritura", "Comienza a leer y escribir sílabas directas (consonante-vocal).", 1 },
                    { 4, "Lectoescritura", "Lee y escribe palabras sencillas con sílabas directas.", 1 },
                    { 5, "Lectoescritura", "Comprende frases cortas y sencillas apoyadas en imágenes.", 1 },
                    { 6, "Lectoescritura", "Realiza trazos preparatorios para la escritura (líneas, círculos, bucles) con direccionalidad adecuada.", 1 },
                    { 7, "Lectoescritura", "Escribe su nombre con apoyo (modelo o reseguir).", 1 },
                    { 8, "Matematicas", "Cuenta hasta 20-30 y reconoce los números del 1 al 10 (cantidad y grafía).", 1 },
                    { 9, "Matematicas", "Asocia cantidad con número (hasta 10).", 1 },
                    { 10, "Matematicas", "Realiza seriaciones sencillas con dos o tres elementos.", 1 },
                    { 11, "Matematicas", "Clasifica objetos por un atributo (color, forma, tamaño).", 1 },
                    { 12, "Matematicas", "Comprende conceptos básicos espaciales (arriba/abajo, dentro/fuera, cerca/lejos) y temporales (antes/después, día/noche).", 1 },
                    { 13, "Matematicas", "Inicia la resolución de problemas sencillos de juntar o quitar (manipulativo, hasta 5).", 1 },
                    { 14, "Actitud", "Muestra curiosidad y disposición para participar en las actividades.", 1 },
                    { 15, "Actitud", "Mantiene la atención en tareas cortas (5-10 minutos) con apoyo.", 1 },
                    { 16, "Actitud", "Tolera la frustración en pequeños retos con ayuda del adulto.", 1 },
                    { 17, "Autonomia", "Sigue instrucciones sencillas de dos o tres pasos.", 1 },
                    { 18, "Autonomia", "Es capaz de organizar su material de trabajo inmediato con supervisión.", 1 },
                    { 19, "Autonomia", "Pide ayuda cuando la necesita de forma adecuada.", 1 },
                    { 20, "Lectoescritura", "Lee y escribe palabras con sílabas inversas (vocal-consonante) y mixtas (consonante-vocal-consonante).", 2 },
                    { 21, "Lectoescritura", "Lee y escribe frases sencillas con significado completo (sujeto-verbo-complemento).", 2 },
                    { 22, "Lectoescritura", "Comprende textos cortos (3-5 frases) y responde a preguntas literales sobre ellos.", 2 },
                    { 23, "Lectoescritura", "Utiliza mayúsculas al inicio de frase y en nombres propios de forma incipiente.", 2 },
                    { 24, "Lectoescritura", "Muestra interés por diferentes tipos de texto (cuentos, poesías, informativos adaptados).", 2 },
                    { 25, "Matematicas", "Cuenta hasta 100 y reconoce números hasta el 50-100 (cantidad y grafía).", 2 },
                    { 26, "Matematicas", "Realiza sumas y restas sencillas sin llevada (hasta el 20) de forma manipulativa y escrita.", 2 },
                    { 27, "Matematicas", "Comprende el concepto de decena y unidad.", 2 },
                    { 28, "Matematicas", "Resuelve problemas de suma y resta sencillos (enunciados cortos, con apoyo visual).", 2 },
                    { 29, "Matematicas", "Identifica figuras geométricas básicas (círculo, cuadrado, triángulo, rectángulo) y cuerpos sencillos (cubo, esfera).", 2 },
                    { 30, "Matematicas", "Maneja monedas de euro de bajo valor (1, 2, 5, 10, 20, 50 céntimos y 1, 2 euros) en contextos de juego.", 2 },
                    { 31, "Actitud", "Muestra iniciativa en la elección de actividades y materiales.", 2 },
                    { 32, "Actitud", "Persiste en tareas de mayor duración (15-20 minutos) con menor supervisión.", 2 },
                    { 33, "Actitud", "Comienza a auto-corregir errores evidentes en sus trabajos.", 2 },
                    { 34, "Autonomia", "Planifica tareas sencillas con ayuda (qué hacer primero, qué después).", 2 },
                    { 35, "Autonomia", "Cuida sus materiales y es responsable de su espacio de trabajo.", 2 },
                    { 36, "Autonomia", "Colabora en tareas grupales sencillas y respeta turnos.", 2 },
                    { 37, "Lectoescritura", "Lee con fluidez y entonación adecuada textos narrativos e informativos sencillos.", 3 },
                    { 38, "Lectoescritura", "Realiza inferencias sencillas y comprende el significado global de un texto.", 3 },
                    { 39, "Lectoescritura", "Escribe textos narrativos y expositivos cortos con una estructura básica (inicio, desarrollo, fin).", 3 },
                    { 40, "Lectoescritura", "Utiliza correctamente los signos de puntuación básicos (punto, coma, interrogación, exclamación).", 3 },
                    { 41, "Lectoescritura", "Planifica la escritura de un texto (lluvia de ideas, esquema sencillo) y lo revisa con ayuda.", 3 },
                    { 42, "Matematicas", "Domina las operaciones de suma y resta con llevadas.", 3 },
                    { 43, "Matematicas", "Inicia el concepto de multiplicación y división (manipulativo y con apoyo gráfico).", 3 },
                    { 44, "Matematicas", "Resuelve problemas de dos operaciones combinadas (suma y resta).", 3 },
                    { 45, "Matematicas", "Utiliza unidades de medida convencionales (metro, litro, kilo) en contextos funcionales.", 3 },
                    { 46, "Matematicas", "Interpreta gráficos sencillos (barras, pictogramas).", 3 },
                    { 47, "Actitud", "Muestra una actitud proactiva y responsable hacia su aprendizaje.", 3 },
                    { 48, "Autonomia", "Trabaja de forma autónoma durante periodos más largos (25-30 minutos).", 3 },
                    { 49, "Autonomia", "Busca información de forma autónoma en fuentes variadas (diccionarios, internet con supervisión).", 3 },
                    { 50, "Actitud", "Desarrolla estrategias para la resolución de conflictos de forma pacífica.", 3 },
                    { 51, "Actitud", "Expresa sus emociones de forma asertiva y comprende las de los demás.", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ActividadesSemanales",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "HitosDeDominio",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Niveles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Niveles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Niveles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
