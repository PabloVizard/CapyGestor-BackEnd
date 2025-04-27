using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class UsuarioEmpresaMappings : Profile
    {
        public UsuarioEmpresaMappings()
        {
            CreateMap<UsuarioEmpresa, UsuarioEmpresaModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom(src => src.EmpresaId))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ReverseMap();
        }
    }
}
