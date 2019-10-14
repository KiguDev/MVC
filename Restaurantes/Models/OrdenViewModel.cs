using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class OrdenViewModel
    {
        public int Id { get; set; }

        public int EmpleadoId { get; set; }
        public int RestauranteId { get; set; }
      
        public string FechaAlta { get; set; }

        public int Estatus { get; set; }
        public decimal Total { get; set; }
       public int cantidadP { get; set; }
    }
}
