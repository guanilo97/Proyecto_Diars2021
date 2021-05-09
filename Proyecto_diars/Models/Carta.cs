using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_diars.Models
{
    public class Carta
    {
        public int Id_carta { get; set; }
        public string categoria { get; set; }
        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        //public Reserva reserva { get; set; }
    }
}
