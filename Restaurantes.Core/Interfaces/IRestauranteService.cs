using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IRestauranteService
    {
        
        List<Restaurante.Core.Entities.Restaurante> ObtenerRestaurante();
        Restaurante.Core.Entities.Restaurante Obtener(int id);
        int InsertarRestaurante(Restaurante.Core.Entities.Restaurante restaurante);
        int EditarRestaurante(Restaurante.Core.Entities.Restaurante restaurante);
        bool EliminarRestaurante(int id);
    }
}
