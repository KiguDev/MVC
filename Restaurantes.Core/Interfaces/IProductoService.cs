using System;
using System.Collections.Generic;
using Restaurantes.Core.Entities;

namespace Restaurantes.Core.Interfaces
{
    public interface IProductoService
    {
        List<Producto> ObtenerProductos(int id);
        Producto Obtener(int id);
        int Agregar(Producto producto);
        void Editar(Producto producto);
        void Eliminar(Producto producto);
        void Eliminar(int[] ids);
    }
}
