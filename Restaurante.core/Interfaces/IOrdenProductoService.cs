using Restaurante.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IOrdenProductoService
    {
        List<OrdenProducto> ObtenerTodas(int id);
        Entities.OrdenProducto Obtener(int id);
        int InsertaOrdenProducto(Entities.OrdenProducto orden);
        int EditarOrdenProducto(Entities.OrdenProducto orden);
        bool AgregarProductoOrden(OrdenProducto orden);
        bool EliminarProductoOrden(OrdenProducto orden);
    }
}
