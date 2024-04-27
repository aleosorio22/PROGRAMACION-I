using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I
{
    public class EditorCalculadora
    {
        public delegate void ejemploDelegado();
        public event ejemploDelegado ejemploEvento;

        public void SumaEv(int a, int b)
        {
            if (ejemploEvento != null)
            {
                ejemploEvento();
                Console.WriteLine("la suma es " + a + b);
            }
            else
            {
                Console.WriteLine("No esta suscritoa los eventos"); 
            }
        } 

        public void RestEv(int a, int b)
        {
            if (ejemploEvento != null) 
            {
                ejemploEvento();
                Console.WriteLine($"La resta es {a - b}");
            }
            else
            {
                Console.WriteLine("No esta suscrito a los eventos");
            }
        }
    } 

    public class SuscriptorCalculadora
    {

        private EditorCalculadora editor;
        private int A;
        private int B;
        public void ejemploEventHandler()
        {
            Console.WriteLine("La operacion sera ejecutada");
        }

        public SuscriptorCalculadora(int a, int b)
        {
            editor = new EditorCalculadora();
            A = a; 
            B = b;

            editor.ejemploEvento += ejemploEventHandler;
        }

        public void OperacionSuma()
        {
            editor.SumaEv(A, B);    
        }
        public void OperacionResta()
        {
            editor.RestEv(A, B);
        }
    }
}
