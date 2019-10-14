using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class ProductosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
