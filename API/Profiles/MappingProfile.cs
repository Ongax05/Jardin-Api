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
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Gama_Producto, Gama_ProductoDto>().ReverseMap();
            CreateMap<Oficina, OficinaDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Cliente, NombresClientesDto>().ReverseMap();
            CreateMap<Pedido, EstadosDeOrdenDto>().ReverseMap();
            CreateMap<Pago, PagoClienteIdDto>().ReverseMap();
            CreateMap<Pedido, ResumenPedidoEsEnDto>().ReverseMap();
            CreateMap<Pago, PagoFormaDto>().ReverseMap();
            CreateMap<Cliente, ClienteNombreDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoConOficinaDto>().ReverseMap();

            CreateMap<Producto, ProductoConCuantosVendidosDto>()
                .ForMember(
                    dest => dest.Unidades_Vendidas,
                    opt => opt.MapFrom(en => en.Detalles_Pedidos.Count)
                )
                .ReverseMap();
            CreateMap<Pedido, PedidoConCuantosProductosDistintos>()
                .ForMember(
                    dest => dest.Cantidad_De_Productos_Distintos,
                    opt =>
                        opt.MapFrom(
                            en => en.Detalles_Pedidos.Select(p => p.ProductoId).Distinct().Count()
                        )
                );
            CreateMap<Pedido, PedidoConCuantosProductos>()
                .ForMember(
                    dest => dest.Cantidad_De_Productos,
                    opt => opt.MapFrom(en => en.Detalles_Pedidos.Select(p => p.ProductoId).Count())
                );
            CreateMap<Cliente, ClienteConFechasDto>()
                .ForMember(
                    dest => dest.Pago_Mas_Reciente,
                    opt =>
                        opt.MapFrom(
                            en =>
                                en.Pagos
                                    .OrderByDescending(p => p.Fecha_Pago)
                                    .Select(p => p.Fecha_Pago)
                                    .FirstOrDefault()
                        )
                )
                .ForMember(
                    dest => dest.Pago_Mas_Antiguo,
                    opt =>
                        opt.MapFrom(
                            en =>
                                en.Pagos
                                    .OrderBy(p => p.Fecha_Pago)
                                    .Select(p => p.Fecha_Pago)
                                    .FirstOrDefault()
                        )
                );
            CreateMap<Empleado, EmpleadoNombreCuantosClientes>()
                .ForMember(dest => dest.Clientes, opt => opt.MapFrom(en => en.Clientes.Count))
                .ReverseMap();
            CreateMap<Empleado, EmpleadoConNombreJefeDto>()
                .ForMember(dest => dest.Nombre_Jefe, opt => opt.MapFrom(en => en.Jefe.Nombre))
                .ReverseMap();
            CreateMap<Producto, ProductoNombreDescImg>()
                .ForMember(dest => dest.Imagen, opt => opt.MapFrom(en => en.Gama_Producto.Imagen))
                .ForAllMembers(p => p.NullSubstitute("No Img"));
            CreateMap<Empleado, EmpleadoConJefesDto>()
                .ForMember(dest => dest.Nombre_Jefe, opt => opt.MapFrom(en => en.Jefe.Nombre))
                .ForMember(
                    dest => dest.Nombre_Jefe_del_Jefe,
                    opt => opt.MapFrom(en => en.Jefe.Jefe.Nombre)
                )
                .ForAllMembers(p => p.NullSubstitute("No tiene jefe"));
            CreateMap<Cliente, ClientsWithRepSalInfoDto>()
                .ForMember(dest => dest.Nombre_RepSal, opt => opt.MapFrom(en => en.Empleado.Nombre))
                .ForMember(
                    dest => dest.Apellido_RepSal,
                    opt => opt.MapFrom(en => en.Empleado.Apellido1)
                )
                .ReverseMap();
            CreateMap<Cliente, ClientsWithRepSalInfoPlusOfficeCityDto>()
                .ForMember(dest => dest.Nombre_RepSal, opt => opt.MapFrom(en => en.Empleado.Nombre))
                .ForMember(
                    dest => dest.Apellido_RepSal,
                    opt => opt.MapFrom(en => en.Empleado.Apellido1)
                )
                .ForMember(
                    dest => dest.Ciudad_Oficina,
                    opt => opt.MapFrom(en => en.Empleado.Oficina.Ciudad)
                )
                .ReverseMap();
        }
    }
}
