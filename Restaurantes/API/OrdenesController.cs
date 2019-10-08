using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces; 
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly IMapper _mapper;
        public OrdenesController(IOrdenService ordenService, IMapper mapper)
        {
            _ordenService = ordenService;
            _mapper = mapper;


        }
        [HttpGet]
        public ActionResult<List<OrdenDTO>> getOrdenes()
        {
            var orden = _ordenService.ObtenerTodo();

            var model = new List<OrdenDTO>();
            _mapper.Map(orden, model);

            return model;
        }

        [HttpPut("{id}")]
        public ActionResult putOrden(int id, Orden model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteOrden(int id, Orden model)
        {
            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult postOrden([FromBody] Orden model)
        {
            return Ok();
        }
    }
}