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
            CreateMap<Restaurante.Core.Entities.Restaurante, RestauranteDTO>().ForMember(c => c.Mesas, opt => opt.MapFrom(src => src.Mesas.Count()));
            CreateMap<Restaurante.Core.Entities.Mesa, MesaDTO>();
            CreateMap<Restaurante.Core.Entities.Empleado, EmpleadoDTO>();
            CreateMap<Restaurante.Core.Entities.Producto, ProductoViewModel>().ReverseMap();
            CreateMap<Restaurante.Core.Entities.Producto, ProductoDTO>().ReverseMap();
            CreateMap<Restaurante.Core.Entities.Orden, OrdenViewModel>().ReverseMap();
        }
    }
}
