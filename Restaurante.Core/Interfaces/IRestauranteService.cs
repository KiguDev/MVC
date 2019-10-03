using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Interfaces
{
    public interface IRestauranteService
    {
        List<Core.Entities.Restaurante> ObtenerRestaurantes();
        Core.Entities.Restaurante Obtener(int id);
        void InsertRecord(Core.Entities.Restaurante restaurante);
        void SaveChanges();
        void Edit(Core.Entities.Restaurante restaurante);
        void Delete(Core.Entities.Restaurante restaurante);
        void Delete(List<int> ids);
    }
}
