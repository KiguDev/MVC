using Restaurante.Core.Entities;
using Restaurante.core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Restaurante.infrastructure.Services
{
    public class MesasService : IMesasService
    {
        public AppDbContext _context;
        public MesasService(AppDbContext context)
        {
            _context = context;
        }

        public int EditarMesa(Core.Entities.Mesa mesa)
        {
            _context.Update(mesa);
            _context.SaveChanges();
            return mesa.Id;
        }

        public bool EliminarMesa(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(c => c.Id == id);
            _context.Remove(mesa);
            _context.SaveChanges();
            return true;
        }

        public int InsertarMesa(Core.Entities.Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa.Id;
        }

        public Mesa Obtener(int id)
        {
            return _context.Mesas.FirstOrDefault(c => c.Id == id);
        }

        public List<Core.Entities.Mesa> ObtenerMesas(int id)
        {
            return _context.Mesas.Where(c => c.RestauranteId == id).ToList();
        }
    }
}
