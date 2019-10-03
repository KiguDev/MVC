using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="El usuario/correo es requerido")]
        [EmailAddress(ErrorMessage ="Correo no valido")]
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }
}
