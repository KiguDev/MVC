using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class RestauranteDummyService : IRestauranteService
    {
        public int Agregar(Core.Entities.Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public void Editar(Core.Entities.Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public Restaurante Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Core.Entities.Restaurante> ObtenerRestaurantes()
        {
            return new List<Restaurante> {
                new Restaurante{Nombre = "Mario's Pizza", Domicilio = "Avev. Prueba 123"}
            };
        }
    }
}
