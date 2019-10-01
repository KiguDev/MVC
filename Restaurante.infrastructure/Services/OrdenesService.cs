using Restaurante.core.Entities;
using Restaurante.core.Interfaces;
using Restaurante.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Services
{
    public class OrdenesService : IOrdenesService
    {
        public AppDbContext _context;
        public OrdenesService(AppDbContext context)
        {
            _context = context;
        }
        public List<Orden> ObtenerTodos()
        {
            return _context.Ordenes.ToList();
        }
    }
}
