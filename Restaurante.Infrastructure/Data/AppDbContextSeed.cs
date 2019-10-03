using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Restaurantes.Any())
            {
                context.Add(new Core.Entities.Restaurante
                {
                    Nombre = "Restaurante Maestro",
                    Domicilio = "Ave. Prueba 134",
                    Telefono = "456456456",
                    Logo = "www.logo.com",
                    FechaDeAlta = DateTime.Now,
                    PaginaWeb = "www.restaurante.com",
                });
                context.SaveChanges();
                //Agregar ordenes
            }
            if (!context.Ordenes.Any())
            {
                context.Ordenes.AddRange(
                    new Orden()
                    {
                        Estatus = 1,
                        FechaAlta = DateTime.Now,
                        RestauranteId = 1,
                        Total = 200
                    },
                    new Orden
                    {
                        Estatus = 2,
                        FechaAlta = DateTime.Now,
                        RestauranteId = 1,
                        Total = 100
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
