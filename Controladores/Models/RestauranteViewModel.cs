using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controladores.Models
{
    public class RestauranteViewModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int NumeroExterior { get; set; }
        public string TipoDeComida { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public List<int> Ordenes { get; set; }
    }
}
