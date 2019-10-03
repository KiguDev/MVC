using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;

        public OrdenesController(IOrdenService ordenService) => _ordenService = ordenService;

        [HttpGet]
        public ActionResult<List<Orden>> Get() => _ordenService.GetAll();
        [HttpPost]
        public ActionResult Post([FromBody]Orden model)
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