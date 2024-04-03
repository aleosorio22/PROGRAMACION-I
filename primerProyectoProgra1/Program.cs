//List<(int, int)> obstaculosMoviles = new List<(int, int)>();


Inicio();
static void Inicio()
{
    bool[,] posicionesVisitadas = null;
    bool salir = false;

    while (!salir)
    {
        MostrarMenuInicio();
        salir = !ContinuarJugando();
    }

    Console.WriteLine("¡Gracias por jugar!");
}

static void MostrarMenuInicio()
{
    Console.Clear();
    Console.WriteLine("¡Bienvenido al Juego de Laberinto!");
    Console.WriteLine("1. Iniciar nuevo juego");
    Console.WriteLine("2. Cargar partida guardada");
    Console.WriteLine("3. Ver instrucciones");
    Console.WriteLine("4. Salir del juego");
    Console.Write("Seleccione una opción: ");
    int opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.WriteLine("¡Iniciando un nuevo juego!");
            IniciarJuego();
            break;
        case 2:
            Console.WriteLine("Cargando partida guardada...");
            // Lógica para cargar una partida guardada
            break;
        case 3:
            MostrarInstrucciones();
            break;
        case 4:
            Console.WriteLine("¡Gracias por jugar!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
            MostrarMenuInicio();
            break;
    }
}

static bool ContinuarJugando()
{
    Console.WriteLine("¿Desea continuar jugando? (S/N)");
    string respuesta = Console.ReadLine().Trim().ToUpper();
    return respuesta == "S";
}

static void MostrarInstrucciones()
{
    Console.WriteLine("Instrucciones del Juego:");
    // Aquí podríamos mostrar las instrucciones detalladas sobre cómo jugar el juego de laberinto.
    // Por ahora, simplemente mostraremos un mensaje genérico.
    Console.WriteLine("Mueva al jugador a través del laberinto utilizando las teclas de dirección.");
    Console.WriteLine("Evite regresar a posiciones previamente visitadas y encuentre la salida del laberinto.");
}

static void IniciarJuego()
{
    // Definir el tamaño del laberinto
    int filas = 10;
    int columnas = 20;

    // Inicializar la matriz de posiciones visitadas
    bool[,] posicionesVisitadas = new bool[filas, columnas];

    // Crear el laberinto representado como una matriz de caracteres
    char[,] laberinto = GenerarLaberinto(filas, columnas);
    List<(int, int)> obstaculosMoviles = GenerarObstaculosMoviles(filas, columnas, 5);  // Generar obstáculos móviles

    // Posición inicial del jugador
    int jugadorX = 0;
    int jugadorY = 0;

    // Variable para controlar si el jugador ha encontrado la salida
    bool salidaEncontrada = false;

    // Bucle principal del juego
    while (!salidaEncontrada)
    {
        // Mover obstáculos móviles
        obstaculosMoviles = MoverObstaculosMoviles(filas, columnas, obstaculosMoviles);

        // Mostrar el laberinto y la posición actual del jugador
        MostrarLaberinto(laberinto, jugadorX, jugadorY, obstaculosMoviles);
        // Marcar la posición actual del jugador como visitada
        posicionesVisitadas[jugadorX, jugadorY] = true;

        // Obtener la entrada del jugador
        ConsoleKeyInfo tecla = Console.ReadKey(true); // Cambiado a true para no mostrar la entrada en la consola

        // Actualizar la posición del jugador según la entrada del jugador
        switch (tecla.Key)
        {
            case ConsoleKey.UpArrow:
                if (jugadorX > 0 && !obstaculosMoviles.Contains((jugadorX - 1, jugadorY)) && !posicionesVisitadas[jugadorX - 1, jugadorY]) // Verificar si hay un obstáculo móvil arriba y si la posición no ha sido visitada
                    jugadorX--;
                break;
            case ConsoleKey.DownArrow:
                if (jugadorX < filas - 1 && !obstaculosMoviles.Contains((jugadorX + 1, jugadorY)) && !posicionesVisitadas[jugadorX + 1, jugadorY]) // Verificar si hay un obstáculo móvil abajo y si la posición no ha sido visitada
                    jugadorX++;
                break;
            case ConsoleKey.LeftArrow:
                if (jugadorY > 0 && !obstaculosMoviles.Contains((jugadorX, jugadorY - 1)) && !posicionesVisitadas[jugadorX, jugadorY - 1]) // Verificar si hay un obstáculo móvil a la izquierda y si la posición no ha sido visitada
                    jugadorY--;
                break;
            case ConsoleKey.RightArrow:
                if (jugadorY < columnas - 1 && !obstaculosMoviles.Contains((jugadorX, jugadorY + 1)) && !posicionesVisitadas[jugadorX, jugadorY + 1]) // Verificar si hay un obstáculo móvil a la derecha y si la posición no ha sido visitada
                    jugadorY++;
                break;
        }

        // Comprobar si el jugador ha llegado a la salida
        if (jugadorX == filas - 1 && jugadorY == columnas - 1)
        {
            Console.WriteLine("¡Felicidades! ¡Has encontrado la salida!");
            salidaEncontrada = true;
        }
    }
}


static char[,] GenerarLaberinto(int filas, int columnas)
{
    // Crear una matriz para representar el laberinto
    char[,] laberinto = new char[filas, columnas];

    // Llenar el laberinto con caracteres de ejemplo
    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
            laberinto[i, j] = '.';
        }
    }

    // Colocar la salida en la esquina inferior derecha del laberinto
    laberinto[filas - 1, columnas - 1] = 'S';

    return laberinto;
}

static List<(int, int)> MoverObstaculosMoviles(int filas, int columnas, List<(int, int)> obstaculosMoviles)
{
    Random rnd = new Random();
    List<(int, int)> nuevosObstaculos = new List<(int, int)>();

    foreach (var obstaculo in obstaculosMoviles)
    {
        int newX = obstaculo.Item1 + rnd.Next(-1, 2); // Mover en el rango [-1, 1] en dirección X
        int newY = obstaculo.Item2 + rnd.Next(-1, 2); // Mover en el rango [-1, 1] en dirección Y

        // Verificar que la nueva posición esté dentro de los límites del laberinto
        if (newX >= 0 && newX < filas && newY >= 0 && newY < columnas)
        {
            nuevosObstaculos.Add((newX, newY));
        }
        else
        {
            // Si la nueva posición está fuera de los límites del laberinto, mantener la posición actual
            nuevosObstaculos.Add(obstaculo);
        }
    }

    return nuevosObstaculos;
}

static List<(int, int)> GenerarObstaculosMoviles(int filas, int columnas, int cantidad)
{
    List<(int, int)> obstaculos = new List<(int, int)>();
    Random rnd = new Random();

    for (int i = 0; i < cantidad; i++)
    {
        int x = rnd.Next(filas);
        int y = rnd.Next(columnas);
        obstaculos.Add((x, y));
    }

    return obstaculos;
}
static void MostrarLaberinto(char[,] laberinto, int jugadorX, int jugadorY, List<(int, int)> obstaculosMoviles)
{
    Console.Clear();
    for (int i = 0; i < laberinto.GetLength(0); i++)
    {
        for (int j = 0; j < laberinto.GetLength(1); j++)
        {
            if (i == jugadorX && j == jugadorY)
            {
                Console.Write("☺"); // Símbolo para representar al jugador
            }
            else if (obstaculosMoviles.Contains((i, j)))
            {
                Console.Write("X"); // Símbolo para representar un obstáculo móvil
            }
            else
            {
                Console.Write(laberinto[i, j]);
            }
        }
        Console.WriteLine();
    }
}
