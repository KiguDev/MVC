using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestauranteViewModel
    {
        [Required(ErrorMessage ="Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Direccion es requerida")]
        public string Direccion { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [Display(Name = "Página Web")]
        [Url]
        public string PaginaWeb { get; set; }
        public string Logo { get; set; }
        [Range(0, 23)]
        public int HoraDeCierre { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public List<int> Ordenes { get; set; }
        public bool EsEditar { get; set; }
        public int Id { get; set; }
    }
}
