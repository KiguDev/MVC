using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenTieneProductoService : IOrdenTieneProductoService
    {
        public AppDbContext _context;

        public OrdenTieneProductoService(AppDbContext context)
        {
            _context = context;
        }

        public void Eliminar(int ordid, int prodid)
        {
            var ordenTieneProducto = _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == ordid && c.ProductoId == prodid);

            _context.Remove(ordenTieneProducto);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.OrdenTieneProductos.Where(c => ids.Contains(c.OrdenId)));
            _context.SaveChanges();
        }

        public List<OrdenTieneProducto> ObtenerOrdenTieneProductos(int id)
        {
            return _context.OrdenTieneProductos.Where(c => c.OrdenId == id).ToList();
        }

        public OrdenTieneProducto Obtener(int id)
        {
            return _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == id);
        }

        public int Agregar(OrdenTieneProducto ordenTieneProducto)
        {
            _context.Add(ordenTieneProducto);
            _context.SaveChanges();

            return ordenTieneProducto.OrdenId;
        }

        public bool CompruebaOrdenProducto(int ordid, int prodid)
        {
            if(_context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == ordid && c.ProductoId == prodid) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ActualizarOrdenProd(OrdenTieneProducto ordenprod)
        {
            var ordtemp = _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == ordenprod.OrdenId && c.ProductoId == ordenprod.ProductoId);
            ordtemp.Cantidad++;
            //_context.OrdenTieneProductos.Update(ordtemp);
            _context.SaveChanges();



            return ordtemp.Cantidad;
        }

        public bool CompruebaOrdenProductoCantidad(int ordid, int prodid)
        {
            var ordenTieneProducto = _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == ordid && c.ProductoId == prodid);
            if(ordenTieneProducto.Cantidad > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int ActualizarOrdenProdMinus(OrdenTieneProducto ordenprod)
        {
            var ordtemp = _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == ordenprod.OrdenId && c.ProductoId == ordenprod.ProductoId);
            ordtemp.Cantidad--;
            //_context.OrdenTieneProductos.Update(ordtemp);
            _context.SaveChanges();



            return ordtemp.Cantidad;
        }
    }
}
