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
            CreateMap<Restaurante.core.Entities.Restaurante, RestauranteDTO>().ForMember(c => c.CantidadMesas, opt => opt.MapFrom(src => src.mesas.Count)).ForMember(c => c.CantidadEmpleados, opt => opt.MapFrom(src => src.empleados.Count));
            CreateMap<Restaurante.core.Entities.Mesa, MesaDTO>();
            CreateMap<Restaurante.core.Entities.Empleado, EmpleadoDTO>();
        }
    }
}
