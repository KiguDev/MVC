using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class MesaDTO
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public int RestauranteId { get; set; }
        public int Capacidad { get; set; }
    }
}
