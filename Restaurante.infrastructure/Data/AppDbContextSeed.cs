using Restaurante.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static void Seed(AppDbContext catalogContext)
        {
            if (!catalogContext.Restaurantes.Any())
            {
                catalogContext.Add(new Restaurante.core.Entities.Restaurante
                {
                    Nombre = "Restaurante Maestro",
                    Domicilio = "Blv. Cucapah 20129",
                    Telefono = 101010,
                    Logo = "...",
                    PaginaWeb = "www.rmaestro.com",
                    FechaDeAlta = DateTime.Now,
                    HoraDeCierre = 19
                });

                catalogContext.SaveChanges();
            }

            if (!catalogContext.Ordenes.Any())
            {
                catalogContext.AddRange(new List<Orden> {
                        new Orden
                        {
                            Estatus = (int) OrdenEstatus.Pendiente,
                            RestauranteId = 1,
                            FechaDeAlta = DateTime.Now,
                            Total = 0
                        }, new Orden
                        {
                            Estatus = (int) OrdenEstatus.Pendiente,
                            RestauranteId = 1,
                            FechaDeAlta = DateTime.Now,
                            Total = 1000
                        }
                    });
                catalogContext.SaveChanges();
            }
        }
    }
}
