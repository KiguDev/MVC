using System;
using System.Collections.Generic;
using Restaurantes.Core.Entities;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenTieneProductoService
    {
        List<OrdenTieneProducto> ObtenerOrdenTieneProducto(int id);
        OrdenTieneProducto Obtener(int ordenId, int productoId);
        void Agregar(OrdenTieneProducto ordenTieneProducto);
        void Editar(OrdenTieneProducto ordenTieneProducto);
        void Eliminar(OrdenTieneProducto ordenTieneProducto);
    }
}
