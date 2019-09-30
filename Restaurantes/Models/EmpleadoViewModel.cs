using Restaurante.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class EmpleadoViewModel
    {
        [Required]
        public string Nombre { get; set; }
        public int Id { get; set; }
        [Required]
        public string Puesto { get; set; }
        public int RestauranteId { get; set;  }
        
    }
}
