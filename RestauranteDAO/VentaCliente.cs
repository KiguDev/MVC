using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
    public class VentaCliente
    {

        public int ClienteId { get; set; }
        public int VentaId { get; set; }

        public Venta Venta { get; set; }
        public Cliente Cliente { get; set; }

    }
}
