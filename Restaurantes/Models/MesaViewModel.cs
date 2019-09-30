using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class MesaViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Identificador { get; set; }
        [Required]
        public int Capacidad { get; set; }
        public int RestauranteId { get; set; }
        public string Restaurante { get; set;  }
    }
}
