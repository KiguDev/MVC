using Restaurantes.Core.Entities;
using System.Collections.Generic;

namespace Restaurantes.Infrastructure.Services
{
    public interface IProductoService
    {
        List<OrdenTieneProducto> ObtenerProductosOrden(int OrdenId);
        List<Producto> ObtenerProductosRestaurante(int ResId);
        Producto Obtener(int id);
        int Agregar(Producto producto);
        void Editar(Producto producto);
        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}
