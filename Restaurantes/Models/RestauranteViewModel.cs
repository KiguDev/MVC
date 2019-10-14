﻿using System;
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

        [Required]
        public string Direccion { get; set; }

       // [Phone]
        public int Telefono { get; set; }

        [Display(Name =  "Logo")]
        [Url]
        public string Logo { get; set; }

        [Url]
        public string PaginaWeb { get; set; }

        [Range(10, 20000)]
        public int HoraCierre { get; set; }

        public DateTime FechaAlta { get; set; }
        public List<int> Ordenes { get; set; }
        public bool EsEditar { get; set; }
        public int Id { get; set; }
    }
}
