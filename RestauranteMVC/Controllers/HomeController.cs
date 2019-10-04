using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;
        private IMesasService _mesasService;
        private IAsyncRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(IRestauranteService restauranteService, IMesasService mesasService, IMapper mapper, IAsyncRepository repository)
        {
            _restauranteService = restauranteService;
            _mesasService = mesasService;
            _mapper = mapper;
            _repository = repository;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            //var restaurantes = _restauranteService.ObtenerRestaurante();
            return View();
        }

        /*public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View(new RestauranteViewModel());
        }*/
        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarRestaurante",new RestauranteViewModel());
        }

        /*public IActionResult AgregarMesa()
        {
            ViewData["AccionMesa"] = "AgregarMesa";
            return View(new MesaViewModel());
        }*/
        public IActionResult AgregarMesa()
        {
            ViewData["AccionMesa"] = "AgregarMesa";
            return PartialView("_AgregarEditarMesa",new MesaViewModel());
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Te hacen falta campos");
                return View(model);
            }

            var restaurante = new Restaurante.core.Entities.Restaurante
            {
                Nombre = model.Nombre,
                Domicilio = model.Domicilio,
                HoraDeCierre = model.HoraDeCierre,
                FechaDeAlta = DateTime.Now,
                Telefono = model.Telefono,
                Logo = model.Logo,
                PaginaWeb = model.PaginaWeb
            };

            var id = _repository.AddAsync(restaurante);
            //var id = _restauranteService.InsertarRestaurante(restaurante);
            //return View(model);
            return RedirectToAction("Index");
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(RestauranteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //ModelState.AddModelError("", "Te hacen falta campos");
                    return BadRequest("Te hacen falta campos");
                }

                var restaurante = new Restaurante.core.Entities.Restaurante
                {
                    Nombre = model.Nombre,
                    Domicilio = model.Domicilio,
                    HoraDeCierre = model.HoraDeCierre,
                    FechaDeAlta = DateTime.Now,
                    Telefono = model.Telefono,
                    Logo = model.Logo,
                    PaginaWeb = model.PaginaWeb
                };

                var id = _repository.AddAsync(restaurante);
                //var id = _restauranteService.InsertarRestaurante(restaurante);
                //return View(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarMesa(MesaViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            model.RestauranteId = id;
            var mesa = new Restaurante.core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId
            };

            var idMesa = _mesasService.InsertarMesa(mesa);
            return RedirectToAction("Mesas/"+model.RestauranteId);
            //return View(model);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarMesa(MesaViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            model.RestauranteId = id;
            var mesa = new Restaurante.core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId
            };

            var idMesa = _mesasService.InsertarMesa(mesa);
            return RedirectToAction("Mesas/" + model.RestauranteId);
            //return View(model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var restaurante = _restauranteService.Obtener(id);
            var viewModel = new RestauranteViewModel
            {
                Id = restaurante.Id,
                Nombre = restaurante.Nombre,
                Domicilio = restaurante.Domicilio,
                HoraDeCierre = restaurante.HoraDeCierre.GetValueOrDefault(),
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono,
                Logo = restaurante.Logo
            };
            return View("Agregar",viewModel);
        }

        [HttpGet]
        public IActionResult EditarMesa(int id)
        {
            ViewData["AccionMesa"] = "EditarMesa";
            var mesa = _mesasService.Obtener(id);
            var viewModel = new MesaViewModel
            {
                Identificador = mesa.Identificador,
                Capacidad = mesa.Capacidad
            };
            return View("AgregarMesa", viewModel);
        }

        [HttpPost]
        public IActionResult Editar(RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var restaurante = _restauranteService.Obtener(model.Id);
            restaurante.Nombre = model.Nombre;
            restaurante.Logo = model.Logo;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Telefono = model.Telefono;
            restaurante.HoraDeCierre = model.HoraDeCierre;
            restaurante.Domicilio = model.Domicilio;

            _restauranteService.EditarRestaurante(restaurante);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarMesa(MesaViewModel model, int resId)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var mesa = _mesasService.Obtener(model.Id);
            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;

            _mesasService.EditarMesa(mesa);

            return RedirectToAction("Mesas/"+mesa.RestauranteId);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var eliminarRestaurante = _restauranteService.EliminarRestaurante(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EliminarMesa(int id, int resId)
        {
            var eliminarMesa = _mesasService.EliminarMesa(id);
            return RedirectToAction("Mesas/"+resId);
        }

        public IActionResult Mesas(int id)
        {
            ViewData["resId"] = id;
            var mesas = _mesasService.ObtenerMesas(id);
            return View(mesas);
        }

        [HttpGet]
        public ActionResult<RestauranteDTO> Perfil(int id)
        {
            var restaurantes = _restauranteService.Obtener(id);
            var model = new RestauranteDTO();
            _mapper.Map(restaurantes, model);
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
