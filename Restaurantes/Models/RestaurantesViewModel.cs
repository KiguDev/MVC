using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestaurantesViewModel
    {
        [Required(ErrorMessage = "Nombre es Requerido")]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Phone(ErrorMessage = "Ingrese un numero valido")]
        public string Telefono { get; set; }
        [Display(Name = "Página Web")]
        [Url]
        public string PaginaWeb { get; set; }
        public DateTime FechaDeAlta { get; set; }
        [Range(100,2000)]
        public int HoraDeCierre { get; set; }
        public List<int> Ordenes { get; set; }
        public bool EsEditar { get; set; }
        public int Id { get; set; }
    }
}
