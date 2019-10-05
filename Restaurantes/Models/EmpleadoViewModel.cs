﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurantes.Models
{
    public class EmpleadoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Puesto { get; set; }
        public int RestauranteId { get; set; }
    }
}
