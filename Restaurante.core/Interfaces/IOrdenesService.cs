using Restaurante.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IOrdenesService
    {
        List<Orden> ObtenerTodas(int id);
        Entities.Orden Obtener(int id);
        int InsertaOrden(Entities.Orden orden);
        bool EditarOrden(Entities.Orden orden);
        bool CambiarEstatus(int id);
        bool AgregarProductoOrden(OrdenProducto orden);
        bool EditarProductoOrden(OrdenProducto orden);
        bool EliminarProductosOrden(int[] ids, int ordenId);
        List<OrdenProducto> ObtenerProductoOrden(int ordenId);
    }
}
