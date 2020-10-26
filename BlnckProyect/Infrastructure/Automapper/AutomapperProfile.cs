using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlnckProyect.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            /*
                CreateMap<SobreGiroDetalleSolicitudDto, ServicioContratacionProductos.Solicitud>()
                .ForMember(dest => dest.FechaSobregiro, opt => {
                    opt.MapFrom(src => src.FechaPago);
                })
                .ForMember(dest => dest.NoCtaCredito, apt => {
                    apt.MapFrom(src => src.Cuenta[src.Cuenta.Length - 1] == 'C' ? src.Cuenta.Remove(src.Cuenta.Length - 2) : "");
                })
                 .ForMember(dest => dest.NoCtaDebito, apt => {
                     apt.MapFrom(src => src.Cuenta[src.Cuenta.Length - 1] != 'C' ? src.Cuenta.Remove(src.Cuenta.Length - 2) : "");
                 });
             */

            //CreateMap<objA, ObjB>()
            //CreateMap<objB, ObjA>()  //reverse
        }
    }
}