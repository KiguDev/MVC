using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class OrdenesViewModel
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Estatus { get; set; }
        public double Total { get; set; }
    }
}
