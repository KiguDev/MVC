using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Entities
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public int Cantidad { get; set; }
        public ICollection<OrdenProducto> Ordenes { get; set; }
    }
}
