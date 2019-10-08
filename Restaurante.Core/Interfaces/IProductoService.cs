using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IProductoService
    {
        List<Producto> ObtenerProductos(int id);
        Producto Obtener(int id);
        int Agregar(Producto producto);
        void Editar(Producto producto);
        void Eliminar(Producto producto);
        
    }
}
