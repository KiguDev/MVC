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
        int EditarOrden(Entities.Orden orden);
        bool CambiarEstatus(int id);
        bool AgregarProductoOrden(OrdenProducto orden);
        bool EliminarProductoOrden(OrdenProducto orden);
    }
}
