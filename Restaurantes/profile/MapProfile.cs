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

            CreateMap<Restaurantes.Core.Entities.Restaurante, RestauranteDTO>()
            .ForMember(r => r.Mesas, opt => opt.MapFrom(src => src.Mesas.Count()))
            .ForMember(r => r.Empleados, opt => opt.MapFrom(src => src.Empleados.Count()))
            .ForMember(r => r.Productos, opt => opt.MapFrom(src => src.Productos.Count()))
            .ForMember(r => r.Ordenes, opt => opt.MapFrom(src => src.Ordenes.Count()));







            CreateMap<Restaurantes.Core.Entities.Mesa, MesaDTO>().ReverseMap();

           
            //----Producto Mapper
            CreateMap<Restaurantes.Core.Entities.Producto, ProductoViewModel>().ReverseMap();
            CreateMap<Restaurantes.Core.Entities.Producto, ProductoDTO>().ReverseMap();

            //------Empleado Maper
            CreateMap<Restaurantes.Core.Entities.Empleado, EmpleadoViewModel>().ReverseMap();
            CreateMap<Restaurantes.Core.Entities.Empleado, EmpleadoDTO>().ReverseMap();

            //------Orden Maper
            CreateMap<Restaurantes.Core.Entities.Orden, OrdenViewModel>().ReverseMap();
            CreateMap<Restaurantes.Core.Entities.Orden, OrdenDTO>().ReverseMap();



        }

    }
}
