using System;
using System.Collections.Generic;

public class LaberintoJuego
{
    // Variable estática para almacenar las vidas del jugador
    private static int vidas;

    public static void Inicio()
    {
        vidas = 3; // Inicializar las vidas del jugador
        bool salir = false;

        while (!salir)
        {
            MostrarMenuInicio();
            salir = !ContinuarJugando();
        }

        Console.WriteLine("¡Gracias por jugar!");
    }

    public static void MostrarMenuInicio()
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

    public static bool ContinuarJugando()
    {
        Console.WriteLine("¿Desea continuar jugando? (S/N)");
        string respuesta = Console.ReadLine().Trim().ToUpper();
        return respuesta == "S";
    }

    public static void MostrarInstrucciones()
    {
        Console.WriteLine("Instrucciones del Juego:");
        Console.WriteLine("Mueva al jugador a través del laberinto utilizando las teclas de dirección.");
        Console.WriteLine("Evite regresar a posiciones previamente visitadas y encuentre la salida del laberinto.");
    }

    public static void IniciarJuego()
    {
        // Definir el tamaño del laberinto
        int filas = 10;
        int columnas = 20;

        Console.WriteLine($"Tamaño del laberinto: {filas} filas x {columnas} columnas");

        // Inicializar la matriz de posiciones visitadas
        bool[,] posicionesVisitadas = new bool[filas, columnas];

        // Crear el laberinto representado como una matriz de caracteres
        char[,] laberinto = GenerarLaberinto(filas, columnas);
        List<(int, int)> obstaculosMoviles = GenerarObstaculosMoviles(filas, columnas, 5);
        List<(int, int)> enemigos = GenerarEnemigos(filas, columnas, 3);

        // Posición inicial del jugador
        int jugadorX = 0;
        int jugadorY = 0;

        Console.WriteLine($"Posición inicial del jugador: ({jugadorX}, {jugadorY})");

        // Variable para controlar si el jugador ha encontrado la salida
        bool salidaEncontrada = false;

        // Bucle principal del juego
        while (!salidaEncontrada && vidas > 0)
        {
            // Mover obstáculos móviles
            obstaculosMoviles = MoverObstaculosMoviles(filas, columnas, obstaculosMoviles);

            // Calcular rutas de los enemigos hacia el jugador utilizando Dijkstra
            Dictionary<(int, int), List<(int, int)>> rutasEnemigos = CalcularRutasEnemigos(filas, columnas, enemigos, (jugadorX, jugadorY));

            // Mover enemigos
            foreach (var enemigo in enemigos)
            {
                if (rutasEnemigos.ContainsKey(enemigo) && rutasEnemigos[enemigo].Count > 0)
                {
                    // Obtener el siguiente paso en la ruta del enemigo
                    var siguientePaso = rutasEnemigos[enemigo][0];
                    // Actualizar la posición del enemigo
                    enemigo.Item1 = siguientePaso.Item1;
                    enemigo.Item2 = siguientePaso.Item2;
                }

                // Verificar si el enemigo alcanza al jugador
                if (enemigo.Item1 == jugadorX && enemigo.Item2 == jugadorY)
                {
                    Console.WriteLine("¡El enemigo ha alcanzado al jugador!");
                    vidas--; // Reducir una vida
                    Console.WriteLine($"Vidas restantes: {vidas}");
                    if (vidas <= 0)
                    {
                        Console.WriteLine("¡Te quedaste sin vidas! Game Over.");
                        return;
                    }
                }
            }

            // Mostrar el laberinto y la posición actual del jugador
            MostrarLaberinto(laberinto, jugadorX, jugadorY, obstaculosMoviles, enemigos, posicionesVisitadas);

            // Marcar la posición actual del jugador como visitada
            posicionesVisitadas[jugadorX, jugadorY] = true;

            // Obtener la entrada del jugador
            ConsoleKeyInfo tecla = Console.ReadKey(true);

            // Actualizar la posición del jugador según la entrada del jugador
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (jugadorX > 0 && !obstaculosMoviles.Contains((jugadorX - 1, jugadorY)) && !posicionesVisitadas[jugadorX - 1, jugadorY])
                        jugadorX--;
                    break;
                case ConsoleKey.DownArrow:
                    if (jugadorX < filas - 1 && !obstaculosMoviles.Contains((jugadorX + 1, jugadorY)) && !posicionesVisitadas[jugadorX + 1, jugadorY])
                        jugadorX++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (jugadorY > 0 && !obstaculosMoviles.Contains((jugadorX, jugadorY - 1)) && !posicionesVisitadas[jugadorX, jugadorY - 1])
                        jugadorY--;
                    break;
                case ConsoleKey.RightArrow:
                    if (jugadorY < columnas - 1 && !obstaculosMoviles.Contains((jugadorX, jugadorY + 1)) && !posicionesVisitadas[jugadorX, jugadorY + 1])
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

        // Si el bucle termina sin encontrar la salida o si el jugador se queda sin vidas
        if (!salidaEncontrada)
        {
            Console.WriteLine("¡Te quedaste sin vidas! Game Over.");
        }
    }

    static char[,] GenerarLaberinto(int filas, int columnas)
    {
        char[,] laberinto = new char[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                laberinto[i, j] = '.';
            }
        }

        laberinto[filas - 1, columnas - 1] = 'S'; // Colocar la salida en la esquina inferior derecha del laberinto

        return laberinto;
    }

