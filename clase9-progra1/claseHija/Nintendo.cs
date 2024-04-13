using clase9_progra1.claseHijo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase9_progra1.claseHija
{
    internal class Nintendo:ClsConsola
    {
        public bool esPortable {  get; set; }

        public string MostrarDetalleNintendo()
        {
            string detallePadre = MostrarDetalles();
            return detallePadre + "Es portable:" + esPortable;
        }
    }
}
