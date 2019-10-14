using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Core.Entities;
namespace Restaurante.Core.Interfaces
{
    public interface IRestauranteService
    {
        List<Entities.Restaurante> ObtenerRestaurantes();
        Entities.Restaurante Obtener(int id);

        int insertar(Restaurante.Core.Entities.Restaurante restaurante);

        void Editar(Restaurante.Core.Entities.Restaurante restaurante);

        void Eliminar(int id);

        void EliminarVarios(int[] ids);
    }
}
