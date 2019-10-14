using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
   public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RestauranteId { get; set; }
        public Puesto Puesto { get; set; }
        public Restaurante Restaurante { get; set; }
        public IEnumerable<Venta> Ventas { get; set; }
    }


    public enum Puesto
    {
        Cajero,
        Mesero,
        Gerente,
        Cocinero,
        Ayudante,
        Seguridad,
        Limpieza
    }
}
