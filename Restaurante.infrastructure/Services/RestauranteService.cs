using Microsoft.EntityFrameworkCore;
using Restaurante.core.Entities;
using Restaurante.core.Interfaces;
using Restaurante.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Services
{
    public class RestauranteService : IRestauranteService
    {
        public AppDbContext _context;
        public  RestauranteService (AppDbContext context)
        {
            _context = context;
        }

        public int EditarRestaurante(core.Entities.Restaurante restaurante)
        {
            _context.Update(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        public bool EliminarRestaurante(int id)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(c => c.Id == id);
            _context.Remove(restaurante);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarRestaurantes(int[] ids)
        { 
            _context.RemoveRange(_context.Restaurantes.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
            return true;
        }

        public int InsertarRestaurante(core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        public core.Entities.Restaurante Obtener(int id)
        {
            return _context.Restaurantes.Include(c => c.mesas).Include(d => d.empleados).FirstOrDefault(c => c.Id == id);
        }

        public List<core.Entities.Restaurante> ObtenerRestaurante()
        {
            return _context.Restaurantes.Include(c => c.mesas).Include(d => d.empleados).ToList();
        }
    }
}
