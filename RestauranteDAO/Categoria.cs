using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
   public class Categoria
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int RestauranteId { get; set; }  
        public Restaurante Restaurante { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
    }
}
