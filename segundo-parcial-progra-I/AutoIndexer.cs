using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segundo_parcial_progra_I
{
    public class AutoIndexer
    {
        double costo;
        double tenencia;
        string modelo;

        public AutoIndexer(string Modelo, double pCosto)
        { 
            costo = pCosto;
            modelo = Modelo;
        }

        public void MostrarInformacionAuto()
        {
            Console.WriteLine("Tu automovil {0}", modelo);
            Console.WriteLine("tiene un costo de {0}", costo);
        }
    }
}
