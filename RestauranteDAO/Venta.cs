using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
   public class Venta
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int RestauranteId { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public int? Mesa { get; set; }  //Valor opcional
        public TipoVenta TipoVenta { get; set; }
        public EstadoVenta EstadoVenta { get; set; }
        public IEnumerable<VentaProducto> Productos { get; set; }
        public Empleado Cajero { get; set; }
        public IEnumerable<VentaCliente> VentasFacturadas { get; set; }
    }

    public enum TipoVenta {
        OnSite,
        PickAndGo,
        Delivery
    }

    public enum EstadoVenta { 
        Abierta, 
        Finalizada,
        Cancelada
    }


}
