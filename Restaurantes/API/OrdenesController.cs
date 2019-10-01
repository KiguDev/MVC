using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.infrastructure.Services;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        public readonly IOrdenService _ordenService;
        public OrdenesController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }
        [HttpGet]
        public ActionResult<List<Ordenes>> Get()
        {
            return _ordenService.ObtenerTodo();
        }
        [HttpPost]
        public ActionResult Post([FromBody] Ordenes model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Ordenes model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}