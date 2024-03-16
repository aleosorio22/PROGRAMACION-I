//array 
//son una estructura de datos primitiva pero nmuy importante
//que son arrays

//ARREGLOS: SOn estructuras de datos que nos permiten almacenar multiples valores del mismo tipo de dato
//cada valor se almacena en una posicion especifica del arreglo llamada indice [INDEX]

// VENTAJAS DE ARREGLOS: Permiten organizar y acceder facilmente a conjuntos de datos relacionados
//LIMITACIONES: El tamano es fijo y se define en tiempo de compilacion. 

//EJEMPLO
static void ejemplo1()
{
    int[] calificaciones;
    calificaciones = new int[] { 85, 77, 68, 94, 75 };
    Console.WriteLine(calificaciones[2]);
}

static void ejemplo2()
{
    string[] nombres = new string[3];
    nombres[0] = "juan";
    nombres[1] = "Jorge";
    nombres[2] = "Michael";
    
    foreach (string nombre in nombres)
    {
        Console.WriteLine(nombre);
    }
}

//ejemplo2();

static void promediosconForEach()
{
    int [] notas = { 80, 75, 90, 95 };
    int promedio = 0;

    foreach (int nota in notas)
    {
        promedio += nota;
    }
    double prom = promedio / notas.Length; 
    Console.WriteLine(prom);
}

//promedios();

//recorrer un arreglo con un bucle for
static void promediosconFor()
{
    int[] notas = { 80, 75, 90, 95 };
    int promedio = 0;

    for (int i = 0; i < notas.Length; i++)
    {
        promedio += notas[i];
    }
    double prom = promedio / notas.Length;

    Console.WriteLine(prom);

}

//promediosconFor();

//metodos y priopiedadses

static void promedioConMetodos()
{
    int[] notas = { 80, 75, 90, 95 };
    double prom = notas.Average();
    Console.WriteLine(prom);
}
//promedioConMetodos();

static void verificarReprobados()
{
    int[] notas = { 80, 75, 90, 95 };

    bool hayReprobados = Array.Exists(notas, calif => calif <=60);
    if (hayReprobados == true)
    {
        Console.WriteLine("Hay reprobados");
    }
    else
    {
        Console.WriteLine("No hay reprobados");
    }
}

//verificarReprobados();

static void find()
{
    int[] nums = { 1, 2, 3, 4, 5, 6, };

}

//ejercicio

static void ordenarNombres()
{
    string[] nombres = { "Juan", "Pedro", "Jorge", "Mario", "Adan" };
    string[] nombres2 = new string[nombres.Length];

    for (int i = 0; i < nombres.Length; i++)
    {
        nombres2[i] = nombres[nombres.Length - 1 - i];
    }

    for (int i = 0; i < nombres2.Length; i++)
    {
        Console.WriteLine(nombres2[i]);
    }
    
}
ordenarNombres();
