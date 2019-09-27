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
    }
}
