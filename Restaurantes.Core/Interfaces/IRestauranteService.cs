using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IRestauranteService
    {
        List<Restaurante> ObtenerRestaurantes();
        Restaurante Obtener(int id);
        int Agregar(Restaurante restaurante);
        void Editar(Restaurante restaurante);

        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}
