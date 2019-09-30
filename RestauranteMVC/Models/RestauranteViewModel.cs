using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class RestauranteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        [Required]
        public string Domicilio { get; set; }
        
        public int Telefono { get; set; }
        public string Logo { get; set; }
        [Display(Name = "Página Web")]
        [Url]
        public string PaginaWeb { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int HoraDeCierre { get; set; }
        public List<int> Ordenes { get; set; }
        public bool EsEditar { get; set; }
    }
}
