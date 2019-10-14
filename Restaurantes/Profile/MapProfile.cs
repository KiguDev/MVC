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
            CreateMap<Restaurante.Core.Entities.Restaurante, RestauranteViewModel>().ReverseMap();

            CreateMap<Restaurante.Core.Entities.Restaurante, RestauranteDTO>().ForMember(r => r.Mesas, opt => opt.MapFrom(src => src.Mesas.Count()));

            CreateMap<Restaurante.Core.Entities.Mesa, MesaDTO>().ReverseMap();

            CreateMap<Restaurante.Core.Entities.Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<Restaurante.Core.Entities.Empleado, EmpleadoViewModel>().ReverseMap();
            CreateMap<EmpleadoViewModel, EmpleadoDTO>().ReverseMap();

            CreateMap<Restaurante.Core.Entities.Producto, ProductoDTO>().ReverseMap();
            CreateMap<Restaurante.Core.Entities.Producto, ProductoViewModel>().ReverseMap();
        }
       
    }
}
