using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrdenProducto> Productos { get; set; }
    }

    public enum OrdenEstatus
    {
        Pendiente,
        Cocinando,
        Enviado,
        Entregado
    }
}
