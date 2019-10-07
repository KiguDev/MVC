using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public double Precio { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
        public ICollection<OrdenProducto> Ordenes { get; set; }
    }
}
