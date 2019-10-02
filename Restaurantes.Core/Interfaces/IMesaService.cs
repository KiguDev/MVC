using Restaurantes.Core.Entities;
using System.Collections.Generic;

namespace Restaurantes.Infrastructure.Services
{
    public interface IMesaService
    {
        List<Mesa> ObtenerMesas();
        Mesa Obtener(int id);
        int Agregar(Mesa mesa);
        void Editar(Mesa mesa);

        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}
