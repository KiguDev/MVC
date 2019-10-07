using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class OrdenService : IOrdenService
    {
        public AppDbContext _context;
        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public void Editar(Orden orden)
        {
            _context.Update(orden);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var orden = _context.Ordenes.FirstOrDefault(o => o.Id == id);
            _context.Remove(orden);
            _context.SaveChanges();
        }

        public int Insertar(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public Orden Obtener(int id)
        {
            return _context.Ordenes.FirstOrDefault(o => o.Id == id);
        }

        public List<Orden> ObtenerOrdenes(int id)
        {

            var ordenes = _context.Ordenes.Where(o => o.RestauranteId == id).ToList();
            return ordenes;
        }

        public List<Orden> ObtenerTodas()
        {
            var ordenes = _context.Ordenes.ToList();
            return ordenes;
        }

        public List<Orden> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}