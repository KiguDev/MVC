using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services 
{
    public class OrdenTieneProductoService : IOrdenTieneProductoService
    {
        public AppDbContext _context;
        private readonly IProductoService _productoService;

        public OrdenTieneProductoService(AppDbContext context, IProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }

        public void Editar(OrdenTieneProducto orden)
        {
            var subTotalAntiguo = _context.OrdenTieneProductos.Where(o => o.Id == orden.Id).FirstOrDefault().SubTotal;
            var SubTotalNuevo = (decimal)(orden.Producto.Precio * orden.Cantidad);
            orden.SubTotal = SubTotalNuevo;
            var ordenCompleta = _context.Ordenes.Where(o => o.Id == orden.OrdenId).FirstOrDefault();
            ordenCompleta.Total = (ordenCompleta.Total - subTotalAntiguo) + SubTotalNuevo;
            _context.OrdenTieneProductos.Update(orden);
           
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var ordenTP = _context.OrdenTieneProductos.Where(o => o.Id == id).FirstOrDefault();
            var ordenCompleta = _context.Ordenes.Where(o => o.Id == ordenTP.OrdenId).FirstOrDefault();
            ordenCompleta.Total -= ordenTP.SubTotal;
            _context.OrdenTieneProductos.Remove(ordenTP);
           
            _context.SaveChanges();
           
        }

        public int insertar(OrdenTieneProducto orden)
        {
            var producto = _productoService.Obtener(orden.ProductoId);
            orden.SubTotal = (decimal)(producto.Precio * orden.Cantidad);
            var ordenCompleta = _context.Ordenes.Where(o => o.Id == orden.OrdenId).FirstOrDefault();
            ordenCompleta.Total += orden.SubTotal;
           
            _context.OrdenTieneProductos.Add(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public OrdenTieneProducto Obtener(int id)
        {
            return _context.OrdenTieneProductos.FirstOrDefault(o => o.Id == id);
        }

        public List<OrdenTieneProducto> ObtenerOrdenTProducto(int id)
        {
            var ordenesTP = _context.OrdenTieneProductos.Where(o => o.OrdenId == id).ToList();
            return ordenesTP;
        }
    }
}
