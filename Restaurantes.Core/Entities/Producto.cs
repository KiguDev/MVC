using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int CategoriaId{ get; set; }
        public int Categoria { get; set; }
        public List<Restaurante>  RestauranteId {get; set;}
        public ICollection<OrdenTieneProducto> Ordenes { get; set; }
        public object Restaurante { get; set; }

        
    }
}
