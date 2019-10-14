using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;

namespace RestauranteMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IServicio<Producto> _servicioProduct;

        public ProductosController(IServicio<Producto> servicio)
        {
            _servicioProduct = servicio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Guardar(int id)
        {
            var productoExistente = _servicioProduct.Get(id);
            var producto = productoExistente != null ? productoExistente : new Producto();
            return PartialView(producto);
        }
    }
}