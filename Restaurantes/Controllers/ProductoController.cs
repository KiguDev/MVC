using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Controllers
{
    public class ProductoController : Controller
    {
            private IProductoService _productoServices;
            public ProductoController(IProductoService productoService)
            {
                _productoServices = productoService;
            }


            public IActionResult Index(int id)
            {
                ViewData["resId"] = id;
                var productos = _productoServices.ObtenerProducto(id);
                return View(productos);
            }

            public IActionResult Agregar()
            {
                ViewData["Accion"] = "Agregar";
                return View(new ProductoViewModel());
            }



            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Agregar(ProductoViewModel model, int id)
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Te hacen falta campos");
                    return View(model);
                }

                var producto = new Producto
                {

                    Nombre = model.Nombre,
                    Precio = model.Precio,
                    Descripcion = model.Descripcion,
                    Imagen = model.Imagen
                };

                model.Id = id;
                producto.Id = id;
                var respuesta = _productoServices.Insertar(producto);

                return View("Agregar", model);
            }

         
            public IActionResult Editar(int id)
            {
                ViewData["Accion"] = "Editar";
                var producto = _productoServices.Obtener(id);
                var viewModel = new ProductoViewModel
                {
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Descripcion = producto.Descripcion,
                    Imagen = producto.Imagen
                };

                return View("Agregar", viewModel);

            }

        [HttpPost]
        public IActionResult Editar(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar", model);
            }
            var producto = _productoServices.Obtener(model.Id);


                    producto.Nombre = model.Nombre;
                    producto.Precio = model.Precio;
                    producto.Descripcion = model.Descripcion;
                    producto.Imagen = model.Imagen;
                   _productoServices.Editar(producto);


            return RedirectToAction("Index", new { Id = producto.RestauranteId });
        }

            ///Eliminar Producto
           
            [HttpPost]
            public IActionResult Eliminar(int id)
            {
                var resId = _productoServices.Obtener(id).Id;
                _productoServices.Eliminar(id);
                return RedirectToAction("Index", new { Id = resId });
            }

        
    }
}
