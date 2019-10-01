using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Entities
{
    public class OrdenProducto
    {
        public int OrdenId { get; set; }
        public Ordenes Ordenes { get; set; }
        public int ProductoId { get; set; }
        public Productos Productos { get; set; }
        public int Cantidad { get; set; }
    }
}
