using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenService
    {
        List<Restaurantes.Core.Entities.Orden> ObtenerOrdenes(int id);
        Restaurantes.Core.Entities.Orden Obtener(int id);

        int insertar(Restaurantes.Core.Entities.Orden orden);

        void Editar(Restaurantes.Core.Entities.Orden orden);

        void Eliminar(int id);

        List<Restaurantes.Core.Entities.Orden> ObtenerTodas();

    }
}
