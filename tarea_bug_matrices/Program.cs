Console.WriteLine("hola");

//inicio del programa principal
string[] palabras = { "GATO", "PERRO", "CASA", "ARBOL" };
char[,] tablero = GenerarTablero(palabras);

Console.WriteLine("¡Bienvenido al juego de búsqueda de palabras!");
MostrarTablero(tablero);

foreach (string palabra in palabras)
{
    Console.Write($"Ingresa la posición de la palabra '{palabra}' (fila, columna): ");
    string[] posicion = Console.ReadLine().Split(',');
    int fila = int.Parse(posicion[0]);
    int columna = int.Parse(posicion[1]);

    if (VerificarPalabra(tablero, palabra, fila, columna))
    {
        Console.WriteLine("¡Correcto!");
    }
    else
    {
        Console.WriteLine("Incorrecto. Intenta de nuevo.");
    }
}

Console.WriteLine("¡Felicidades! Has completado el juego.");
Console.ReadLine();




// funciones utilizadas en el programa principal
static char[,] GenerarTablero(string[] palabras)
{
    int tamanio = 10;
    char[,] tablero = new char[tamanio, tamanio];

    // Rellenar el tablero con caracteres aleatorios
    Random random = new Random();
    for (int i = 0; i < tamanio; i++)
    {
        for (int j = 0; j < tamanio; j++)
        {
            tablero[i, j] = (char)random.Next('A', 'Z' + 1);
        }
    }

    // Colocar las palabras en el tablero
    foreach (string palabra in palabras)
    {
        UbicarPalabra(tablero, palabra);
    }

    return tablero;
}

//static void UbicarPalabra(char[,] tablero, string palabra)
//{
//    int tamanio = tablero.GetLength(0);
//    Random random = new Random();
//    bool colocada = false;

//    while (!colocada)
//    {
//        int fila = random.Next(tamanio);
//        int columna = random.Next(tamanio);
//        int direccion = random.Next(8); // 0: horizontal, 1: vertical, 2-7: diagonales

//        if (PuedeColocarPalabra(tablero, palabra, fila, columna, direccion))
//        {
//            ColocarPalabraEnTablero(tablero, palabra, fila, columna, direccion);
//            colocada = true;
//        }
//    }
//}

static void UbicarPalabra(char[,] tablero, string palabra)
{
    int tamanio = tablero.GetLength(0);
    Random random = new Random();
    bool colocada = false;
    int maxIntentos = 1000; // Número máximo de intentos para colocar una palabra
    int intentos = 0;

    while (!colocada && intentos < maxIntentos)
    {
        int fila = random.Next(tamanio);
        int columna = random.Next(tamanio);
        int direccion = random.Next(8); // 0: horizontal, 1: vertical, 2-7: diagonales

        if (PuedeColocarPalabra(tablero, palabra, fila, columna, direccion))
        {
            ColocarPalabraEnTablero(tablero, palabra, fila, columna, direccion);
            colocada = true;
        }
        else
        {
            intentos++;
        }
    }
}

static bool PuedeColocarPalabra(char[,] tablero, string palabra, int fila, int columna, int direccion)
{
    int tamanio = tablero.GetLength(0);
    int filaOffset = 0, columnaOffset = 0;

    switch (direccion)
    {
        case 0: // Horizontal derecha
            columnaOffset = 1;
            break;
        case 1: // Vertical abajo
            filaOffset = 1;
            break;
        case 2: // Diagonal derecha abajo
            filaOffset = 1;
            columnaOffset = 1;
            break;
            // ... (omitido por brevedad)
    }

    int filaSiguiente = fila + filaOffset;
    int columnaSiguiente = columna + columnaOffset;

    for (int i = 0; i < palabra.Length; i++)
    {
        //bug
        if (filaSiguiente >= tamanio || columnaSiguiente >= tamanio || !char.IsUpper(tablero[filaSiguiente, columnaSiguiente]))
        {
            return false;
        }

        filaSiguiente += filaOffset;
        columnaSiguiente += columnaOffset;
    }

    return true;
}

//static void ColocarPalabraEnTablero(char[,] tablero, string palabra, int fila, int columna, int direccion)
//{
//    int filaOffset = 0, columnaOffset = 0;

//    switch (direccion)
//    {
//        case 0: // Horizontal derecha
//            columnaOffset = 1;
//            break;
//        case 1: // Vertical abajo
//            filaOffset = 1;
//            break;
//        case 2: // Diagonal derecha abajo
//            filaOffset = 1;
//            columnaOffset = 1;
//            break;
//            // ... (omitido por brevedad)
//    }

//    for (int i = 0; i < palabra.Length; i++)
//    {
//        tablero[fila, columna] = palabra[i];
//        fila += filaOffset;
//        columna += columnaOffset;
//    }
//}
static void ColocarPalabraEnTablero(char[,] tablero, string palabra, int fila, int columna, int direccion)
{
    int filaOffset = 0, columnaOffset = 0;

    switch (direccion)
    {
        case 0: // Horizontal derecha
            columnaOffset = 1;
            break;
        case 1: // Vertical abajo
            filaOffset = 1;
            break;
        case 2: // Diagonal derecha abajo
            filaOffset = 1;
            columnaOffset = 1;
            break;
            // ... (omitido por brevedad)
    }

    int filaActual = fila;
    int columnaActual = columna;

    for (int i = 0; i < palabra.Length; i++)
    {
        tablero[filaActual, columnaActual] = palabra[i];
        filaActual += filaOffset;
        columnaActual += columnaOffset;
    }
}

static void MostrarTablero(char[,] tablero)
{
    int tamanio = tablero.GetLength(0);

    for (int i = 0; i < tamanio; i++)
    {
        for (int j = 0; j < tamanio; j++)
        {
            Console.Write(tablero[i, j] + " ");
        }
        Console.WriteLine();
    }
}


//static bool VerificarPalabra(char[,] tablero, string palabra, int fila, int columna)
//{
//    int longitud = palabra.Length;
//    int tamanio = tablero.GetLength(0);

//    // Verificar si las coordenadas están dentro del rango del tablero
//    if (fila < 0 || fila >= tamanio || columna < 0 || columna >= tamanio)
//    {
//        return false;
//    }

//    // Verificar horizontalmente
//    if (columna + longitud <= tamanio)
//    {
//        bool encontrada = true;
//        for (int i = 0; i < longitud; i++)
//        {
//            if (tablero[fila, columna + i] != palabra[i])
//            {
//                encontrada = false;
//                break;
//            }
//        }
//        if (encontrada) return true;
//    }

//    // Verificar verticalmente
//    if (fila + longitud <= tamanio)
//    {
//        bool encontrada = true;
//        for (int i = 0; i < longitud; i++)
//        {
//            if (tablero[fila + i, columna] != palabra[i])
//            {
//                encontrada = false;
//                break;
//            }
//        }
//        if (encontrada) return true;
//    }

//    // Si no se encontró en ninguna dirección, retornar falso
//    return false;
//}


static bool VerificarPalabra(char[,] tablero, string palabra, int fila, int columna)
{
    int tamanio = tablero.GetLength(0);
    int longitudPalabra = palabra.Length;

    // Verificar horizontal derecha
    if (columna + longitudPalabra <= tamanio)
    {
        string palabraEncontrada = "";
        for (int i = 0; i < longitudPalabra; i++)
        {
            palabraEncontrada += tablero[fila, columna + i];
        }
        if (palabraEncontrada == palabra)
        {
            return true;
        }
    }

    // Verificar otras direcciones (omitido por brevedad)

    return false;
}