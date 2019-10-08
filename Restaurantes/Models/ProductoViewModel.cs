using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurantes.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public int RestauranteId { get; set; }
    }
}
