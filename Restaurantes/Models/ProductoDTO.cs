using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
    }
}
