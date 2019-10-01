using Restaurante.Core.Entities;
using Restaurante.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Services
{
    public class OrdenService : IOrdenService
    {
        public AppDbContext _context;

        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public List<Ordenes> ObtenerTodo()
        {
            return _context.Ordenes.ToList();
        }
    }
}
