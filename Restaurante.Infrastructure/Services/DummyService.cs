using Restaurante.Core.Entities;
using Restaurante.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class DummyService : IRestauranteService
    {
        public void Delete(Core.Entities.Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Edit(Core.Entities.Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public void InsertRecord(Core.Entities.Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public Core.Entities.Restaurante Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Core.Entities.Restaurante> ObtenerRestaurantes()
        {
            return new List<Core.Entities.Restaurante>
            {
                new Core.Entities.Restaurante
                {
                    Nombre = "dummy restaurante",
                    Domicilio = "dummy domicilio",
                    PaginaWeb = "www.dummy.com",
                    FechaDeAlta = DateTime.Now,
                    Telefono = "66493930",
                    Mesas = new List<Mesa>
                    {
                        new Mesa
                        {
                            Capacidad = 5,
                            
                        }
                    }
                }
            };
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
