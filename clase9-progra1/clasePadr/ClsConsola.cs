using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase9_progra1.claseHijo
{
    internal class ClsConsola
    {
        public int anioLanzamiento { get; set; }
        public string Marca { get; set; }

        public string MostrarDetalles()
        {
            return $"Marca: {Marca} Ano: { anioLanzamiento}";
        }
    }
}
