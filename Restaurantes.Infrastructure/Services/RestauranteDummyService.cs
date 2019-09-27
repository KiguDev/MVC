using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class RestauranteDummyService : IRestauranteService
    {
        public Restaurante Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Restaurante> ObtenerRestaurantes()
        {
            return new List<Restaurante> {
                new Restaurante{Nombre = "Mario's Pizza", Domicilio = "Avev. Prueba 123"}
            };
        }
    }
}
