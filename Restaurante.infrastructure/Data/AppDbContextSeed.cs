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
                    Logo = "https://i.imgur.com/0AviX1l.png",
                    PaginaWeb = "https://www.restaurantemaster.com",
                    HoraDeCierre = 22


                });

                catalogContext.SaveChanges();
            }

            if (!catalogContext.Ordenes.Any())
            {
                catalogContext.Add(new Restaurante.Core.Entities.Orden
                {
                    Estatus = (int)OrdenEstatus.Pendiente,
                    RestauranteId = 1,
                    FechaAlta = DateTime.Now
                });
            }
        }
    }
}
