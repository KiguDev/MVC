using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Interfaces;
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

        [HttpPost]
        public ActionResult Create(MesaViewModel model)
        {
            var mesa = new Mesa();
            mesa = _mapper.Map(model,mesa);
            _mesasService.Insert(mesa);
            _mesasService.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(MesaViewModel model)
        {
            var mesa = new Mesa();
            mesa = _mapper.Map(model, mesa);
            _mesasService.Update(mesa);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] MesaViewModel model)
        {
            var mesa = _mesasService.GetMesa(model.Id);
            _mesasService.Delete(mesa);
            _mesasService.SaveChanges();
            return Ok();
        }
    }
}