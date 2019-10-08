using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        public AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }


        public int Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.Id;
        }

        public void Editar(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = _context.Productos.Where(c=>c.Id == id).FirstOrDefault();
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Productos.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }

        public Producto Obtener(int id)
        {
            return _context.Productos.Where(c=>c.Id == id).FirstOrDefault();
        }        

        public List<OrdenTieneProducto> ObtenerProductosOrden(int OrdenId)
        { 
            var orden = _context.Ordenes.Where(c=>c.Id == OrdenId).FirstOrDefault();
            return orden.Productos.ToList();
        }

        public List<Producto> ObtenerProductosRestaurante(int ResId)
        {
            var productos = _context.Productos.Where(c => c.RestauranteId == ResId);
            return productos.ToList();
        }
    }
}
