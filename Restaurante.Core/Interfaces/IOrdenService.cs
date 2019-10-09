using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IOrdenService
    {
        List<Orden> ObtenerOrdenes(int id);
        Orden Obtener(int id);
        int Agregar(Orden orden);
        void Editar(Orden orden);
        void Eliminar(Orden orden);
    }
}
