using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Entities
{
    public class OrdenTieneProducto
    {
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
