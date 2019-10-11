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

        public bool EditarOrden(Orden orden)
        {
            var ordenAEditar = _context.Ordenes.First(c => c.Id == orden.Id);
            ordenAEditar.Total = orden.Total;
            _context.Update(ordenAEditar);
            _context.SaveChanges();
            return true;
        }

        public bool EditarProductoOrden(OrdenProducto orden)
        {
            var ordenProducto = _context.OrdenProducto.FirstOrDefault(c => c.ProductoId == orden.ProductoId && c.OrdenId == orden.OrdenId);
            ordenProducto.Cantidad = orden.Cantidad;
            ordenProducto.SubTotal = orden.SubTotal;
            _context.Update(ordenProducto);
            _context.SaveChanges();
            return true;
        }

        /*public bool EliminarProductoOrden(int[] ids)
        {
            throw new NotImplementedException();
        }*/

        public bool EliminarProductosOrden(int[] ids, int ordenId)
        {
            _context.RemoveRange(_context.OrdenProducto.Where(c => ids.Contains(c.ProductoId) && c.OrdenId == ordenId));
            _context.SaveChanges();
            return true;
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

        public List<OrdenProducto> ObtenerProductoOrden(int ordenId)
        {
            return _context.OrdenProducto.Where(c => c.OrdenId == ordenId).ToList();
        }

        public List<Orden> ObtenerTodas(int id)
        {
            return _context.Ordenes.Where(c => c.RestauranteId == id).ToList();
        }
    }
}
