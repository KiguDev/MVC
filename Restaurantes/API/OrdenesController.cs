using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;

namespace Restaurantes.API
{
    [Route("API/[Controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;

        public OrdenesController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpGet]
        public ActionResult <List<Restaurante.Core.Entities.Orden>> Get()
        {
            return _ordenService.ObtenerTodo();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Restaurante.Core.Entities.Orden model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Restaurante.Core.Entities.Orden model)
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