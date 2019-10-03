using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurantes.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name ="¿Recordar contraseña?")]
        public bool RememberMe { get; set; }
    }
}
