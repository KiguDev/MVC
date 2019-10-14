using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string DireccionFiscal { get; set; }
        public string Telefono { get; set; }

        public IEnumerable<Reservacion> Reservaciones { get; set; }
        public IEnumerable<VentaCliente> Ventas { get; set; }   
    }
}
