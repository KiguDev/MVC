using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Entities
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
        public string Logo { get; set; }
        public string PaginaWeb { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int? HoraDeCierre { get; set; }
        public ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    }
}
