using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IProductoService
    {
        List<Entities.Producto> ObtenerProductos(int id);
        Entities.Producto Obtener(int id);

        int insertar(Restaurante.Core.Entities.Producto producto);

        void Editar(Restaurante.Core.Entities.Producto producto);

        void Eliminar(int id);
        void EliminarVarios(int[] ids);
    }
}
