using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;

namespace Restaurante.Infrastructure.Services
{
    public class OrdenService : IOrdenService
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
