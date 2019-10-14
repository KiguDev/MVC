using Microsoft.EntityFrameworkCore;
using Restaurantes.Infrastructure.Data;
using Restaurantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurantes.Core.Entities;


namespace Restaurantes.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        public AppDbContext _context;
        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public int Insertar(Producto producto)
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
            var producto = _context.Productos.FirstOrDefault(m => m.Id == id);
            _context.Remove(producto);
            _context.SaveChanges();
        }

        public void EliminarVarios(int[] ids)
        {
            var producto = _context.Productos;

            //var restaurantesEliminar = restaurantes.Where(r => r.Id == ids.Where(id => id == r.Id).FirstOrDefault());
            var productoEliminar = _context.Productos.Where(m => ids.Contains(m.Id));
            _context.RemoveRange(productoEliminar);
            _context.SaveChanges();

        }


        public Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(m => m.Id == id);
        }

        public List<Restaurantes.Core.Entities.Producto> ObtenerProducto(int id)
        {
            var producto = _context.Productos.Where(p => p.RestauranteId == id).ToList();
           
            return producto;
        }
    }
}
