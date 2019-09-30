using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public ICollection<Producto> Producto { get; set; }
        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }

    }

    public enum OrdenEstatus
    {
        Pendiente,
        Cocinando,
        Enviado,
        Entregado
    }
}
