using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I
{
    delegate void Imprimir(string cadena);
    delegate void DelegadoString(string texto);
    delegate void DelegadoInt(int a, int b);
    delegate void DecirHola(string  saludo);

    public class delegates
    {
        //del 1
        public void ImprimirPantalla(string v)
        {
            Console.WriteLine(v);
        }

        public void ejemploDelegado()
        {
            Imprimir ImprimirDel = new Imprimir(ImprimirPantalla);
            ImprimirDel("ejemplo delegado");
        }
        
        //del 2
        public void ImprimirMensaje2(string mensaje)
        {
            Console.WriteLine("El mensaje es:" + mensaje);
        }

        //del3

        public  void Sumar(int a, int b)
        {
            int resultado = a + b;  
            Console.WriteLine($"El resultado de {a} + {b} es: {resultado}");
        }

        public  void Restar(int a, int b) 
        {
            int resultado = a - b;
            Console.WriteLine($"El resultado de {a} - {b} es: {resultado}");
        }

        //del4
        public void SaludarPorNombre(string nombre)
        {
            Console.WriteLine("Hola, como estas, " + nombre);
        }
    }
}
