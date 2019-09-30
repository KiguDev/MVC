using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class EmpleadoViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int RestauranteId { get; set; }
        [Required]
        public int Puesto { get; set; }
    }
}
