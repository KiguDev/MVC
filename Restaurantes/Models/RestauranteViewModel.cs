using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestauranteViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Domicilio { get; set; }
        public int NumeroExterior { get; set; }
        public string TipoDeComida { get; set; }
       
        public List<int> Ordenes { get; set; }
        
        public int Telefono { get; set; }
        public string Logo { get; set; }
        [Url]
        [Display(Name = "Página Web")]
        public string PaginaWeb { get; set; }

        public DateTime FechaAlta { get; set; }
        public int? HoraDeCierre { get; set; }

        public bool EsEditar { get; set; }
        public int Id { get; set; }
    }
}
