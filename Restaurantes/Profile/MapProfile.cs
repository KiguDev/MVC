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
            CreateMap<Restaurante, RestauranteDTO>()/**/
                .ForMember(c => c.Mesas, opt => opt.MapFrom(src => src.Mesas.Count)).ForMember(c => c.Productos, opt => opt.MapFrom(src => src.Productos.Count)).ForMember(c => c.Empleados, opt => opt.MapFrom(src => src.Empleados.Count)).ForMember(c => c.Ordenes, opt => opt.MapFrom(src => src.Ordenes.Count)).ReverseMap();
            CreateMap<Mesa, MesaViewModel>().ReverseMap();
            CreateMap<Mesa, MesaDTO>();
            CreateMap<Producto, ProductoViewModel>().ReverseMap();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<Empleado, EmpleadoViewModel>().ReverseMap();
            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<Orden, OrdenViewModel>().ReverseMap();
            CreateMap<Orden, OrdenDTO>();
            CreateMap<OrdenTieneProducto, OrdenTieneProductoViewModel>().ReverseMap();
            CreateMap<OrdenTieneProducto, OrdenTieneProductoDTO>();
        }
    }
}
