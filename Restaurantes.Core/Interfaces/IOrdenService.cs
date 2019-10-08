using System;
using System.Collections.Generic;
using Restaurantes.Core.Entities;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenService
    {
        List<Orden> ObtenerOrdenes(int id);
        Orden Obtener(int id);
        int Agregar(Orden orden);
        void Editar(Orden orden);
        void CerrarOrden(int id);
    }
}
