using System;
using Restaurantes.Core.Entities;
using Restaurantes.Models;

namespace Restaurantes.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<Restaurante, RestauranteViewModel>().ReverseMap();
            CreateMap<Restaurante, RestauranteDTO>()
                .ForMember(c => c.Mesas, opt => opt.MapFrom(src => src.Mesas.Count))
                .ForMember(c => c.Empleados, opt => opt.MapFrom(src => src.Empleados.Count));
            CreateMap<Mesa, MesaDTO>();
            CreateMap<Empleado, EmpleadoDTO>();
        }
        
    }
}
