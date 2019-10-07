using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RestauranteId { get; set; }
        public string Ingredientes { get; set; }
        public double Precio { get; set; }
    }
}
