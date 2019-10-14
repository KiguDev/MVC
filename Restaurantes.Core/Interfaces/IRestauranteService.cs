using System.Collections.Generic;
using Restaurantes.Core.Entities;

namespace Restaurantes.Infrastructure.Services
{
    public interface IRestauranteService
    {
        int Editar(int Id);
        int Editar(Core.Entities.Restaurante restaurante);
        void Eliminar(int id);
        void Eliminar(int[] ids);
        void EliminarVarios(int[] ids);
        int Insertar(Core.Entities.Restaurante restaurante);
        Core.Entities.Restaurante Obtener(int id);
        List<Core.Entities.Restaurante> ObtenerRestaurantes();
    }
}
