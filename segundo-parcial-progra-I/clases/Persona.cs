using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I.herencia
{
    internal class Persona
    {
        public string nombre { get; set; }
        public string edad {  get; set; }
        public string sexo { get; set; }
        private string color { get; set; }

        public void saludar() 
        {
            Console.WriteLine("hola");
        }

        public virtual void accionPrincipal()
        {
            Console.WriteLine("Toda persona tiene una accion principal segun su profesion.");
        }

    }
}
