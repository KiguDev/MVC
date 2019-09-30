using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static void Seed(AppDbContext catalogContext)
        {
            if (!catalogContext.Restaurantes.Any())
            {
                catalogContext.Add(new Restaurante.Core.Entities.Restaurante
                {
                    Nombre = "Restaurante Maestro",
                    Domicilio = "Ave. Prueba 123",
                    Telefono = 4424392,
                    PaginaWeb = "https://www.haosua.com",
                    Logo = "Logo.jpg",
                    FechaDeAlta = DateTime.Now

                });

                catalogContext.SaveChanges();
            }
        }
    }
}
