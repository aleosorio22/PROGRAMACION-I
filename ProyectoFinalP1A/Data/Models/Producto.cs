using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalP1A.Data.Models
{
    internal class Producto
    {
        public int id { get; set; }
        public string nombreProducto { get; set; }
        public string categoria { get; set;}
        public string areaProduccion { get; set;}
        public decimal precio { get; set;}
        public bool estado { get; set;}
        public string descripcion { get; set;}
        public DateTime fechaCreacion { get; set;}

    }
}
