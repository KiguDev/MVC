using System;
namespace Restaurantes.Models
{
    public class OrdenTieneProductoViewModel
    {
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
