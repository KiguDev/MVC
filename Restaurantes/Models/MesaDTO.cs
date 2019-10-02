using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class MesaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Identificador requerido")]
        public string Identificador { get; set; }
        [Required]
        public int Capacidad { get; set; }
        public int RestauranteId { get; set; }
    }
}
