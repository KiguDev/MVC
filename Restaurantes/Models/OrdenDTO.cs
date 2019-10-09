using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class OrdenDTO
    {
        public int Id { get; set; }
        public int Productos { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Estatus { get; set; }
        public decimal Total { get; set; }

    }
}