    static List<(int, int)> MoverObstaculosMoviles(int filas, int columnas, List<(int, int)> obstaculosMoviles)
    {
        Random rnd = new Random();
        List<(int, int)> nuevosObstaculos = new List<(int, int)>();

        foreach (var obstaculo in obstaculosMoviles)
        {
            int newX = obstaculo.Item1 + rnd.Next(-1, 2);
            int newY = obstaculo.Item2 + rnd.Next(-1, 2);

            if (newX >= 0 && newX < filas && newY >= 0 && newY < columnas)
            {
                nuevosObstaculos.Add((newX, newY));
            }
            else
            {
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

    static List<(int, int)> GenerarEnemigos(int filas, int columnas, int cantidad)
    {
        List<(int, int)> enemigos = new List<(int, int)>();
        Random rnd = new Random();

        for (int i = 0; i < cantidad; i++)
        {
            int x = rnd.Next(filas);
            int y = rnd.Next(columnas);
            enemigos.Add((x, y));
        }

        return enemigos;
    }

    static void MostrarLaberinto(char[,] laberinto, int jugadorX, int jugadorY, List<(int, int)> obstaculosMoviles, List<(int, int)> enemigos, bool[,] posicionesVisitadas)
    {
        Console.Clear();
        for (int i = 0; i < laberinto.GetLength(0); i++)
        {
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {
                if (i == jugadorX && j == jugadorY)
                {
                    Console.Write("☺");
                }
                else if (obstaculosMoviles.Contains((i, j)))
                {
                    Console.Write("X");
                }
                else if (enemigos.Contains((i, j)))
                {
                    Console.Write("E");
                }
                else if (posicionesVisitadas[i, j])
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(laberinto[i, j]);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Posición del jugador: ({jugadorX}, {jugadorY})");
        Console.WriteLine("Posiciones de los enemigos:");
        foreach (var enemigo in enemigos)
        {
            Console.WriteLine($"- ({enemigo.Item1}, {enemigo.Item2})");
        }
    }

    static Dictionary<(int, int), List<(int, int)>> CalcularRutasEnemigos(int filas, int columnas, List<(int, int)> enemigos, (int, int) jugadorPosicion)
    {
        Dictionary<(int, int), List<(int, int)>> rutasEnemigos = new Dictionary<(int, int), List<(int, int)>>();

        foreach (var enemigo in enemigos)
        {
            if (!rutasEnemigos.ContainsKey(enemigo))
            {
                List<(int, int)> ruta = Dijkstra(filas, columnas, enemigo, jugadorPosicion);
                rutasEnemigos.Add(enemigo, ruta);
            }
        }

        return rutasEnemigos;
    }

    static List<(int, int)> Dijkstra(int filas, int columnas, (int, int) inicio, (int, int) fin)
    {
        int[,] distancias = new int[filas, columnas];
        bool[,] visitado = new bool[filas, columnas];
        (int, int)[,] padres = new (int, int)[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                distancias[i, j] = int.MaxValue;
            }
        }

        distancias[inicio.Item1, inicio.Item2] = 0;

        while (true)
        {
            (int, int) u = (-1, -1);
            int minDistancia = int.MaxValue;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (!visitado[i, j] && distancias[i, j] < minDistancia)
                    {
                        minDistancia = distancias[i, j];
                        u = (i, j);
                    }
                }
            }

            if (u == (-1, -1))
                break;

            visitado[u.Item1, u.Item2] = true;

            if (u == fin)
                break;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 && dy != 0)
                        continue;

                    int x = u.Item1 + dx;
                    int y = u.Item2 + dy;

                    if (x < 0 || x >= filas || y < 0 || y >= columnas || visitado[x, y])
                        continue;

                    int distanciaActualizada = distancias[u.Item1, u.Item2] + 1;

                    if (distanciaActualizada < distancias[x, y])
                    {
                        distancias[x, y] = distanciaActualizada;
                        padres[x, y] = u;
                    }
                }
            }
        }

        List<(int, int)> ruta = new List<(int, int)>();

        if (distancias[fin.Item1, fin.Item2] != int.MaxValue)
        {
            (int, int) actual = fin;

            while (actual != inicio)
            {
                ruta.Add(actual);
                actual = padres[actual.Item1, actual.Item2];
            }

            ruta.Reverse();
        }

        return ruta;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LaberintoJuego.Inicio();
    }
}
