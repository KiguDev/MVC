using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IordenService _ordenService;

        public OrdenesController(IordenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpGet]
        public ActionResult<List<Orden>> Get()
        {
            return _ordenService.ObtenerTodo();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Orden model)
        {
            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Orden model)
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