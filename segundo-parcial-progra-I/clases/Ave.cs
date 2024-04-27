using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I.clases
{
    internal class Ave : Animal, Volador
    {
        public void volar()
        { 
            Console.WriteLine("aletea");
        }
    }
}
