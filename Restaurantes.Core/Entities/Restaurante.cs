using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Entities
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
        public string Logo { get; set; }
        public string PaginaWeb { get; set; }

        public DateTime FechaAlta { get; set; }
        public int? HoraCierre { get; set; }

        public ICollection<Mesa> Mesas { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
