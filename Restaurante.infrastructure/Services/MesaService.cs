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
    public class MesaService : IMesaService
    {
        public AppDbContext _context;

        public MesaService(AppDbContext context)
        {
            _context = context;
        }

        public void Editar(Mesa mesa)
        {
            _context.Update(mesa);
            _context.SaveChanges();
        }

        public void Eliminar(Mesa Mesa)
        {
            _context.Mesas.Remove(Mesa);
            _context.SaveChanges();
        }

        public int Insertar(Mesa mesa)
        { 
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa.Id;
        }

        public Core.Entities.Mesa Obtener(int id)
        {
            return _context.Mesas.FirstOrDefault(c => c.Id == id);

        }

        public List<Core.Entities.Mesa> ObtenerMesas()
        {
            return _context.Mesas.Include(c => c.Restaurante).ToList();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Mesas.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }
    }
}
