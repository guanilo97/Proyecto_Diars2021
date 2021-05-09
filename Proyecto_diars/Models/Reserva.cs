using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_diars.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public  TimeSpan Hora { get; set; }
        public int N_personas { get; set; }

        public string Mesa { get; set; }
        public int Cartaid { get; set; }
        public Carta cartass { get; set; }

    }
}
