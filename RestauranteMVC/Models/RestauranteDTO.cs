using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class RestauranteDTO
    {
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public int CantidadMesas { get; set; }
    }
}
