////EJERCICIOS CLASE 5
int opcion;
do
{
    menu();
    opcion = opc();

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ejercicio 1");
            ejercicio1();
            break;
        case 2:
            Console.WriteLine("Ejercicio 2");
            ejercicio2();
            break;
        case 3:
            Console.WriteLine("Ejercicio 3");
            ejercicio3();
            break;
         case 4:
            Console.WriteLine("Ejercicio 4");
            ejercicio4();
            break;
        case 0:
            Console.WriteLine("Adios!");
            break;
        default:
            Console.WriteLine("ingrese una opcion valida");
            break;
    }

    if (opcion != 0)
    {
        Console.WriteLine("Presiona cualquier tecla para continuar");
        Console.ReadKey();
    }
} while (opcion != 0);

static void menu()
{
    Console.Clear();

    Console.WriteLine("Seleccione una opcion: ");
    Console.WriteLine("1. Ejercicio 1");
    Console.WriteLine("2. Ejercicio 2");
    Console.WriteLine("3. Ejercicio 3");
    Console.WriteLine("4. Ejercicio 4");
    Console.WriteLine("0. Salir");
}

static int opc()
{
    Console.WriteLine("Selecciona una opcion: ");
    if (int.TryParse(Console.ReadLine() , out int opcion))
    {
        return opcion;
    }
    else
    {
        Console.WriteLine("entrada no valida");
        return -1;
    }
}


//ejercicio 1
static void ejercicio1()
{
    int n, max, min;

    Console.WriteLine("ingrese n1");
    n = int.Parse(Console.ReadLine());

    max = n;
    min = n;

    do
    {
        if (n > max)
        {
            max = n;
        }
        else
        {
            min = n;
        }

        Console.WriteLine("ingrese n1");
        n = int.Parse(Console.ReadLine());
    }

    while (n != 0);

    Console.WriteLine("el numero mayor fue: " + max);
    Console.WriteLine("el numero menor fue: " + min);

}

//ejercicio2
static void ejercicio2()
{
    Console.WriteLine("ingrese cualquier numero");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine($"multiplique el numero por 2: {n = n * 2}");
    Console.WriteLine($"Sumele 8 a su resultado: {n = n + 8}");
    Console.WriteLine($"multiplique su resultado por 5 {n = n * 5}");
    Console.WriteLine($"Ingrese su resultado final {n}");


    string numero = n.ToString();

    string nuevonumero = numero.Substring(0, numero.Length - 1);

    int nuevon = int.Parse(nuevonumero);

    nuevon = nuevon - 4;

    Console.WriteLine($"El numero es {nuevon}");
}




//ejercicio3
static void ejercicio3()
{
    Console.WriteLine("Ingrese una frase por favor: ");
    string fraseIngresada = Console.ReadLine();
    contPalabras(fraseIngresada);
}

static void contPalabras(string frase)
{
    int nPalabras = 0;  
    int nVocales = 0;
    bool palabras = false;

    frase = frase.ToLower();   
    
    foreach(var caracter in frase)
    {
        if (char.IsWhiteSpace(caracter))
        {
            palabras = false;
        }
        else if (char.IsLetter(caracter))
        {
            if (!palabras)
            {
                nPalabras++;
                palabras |= true;
            }
            if("aeiou".Contains(caracter))
            {
                nVocales++;
            }
        }
    }

    Console.WriteLine($"Numero de palabras: {nPalabras}");
    Console.WriteLine($"Numero de vocales: {nVocales}");
}

//ejercicio4
static void ejercicio4()
{
    Console.WriteLine("Escriba una palabta");
    string palabra = Console.ReadLine();

    if (Palindromo(palabra))
    {
        Console.WriteLine("La palabra es un palindromo");
    }
    else
    {
        Console.WriteLine("la palabra no es un palindromo");
    }

}

static bool Palindromo (string palabra)
{
    palabra = palabra.ToLower();
    
    for (int i = 0, j = palabra.Length -1; i < j; i++, j--)
    {
        if (palabra[i] != palabra[j])
        {
            return false;
        }
    }
    return true;
}
//static void suma()
//{
//    int n1, n2, resultado = 0;
//    Console.WriteLine("ingrese n1");
//    n1 = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("ingrese n2");
//    n2 = Convert.ToInt32(Console.ReadLine());

//    resultado = n1 + n2;

//    Console.WriteLine(resultado);
//}
//static string saludo()
//{
//    Console.WriteLine("ingrese nombre");
//    string name = Console.ReadLine();
//    return name;

//}

//static int edad()
//{
//    //ejercicio 3
//    Console.WriteLine("ingrese su ano de nacimiento");
//    int ano = Convert.ToInt32(Console.ReadLine());
//    int edad = 2024 - ano;
//    return edad;

//}

//edad();

//static int sumatoria(int num1, int num2, int num3)
//{
//    int res = 0;
//    res = num1 + num2 + num3;
//    return res;
//}

//int promedio = sumatoria(20, 25, 40) / 3;
//Console.WriteLine("promedio =: " + promedio);

//string id = saludo();
//int anos = edad();
//Console.WriteLine(anos);






