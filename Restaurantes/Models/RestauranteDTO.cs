using System;
using Newtonsoft.Json;

namespace Restaurantes.Models
{
    public class RestauranteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
        public int Mesas { get; set; }
        public int Empleados { get; set; }
        public int Productos { get; set; }
    }
}
