using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public int Capacidad { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
