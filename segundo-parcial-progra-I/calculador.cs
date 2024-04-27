delegate int calculador(int number);

namespace segundo_parcial_progra_I
{
    public class Calculadora
    {
        static int number = 0;
        static int Sumar(int number)
        {
            Calculadora.number += number ;
            return Calculadora.number;
        }

        static int Multiplicar (int number)
        {
            Calculadora.number *= number ;
            return Calculadora.number;
        }
    }
}