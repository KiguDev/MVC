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

        public bool AgregarProductoOrden(OrdenProducto orden)
        {
            _context.OrdenProducto.Add(orden);
            _context.SaveChanges();
            return true;
        }

        public bool CambiarEstatus(int id)
        {
            var ordenA = _context.Ordenes.FirstOrDefault(c => c.Id == id);
            if (ordenA.Estatus == 0)
            {
                ordenA.Estatus = 1;
            }
            else
            {
                ordenA.Estatus = 0;
            }
            
            _context.Update(ordenA);
            _context.SaveChanges();

            return true;
        }

        public int EditarOrden(Orden orden)
        {
            _context.Update(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public bool EliminarProductoOrden(OrdenProducto orden)
        {
            throw new NotImplementedException();
        }

        public int InsertaOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public Orden Obtener(int id)
        {
            return _context.Ordenes.FirstOrDefault(c => c.Id == id);
        }

        public List<Orden> ObtenerTodas(int id)
        {
            return _context.Ordenes.Where(c => c.RestauranteId == id).ToList();
        }
    }
}
