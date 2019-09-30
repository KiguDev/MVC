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
                catalogContext.Add(new Core.Entities.Restaurante {
                    Nombre = "Restaurante Maestro",
                    Domicilio = "Ave. Prueba 123",
                    FechaDeAlta = DateTime.Now,
                    PaginaWeb = "www.Maestro.com",
                    Logo = "Imagen.Jpg",
                    Id = 0,
                    Telefono = 664529,
                    HoraDeCierre = DateTime.Today.Hour
                    
                
                });
                catalogContext.SaveChanges();
            }
        }
    }
}
