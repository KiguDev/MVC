using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public int RestauranteId { get; set; }
        public string Puesto { get; set; }
    }
}
