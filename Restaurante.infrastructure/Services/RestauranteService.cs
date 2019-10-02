using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
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

        public RestauranteService(AppDbContext context)
        {
            _context = context;
        }
        public Core.Entities.Restaurante Obtener(int id)
        {
            return _context.Restaurantes.FirstOrDefault(c => c.Id == id);

        }

        public List<Core.Entities.Restaurante> ObtenerRestaurantes()
        {
            return _context.Restaurantes.Include(c => c.Mesas).ToList();
        }

        public int Insertar(Core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        public int Editar(Core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

     

        void IRestauranteService.Editar(Core.Entities.Restaurante restaurante)
        {
            _context.Update(restaurante);
            _context.SaveChanges();
        }

        public void Eliminar(Core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Remove(restaurante);
            _context.SaveChanges();
            
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Restaurantes.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }
    }
}
