using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    public class OrdenViewModel
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }
    }
}
