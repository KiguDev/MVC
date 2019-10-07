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
        bool CerrarOrden(int id);
        bool AgregarProductoOrden(Orden orden);
        bool EliminarProductoOrden(Orden orden);
    }
}
