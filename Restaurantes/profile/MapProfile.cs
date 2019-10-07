using Restaurantes.Core.Entities;
using Restaurantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.profile
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {

            CreateMap<Restaurantes.Core.Entities.Restaurante, RestauranteViewModel>().ReverseMap();

            CreateMap<Restaurantes.Core.Entities.Restaurante, RestauranteDTO>().ForMember(r => r.Mesas, opt => opt.MapFrom(src => src.Mesas.Count()));

            CreateMap<Restaurantes.Core.Entities.Mesa, MesaDTO>().ReverseMap();
        }

    }
}
