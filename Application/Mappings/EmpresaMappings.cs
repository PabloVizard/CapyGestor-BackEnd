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
    public class EmpresaMappings : Profile
    {
        public EmpresaMappings()
        {
            CreateMap<Empresa, EmpresaModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.Removido, opt => opt.MapFrom(src => src.Removido))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ForMember(dest => dest.UsuarioResponsavelId, opt => opt.MapFrom(src => src.UsuarioResponsavelId))
                .ForMember(dest => dest.UsuarioResponsavel, opt => opt.MapFrom(src => src.UsuarioResponsavel))
                .ForMember(dest => dest.UsuarioEmpresas, opt => opt.MapFrom(src => src.UsuarioEmpresas))
                .ReverseMap();
        }
    }

}
