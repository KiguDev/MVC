using System;
namespace Restaurantes.Models
{
    public class OrdenViewModel
    {
        public int Id { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaAlta { get; set; }
        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
    }
}
