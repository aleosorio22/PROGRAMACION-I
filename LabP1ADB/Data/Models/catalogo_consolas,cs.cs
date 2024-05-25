using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabP1ADB.Data.Models
{
    internal class catalogo_consolas_cs
    {
        public int IdConsola { get; set; }
        public string NombreConsola { get; set; }
        public string Compania { get; set; }
        public int AnioLanzamiento { get; set; }
        public byte Generacion { get; set; }
    }
}
