using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IRestauranteService
    {
        
        List<Entities.Restaurante> ObtenerRestaurante();
        Entities.Restaurante Obtener(int id);
        int InsertarRestaurante(Entities.Restaurante restaurante);
        int EditarRestaurante(Entities.Restaurante restaurante);
        bool EliminarRestaurante(int id);
    }
}
