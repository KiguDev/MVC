using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class ProductoDTO
    {
        public int Id;
        public string Nombre;
        public string Precio;
        public string Descripcion;
        public string Imagen;
        public int RestaurantId;

        public RestauranteViewModel Restaurante { get; set; }
    }
}
