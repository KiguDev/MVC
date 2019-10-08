using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenTieneProductoService : IOrdenTieneProductoService
    {
        public AppDbContext _context;
        public OrdenTieneProductoService(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(OrdenTieneProducto ordenTieneProducto)
        {
            var producto = _context.Productos.FirstOrDefault(c => c.Id == ordenTieneProducto.ProductoId);
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == ordenTieneProducto.OrdenId);
            ordenTieneProducto.Subtotal = producto.Precio * ordenTieneProducto.Cantidad;
            orden.Total += ordenTieneProducto.Subtotal;

            _context.Add(ordenTieneProducto);
            _context.SaveChanges();
        }

        public void Editar(OrdenTieneProducto ordenTieneProducto)
        {
            var producto = _context.Productos.FirstOrDefault(c => c.Id == ordenTieneProducto.ProductoId);
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == ordenTieneProducto.OrdenId);
            orden.Total -= ordenTieneProducto.Subtotal;
            ordenTieneProducto.Subtotal = producto.Precio * ordenTieneProducto.Cantidad;
            orden.Total += ordenTieneProducto.Subtotal;

            _context.Update(ordenTieneProducto);
            _context.SaveChanges();
        }

        public void Eliminar(OrdenTieneProducto ordenTieneProducto)
        {
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == ordenTieneProducto.OrdenId);
            orden.Total -= ordenTieneProducto.Subtotal;
            _context.Remove(ordenTieneProducto);
            _context.SaveChanges();
        }

        public OrdenTieneProducto Obtener(int ordenId, int productoId)
        {
            return _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == ordenId && c.ProductoId == productoId);
        }

        public List<OrdenTieneProducto> ObtenerOrdenTieneProducto(int id)
        {
           return _context.OrdenTieneProductos.Where(c => c.OrdenId == id).ToList();
        }
    }
}