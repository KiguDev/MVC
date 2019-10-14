using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : Controller
    {
        private readonly IOrdenService _OrdenService;
        private readonly IMapper _mapper;
        public OrdenesController(IOrdenService OrdenService, IMapper mapper)
        {
            _OrdenService = OrdenService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<OrdenDTO>> getOrden(int id)
        {
            var ordenes = _OrdenService.Obtener(id);
            var model = new List<OrdenDTO>();
            _mapper.Map(ordenes, model);
            return model;
        }

        [HttpPut("{id}")]
        public ActionResult putProducto(int id, OrdenViewModel model)
        {
            var ordenes = _OrdenService.Obtener(id);
            if (ordenes == null)
                return BadRequest();
           
            
            _OrdenService.Editar(ordenes);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteProducto(int id)
        {
            _OrdenService.Eliminar(id);
            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult postProducto([FromBody] ProductoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }


            var ordenes = new Restaurantes.Core.Entities.Orden
            {
            Id = model.Id,
            

        };
            ordenes.Id = id;
            var respuesta = _OrdenService.insertar(ordenes);
            return Ok();
        }
    }
}