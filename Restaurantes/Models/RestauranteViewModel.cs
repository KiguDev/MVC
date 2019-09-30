using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestauranteViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Nombre requerido")]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Phone]
        public int Telefono { get; set; }
        [Display(Name ="Página Web")]
        [Url]
        public string PaginaWeb { get; set; }
        public int NumeroExterior { get; set; }
        public string TipoDeComida { get; set; }
        public DateTime FechaDeAlta { get; set; }
        [Range(100,2000)]
        public int HoraDeCierre { get; set; }
        public List<int> Ordenes { get; set; }
    }
}
