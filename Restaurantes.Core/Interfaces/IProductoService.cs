using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IProductoService
    {
        List<Entities.Producto> ObtenerProducto(int id);
        Entities.Producto Obtener(int id);

        int Insertar(Producto producto);

        void Editar(Producto producto);

        void Eliminar(int id);

        void EliminarVarios(int[] ids);

       
    }
}
