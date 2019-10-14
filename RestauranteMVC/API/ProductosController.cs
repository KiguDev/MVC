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
    public class ProductosController : ControllerBase
    {
        private readonly IServicio<Producto> _productService;
        public ProductosController(IServicio<Producto> servicio) => _productService = servicio; 
        
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetAll() => _productService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id) => _productService.Get(id);

        [HttpPost]
        public ActionResult Insert([FromBody] Producto producto)
        {
            _productService.Insert(producto);
            _productService.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody]Producto producto)
        {
            _productService.Update(producto);
            _productService.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]Producto producto)
        {
            _productService.DeleteRercord(producto);
            _productService.SaveChanges();
            return Ok();
        }
    }
}