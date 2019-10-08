using System;
namespace Restaurantes.Models
{
    public class OrdenDTO
    {
        public int Id { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
        public int Productos { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
