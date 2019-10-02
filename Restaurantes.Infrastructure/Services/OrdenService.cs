using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenService : IordenService
    {
        public AppDbContext _context;

        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public List<Orden> ObtenerTodo()
        {
            return _context.Ordenes.ToList();
        }
    }
}
