using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
   public class Mesa
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public int Capacidad { get; set; }
        public int RestauranteId { get; set; }
        public IEnumerable<Reservacion> Reservaciones { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
