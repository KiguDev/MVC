using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class MesasService : IMesasService
    {
        public AppDbContext _context;

        public MesasService(AppDbContext context)
        {
            _context = context;
        }

        public List<Mesa> ObtenerMesas()
        {
            return _context.Mesas.ToList();
        }
        public Mesa Obtener(int id)
        {
            return _context.Mesas.FirstOrDefault(c => c.Id == id);
        }

        public int Agregar(Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa.Id;
        }

        public void Editar(Mesa mesa)
        {
            _context.Update(mesa);
            _context.SaveChanges();
        }
        public void Eliminar(Mesa mesa)
        {
            _context.Remove(mesa);
            _context.SaveChanges();
        }
    }
}
