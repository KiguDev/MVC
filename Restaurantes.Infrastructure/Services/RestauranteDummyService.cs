using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class RestauranteDummyService : IRestauranteService
    {
        public int Agregar(Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public void Editar(Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int[] ids)
        {
            throw new NotImplementedException();
        }

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
