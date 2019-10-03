using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestauranteDTO
    {
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string Domicilio { get; set; }
        public int Mesas { get; set; }

        public int Telefono { get; set; }
    }
}
