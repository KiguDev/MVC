using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        public OrdenesController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }
        [HttpGet]
        public ActionResult<List<Orden>> getOrdenes()
        {
            return _ordenService.ObtenerTodas();
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