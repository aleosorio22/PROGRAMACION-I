using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I.herencia
{
    internal class Policia : Persona
    {
        public string rango {  get; set; }

        public override void accionPrincipal()
        {
            Console.WriteLine("Arrestar");
        }
    }
}
