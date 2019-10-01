using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class RestauranteDTO
    {
        [JsonProperty("NombreRestaurante")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int CantidadMesas { get; set; }
    }
}
