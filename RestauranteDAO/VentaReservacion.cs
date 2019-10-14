using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
   public class VentaReservacion
    {
        public int VentaId { get; set; }
        public int ReservacionId { get; set; }

        public Venta Venta { get; set; }
        public Reservacion Reservacion { get; set; }
    }
}
