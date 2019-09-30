using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IRestauranteService
    {
        List<Core.Entities.Restaurante> ObtenerRestaurantes();
        Entities.Restaurante Obtener(int id);
        int Agregar(Entities.Restaurante restaurante);
        void Editar(Entities.Restaurante restaurante);
        void Eliminar(Entities.Restaurante restaurante);
    }
}
