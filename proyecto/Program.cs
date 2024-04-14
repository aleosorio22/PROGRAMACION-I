using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class GameState
{
    public int Vidas { get; set; }
    public int JugadorX { get; set; }
    public int JugadorY { get; set; }
    public bool[,] PosicionesVisitadas { get; set; }
    public List<(int, int)> ObstaculosMoviles { get; set; }
    public List<(int, int)> Enemigos { get; set; }
   

    public GameState()
    {
        ObstaculosMoviles = new List<(int, int)>();
        Enemigos = new List<(int, int)>();
    }
}


public class Program
{

    static int vidas;
    static bool[,] posicionesVisitadas;
    static int jugadorX;
    static int jugadorY;
    public static void Main(string[] args)
    {
        Inicio();
    }

    

    static void Inicio()
    {
        vidas = 5;
        posicionesVisitadas = new bool[14, 35];
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
                IniciarJuego(ConsoleKey.Escape);
                break;
            case 2:
                Console.Write("Ingrese el nombre del archivo de partida guardada: ");
                string nombreArchivo = Console.ReadLine();
                GameState estadoGuardado = CargarPartida(nombreArchivo);
                if (estadoGuardado != null)
                {
                    // Continuar juego con el estado cargado
                    ContinuarJuego(estadoGuardado);
                }
                break;
            case 3:
                MostrarInstrucciones();
                break;
            case 4:
                FinalizarJuego();
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                MostrarMenuInicio();
                break;
        }
    }

    static void GuardarPartida(GameState estado, string nombreArchivo)
    {
        estado.Vidas = vidas;
        estado.JugadorX = jugadorX;
        estado.JugadorY = jugadorY;
        estado.PosicionesVisitadas = posicionesVisitadas;
        string json = JsonConvert.SerializeObject(estado);
        File.WriteAllText(nombreArchivo, json);
        Console.WriteLine($"Partida guardada como '{nombreArchivo}'.");
    }

    static GameState CargarPartida(string nombreArchivo)
    {
        if (File.Exists(nombreArchivo))
        {
            string json = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<GameState>(json);
        }
        else
        {
            Console.WriteLine("No se encontró un archivo de partida guardada.");
            return null;
        }
    }

    static void ContinuarJuego(GameState estado)
    {

        vidas = estado.Vidas;
        jugadorX = estado.JugadorX;
        jugadorY = estado.JugadorY;
        posicionesVisitadas = estado.PosicionesVisitadas;
    
    }

    static void FinalizarJuego()
    {
        // Guardar partida antes de salir
        Console.Write("¿Desea guardar la partida antes de salir? (S/N): ");
        string respuesta = Console.ReadLine().Trim().ToUpper();
        if (respuesta == "S")
        {
            Console.Write("Ingrese el nombre del archivo de guardado: ");
            string nombreArchivo = Console.ReadLine();
            GuardarPartida(new GameState(), nombreArchivo);
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

    static void IniciarJuego(ConsoleKey teclaSalida)
    {
        // Definir el tamaño del laberinto
        int filas = 14;
        int columnas = 35;

        Console.WriteLine($"Tamaño del laberinto: {filas} filas x {columnas} columnas");

        //bool[,] posicionesVisitadas = new bool[filas, columnas];

        // Crear el laberinto representado como una matriz de caracteres
        char[,] laberinto = GenerarLaberinto(filas, columnas);
        List<(int, int)> obstaculosMoviles = GenerarObstaculosMoviles(filas, columnas, 15);
        List<(int, int)> enemigos = GenerarEnemigos(filas, columnas, 10);

        if (jugadorX == -1 && jugadorY == -1)
        {
            jugadorX = 0;
            jugadorY = 0;
        }

        Console.WriteLine($"Posición inicial del jugador: ({jugadorX}, {jugadorY})");

        // Variable para controlar si el jugador ha encontrado la salida
        bool salidaEncontrada = false;

        // Bucle principal del juego
        while (!salidaEncontrada)
        {
            obstaculosMoviles = MoverObstaculosMoviles(filas, columnas, obstaculosMoviles);

            // Calcular rutas de los enemigos hacia el jugador utilizando Dijkstra
            Dictionary<(int, int), List<(int, int)>> rutasEnemigos = CalcularRutasEnemigos(filas, columnas, enemigos, (jugadorX, jugadorY));

            Console.WriteLine("Posiciones de los enemigos:");

            // Mover enemigos
            for (int i = 0; i < enemigos.Count; i++)
            {
                var enemigo = enemigos[i];
                if (rutasEnemigos.ContainsKey(enemigo) && rutasEnemigos[enemigo].Count > 0)
                {
                    
                    var siguientePaso = rutasEnemigos[enemigo][0];
                    
                    enemigos[i] = siguientePaso;
                  
                    rutasEnemigos[enemigo].RemoveAt(0);

                }
                Console.WriteLine($"({enemigo.Item1}, {enemigo.Item2})");
            }

           
            MostrarLaberinto(laberinto, jugadorX, jugadorY, obstaculosMoviles, enemigos, posicionesVisitadas);
            posicionesVisitadas[jugadorX, jugadorY] = true;

   
            ConsoleKeyInfo tecla = Console.ReadKey(true); // Cambiado a true para no mostrar la entrada en la consola

            if (tecla.Key == teclaSalida)
            {
                FinalizarJuego();
                break; // Salir del bucle principal del juego
            }

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
        // Si el bucle termina sin encontrar la salida o si el jugador se queda sin vidas
        if (!salidaEncontrada)
        {
            Console.WriteLine("¡Te quedaste sin vidas! Game Over.");
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
        Console.WriteLine($"Vidas restantes: {vidas}");
        Console.WriteLine($"Posición del jugador: ({jugadorX}, {jugadorY})");
        Console.WriteLine("Posiciones de los enemigos:");
        for (int k = enemigos.Count - 1; k >= 0; k--)
        {
            var enemigo = enemigos[k];
            Console.WriteLine($"({enemigo.Item1}, {enemigo.Item2})");
           
            if (jugadorX == enemigo.Item1 && jugadorY == enemigo.Item2)
            {
                Console.WriteLine("¡El enemigo ha alcanzado al jugador!");
                vidas--;
                enemigos.RemoveAt(k);
                Console.WriteLine("Enter para continuar jugando.");
                Console.ReadLine();

                if (vidas <= 0)
                {
                    Console.WriteLine("¡Te quedaste sin vidas! Game Over.");
                    Environment.Exit(0);
                    Console.ReadLine();
                }
            }
        }
    }



    static Dictionary<(int, int), List<(int, int)>> CalcularRutasEnemigos(int filas, int columnas, List<(int, int)> enemigos, (int, int) jugadorPosicion)
    {
        Dictionary<(int, int), List<(int, int)>> rutasEnemigos = new Dictionary<(int, int), List<(int, int)>>();

        foreach (var enemigo in enemigos)
        {
            // Verificar si la clave ya existe en el diccionario
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