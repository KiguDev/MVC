using System;
using System.Collections.Generic;

namespace Restaurantes.Core.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrdenTieneProducto> Productos { get; set; }
        public Restaurante Restaurante { get; set; }
        public Empleado Empleado { get; set; }
    }
}
