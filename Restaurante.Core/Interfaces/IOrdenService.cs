using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IOrdenService
    {
        List<Entities.Orden> ObtenerOrdenes(int id);
        Entities.Orden Obtener(int id);

        int insertar(Restaurante.Core.Entities.Orden orden);

        void Editar(Restaurante.Core.Entities.Orden orden);

        void Eliminar(int id);

        List<Entities.Orden> ObtenerTodas();
    }
}
