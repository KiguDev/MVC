using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int RestauranteId { get; set; }

        public RestauranteViewModel Restaurante { get; set; }

    }
}
