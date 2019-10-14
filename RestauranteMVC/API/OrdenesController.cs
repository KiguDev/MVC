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
        private readonly IServicio<Orden> _orderService;

        public OrdenesController(IServicio<Orden> ordenService) => _orderService = ordenService;

        [HttpGet]
        public ActionResult<List<Orden>> GetAll(int id) => _orderService.GetAll().Where(r => r.RestauranteId == id).ToList();

        //[HttpGet("{id}")]
        //public ActionResult<Orden> GetOrder([FromQuery]int id) => _orderService.Get(id);

        [HttpPost]
        public ActionResult Post([FromBody]Orden model)
        {
            model.FechaAlta = DateTime.Now;
            _orderService.Insert(model);
            _orderService.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody]Orden model)
        {
            _orderService.Update(model);
            _orderService.SaveChanges();
            return Ok();
        }
    }
}