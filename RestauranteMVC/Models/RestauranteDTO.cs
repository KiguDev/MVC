using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class RestauranteDTO
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string PaginaWeb { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int? HoraDeCierre { get; set; }
        public int Telefono { get; set; }
        public int CantidadMesas { get; set; }
        public int CantidadEmpleados { get; set; }
    }
}
