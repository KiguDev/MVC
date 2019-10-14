using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Models
{
    public class OrdenDTO
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public int RestaurantId { get; set; }
   
      
        public int EmpleadoId { get; set; }
     
        public DateTime Fecha { get; set; }
        public virtual ICollection<ProductoDTO> Productos { get; set; }
    }
}
