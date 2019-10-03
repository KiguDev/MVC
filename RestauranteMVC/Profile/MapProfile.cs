using Restaurante.Core.Entities;
using RestauranteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<Restaurante.Core.Entities.Restaurante, RestauranteViewModel>().ReverseMap();
            CreateMap<Restaurante.Core.Entities.Restaurante, RestauranteDTO>().ForMember(m => m.Mesas, opt => opt.MapFrom(src => src.Mesas.Count));
            CreateMap<Mesa, MesaDTO>().ForMember(m => m.Restaurante, opt => opt.MapFrom(src => src.Restaurante.Nombre));
        }
    }
}
