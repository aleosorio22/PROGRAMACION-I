using static System.Runtime.InteropServices.JavaScript.JSType;

Main();
static void Main()
{
    Menu();
}
static void Menu()
{
    Console.Clear();

    Console.WriteLine("PRIMER PARCIAL PROGRAMACION I");
    Console.WriteLine("1. Ejercicio 1");
    Console.WriteLine("2. Ejercicio 2");
    Console.WriteLine("3. Ejercicio 3");
    Console.WriteLine("4. Ejercicio 4");
    Console.WriteLine("0. Salir");

    Console.Write("Seleccione una opción: ");
    string n = Console.ReadLine();
    Opcion(n);
}

static void Opcion(string n)
{
    switch (n)
    {
        case "1":
            Console.WriteLine("Programa 1");
            P1();
            Console.WriteLine();
            break;
        case "2":
            Console.WriteLine("Programa 2");
            P2();
            break;
        case "3":
            Console.WriteLine("Programa 3");
            P3();
            break;
        case "4":
            Console.WriteLine("Programa 4");
            P4();
            break;
        case "0":
            Console.WriteLine("Hasta pronto.");
            break;
        default:
            Console.WriteLine("Ingrese una opcion valida");
            break;
    }

    if (n != "0")
    {
        Console.WriteLine();
        Menu();
    }
}

static void P1()
{
    Console.WriteLine("Escriba un número entero positivo:");
    if (int.TryParse(Console.ReadLine(), out int numero) && numero > 0)
    {
        submenu1(numero);
    }
    else
    {
        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero positivo.");
        Console.WriteLine("Presione cualquier tecla para volver al menú.");
        Console.ReadKey();
        Menu();
    }
}

static void submenu1(int numero)
{
    Console.Clear();

    Console.WriteLine($"Menú para el número {numero}");
    Console.WriteLine("1. Calcular el factorial del número");
    Console.WriteLine("2. Calcular la raíz cuadrada del número");
    Console.WriteLine("0. Salir al menu principal");

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    OpcionEjercicio1(numero, opcion);
} 

static void OpcionEjercicio1(int numero, string opcion)
{
    switch(opcion)
    {
        case "1":
            Console.Clear();
            Console.WriteLine($"El factorial de {numero} es: {Factorial(numero)}");
            Console.WriteLine();
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine($"La raiz cuadrada de {numero} es: {Math.Sqrt(numero)}");
            Console.WriteLine();
            Console.ReadLine();
            break;
        case "0":
            Console.WriteLine("Saliendo...");
            Menu();
            return;
        default:
            Console.Clear();
            Console.WriteLine("Ingrese una opcion valida");
            break;
    }
    Console.WriteLine();
    submenu1(numero);
}

static int Factorial(int n)
{
    if (n == 0 || n == 1)
    {
        return 1;
    }
    else
    {
        return n * Factorial(n - 1);
    }
}

static void P2()
{
    Console.WriteLine("Por favor el primer numero entero positivo");
    if(int.TryParse(Console.ReadLine(), out int n1 ) && n1 > 0)
    {
        Console.WriteLine("Ingrese el segundo numero entero positivo");
        if (int.TryParse(Console.ReadLine(),out int n2 ) && n2 > 0)
        {
            Console.WriteLine("Seleccione el operador matematico: (+, -, *, /).");
            string operador = Console.ReadLine();
            ProcesoP2(n1, n2, operador);
        }
        else
        {
            Console.WriteLine("El segundo numero ingresado no es valido (presione cualquier tecla para continuar)");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("El primer numero ingresado no es valido (presione cualquier tecla para continuar)");
        Console.ReadKey();
    }
}

static int ProcesoP2(int n1, int n2, string operador)
{
    int resultado = 0;

    if (operador == "+")
    {
        resultado = n1 + n2;
    }
    else if (operador == "-")
    {
        resultado = n1 - n2;
    }
    else if (operador == "*")
    {
        resultado = n1 * n2;
    }
    else if (operador == "/")
    {
        resultado = n1 / n2;
    }
    else
    {
        Console.WriteLine("El operador seleccionado no es valido:");
    }
    Console.WriteLine($"Resultado: {resultado}");
    Console.ReadKey();
    return resultado;
}


static void P3()
{
    Console.WriteLine("Ingrese un numero positivo entero");
    if(int.TryParse(Console.ReadLine(),out int n1) && n1 > 0)
    {
        for (int i = 1; i <= 10; i++ )
            Console.WriteLine($"{n1} * {i} = {n1*i}");
    }
    else
    {
        Console.WriteLine("Ingrese un numero valido (presione cualquier tecla para continuar");
    }
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
}

static void P4()
{
    Random random = new Random();
    int numero = random.Next(1, 100);
    int n1 = 0;
    do
    {
        Console.WriteLine("Adivine el numero que el sistema genero de 1 a 100");
        try
        {
            string entrada = Console.ReadLine();
            n1 = int.Parse(entrada);

            if (n1 < 1 || n1 > 100)
            {
                Console.WriteLine("Por favor ingrese un numero valido entre 1 y 100");
                continue;
            }
            if (n1 > numero)
            {
                Console.WriteLine($"{n1} es mayor que el numero que el sistema genero");
            }
            else if (n1 < numero)
            {
                Console.WriteLine($"{n1} es menor al numero que el sistema ingreso");
            }
            else
            {
                Console.WriteLine($"Felicidades, adivinaste el numero! Presiona cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada no valida");
        }

    }
    while (n1 != numero );
}