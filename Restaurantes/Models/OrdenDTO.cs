using System;
namespace Restaurantes.Models
{
    public class OrdenDTO
    {
        public int Id { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}
