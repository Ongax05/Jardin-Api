using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile (){
            CreateMap<Cliente,ClienteDto>().ReverseMap();
            CreateMap<Empleado,EmpleadoDto>().ReverseMap();
            CreateMap<Gama_Producto,Gama_ProductoDto>().ReverseMap();
            CreateMap<Oficina,OficinaDto>().ReverseMap();
            CreateMap<Pago,PagoDto>().ReverseMap();
            CreateMap<Pedido,PedidoDto>().ReverseMap();
            CreateMap<Producto,ProductoDto>().ReverseMap();
        }
    }
}