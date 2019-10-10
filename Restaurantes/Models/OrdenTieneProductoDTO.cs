using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class OrdenTieneProductoDTO
    {
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
