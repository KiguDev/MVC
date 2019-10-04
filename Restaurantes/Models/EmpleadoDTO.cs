using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class EmpleadoDTO
    {
        public string Nombre { get; set; }
        public int RestauranteId { get; set; }
        public string Puesto  { get; set; }
        public int Id { get; set; }
    }   
}
