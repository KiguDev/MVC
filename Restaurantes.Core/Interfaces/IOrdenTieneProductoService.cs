using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenTieneProductoService
    {
        List<OrdenTieneProducto> ObtenerOrdenTieneProductos(int id);
        OrdenTieneProducto Obtener(int id);
        int Agregar(OrdenTieneProducto ordenTieneProducto);
        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}
