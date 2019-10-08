using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class ProductoViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int RestauranteId { get; set; }

    }
}
