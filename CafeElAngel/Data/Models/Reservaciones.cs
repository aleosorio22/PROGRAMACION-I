using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeElAngel.Data.Models
{
    internal class Reservaciones
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public DateTime FechaReservacion { get; set; }
        public TimeSpan HoraReservacion { get; set; }
        public int NumeroPersonas { get; set; }
        public string Tipo { get; set; }
        public string Notas { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string TomadaPor { get; set; }
    }
}
