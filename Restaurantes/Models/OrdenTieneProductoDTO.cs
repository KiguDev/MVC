using System;
namespace Restaurantes.Models
{
    public class OrdenTieneProductoDTO
    {
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
