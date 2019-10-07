using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IProductosService
    {
        List<Entities.Producto> ObtenerProducto(int id);
        Entities.Producto Obtener(int id);
        int InsertarProducto(Entities.Producto producto);
        int EditarProducto(Entities.Producto producto);
        bool EliminarProducto(int id);
        bool EliminarProductos(int[] ids);
    }
}
