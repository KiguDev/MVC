using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Entities;
using Restaurante.core.Interfaces;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenesService _ordenService;

        public OrdenesController(IOrdenesService ordenesService)
        {
            _ordenService = ordenesService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Orden>> Get(int id)
        {
            return _ordenService.ObtenerTodas(id);
        }

        [HttpPost]
        public ActionResult<List<Orden>> Post([FromBody] Orden model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<List<Orden>> Put(int id, Orden model)
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