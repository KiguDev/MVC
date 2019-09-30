using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Entities
{
    public class OrdenProducto
    {
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
