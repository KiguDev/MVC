using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IMesasService _mesasService;
        private readonly IMapper _mapper;
        public MesasController(IMesasService mesasService, IMapper mapper)
        {
            _mesasService = mesasService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<MesaDTO>> Get(int id)
        {
            var mesas = _mesasService.GetMesas(id);
            var model = new List<MesaDTO>();
            _mapper.Map(mesas, model);
            return model;
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] int [] id)
        {
            _mesasService.Delete(id);
            _mesasService.SaveChanges();
            return Ok();
        }
    }
}