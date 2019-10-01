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
            CreateMap<Restaurante.core.Entities.Restaurante, RestauranteViewModel>().ReverseMap();
        }
    }
}
