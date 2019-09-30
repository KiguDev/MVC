using System;
using System.Collections.Generic;
using System.Text;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenService : IOrdenService
    {
        //Se declara el contexto
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
