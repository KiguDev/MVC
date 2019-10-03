using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class RestauranteViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Domicilio { get; set; }
        public int NumeroExterior { get; set; }
        [Display(Name = "Pagina Web")]
        [Url]
        public string PaginaWeb { get; set; }
        [Phone]
        public string Telefono { get; set; }
        public string TipoDeComnida { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public List<int> Ordenes { get; set; }
        public string Logo { get; set; }
        public int Id { get; set; }
        public bool IsEditar { get; set; }
    }
}
