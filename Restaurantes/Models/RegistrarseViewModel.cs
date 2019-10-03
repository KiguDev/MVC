using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurantes.Models
{
    public class RegistrarseViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contreseña no coincide")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
