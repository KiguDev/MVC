using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static void Seed(AppDbContext catalogContext)
        {
            if (!catalogContext.Restaurantes.Any())
            {
                catalogContext.Add(new Restaurante.Core.Entities.Restaurante
                {
                    Nombre="Restaurante Maestro",
                    Domicilio="Ave. Prueba 123",
                    Telefono = 664,
                    HoraCierre = 10


                });

                catalogContext.SaveChanges();
            }

            if (!catalogContext.Ordenes.Any())
            {
                catalogContext.Add(new Restaurante.Core.Entities.Orden
                {
                    Estatus = (int)OrdenEstatus.Pendiente,
                    RestauranteId = 1,
                    FechaAltra = DateTime.Now
                });
            }
        }
    }
}
