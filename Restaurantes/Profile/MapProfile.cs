using Restaurantes.Core.Entities;
using Restaurantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
       public MapProfile()
        {
            CreateMap<Restaurante, RestauranteViewModel>().ReverseMap();
            CreateMap<Restaurante, RestauranteDTO>()
                .ForMember(c => c.Mesas, opt => opt.MapFrom(src => src.Mesas.Count));
            CreateMap<Mesa, MesaViewModel>().ReverseMap();
            CreateMap<Mesa, MesaDTO>();
        }
    }
}
