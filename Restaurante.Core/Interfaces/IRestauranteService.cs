using System.Collections.Generic;

namespace Restaurante.Core.Interfaces
{
    public interface IRestauranteService
    {
        List<Entities.Restaurante> ObtenerRestaurantes();
        Entities.Restaurante Obtener(int id);

        int Insertar(Core.Entities.Restaurante restaurante);
        void Editar(Core.Entities.Restaurante restaurante);
        void Eliminar(Core.Entities.Restaurante restaurante);
    }
}
