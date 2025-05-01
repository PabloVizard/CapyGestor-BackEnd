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
    public class UsuarioFilialMappings : Profile
    {
        public UsuarioFilialMappings()
        {
            CreateMap<UsuarioFilial, UsuarioFilialModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.FilialId, opt => opt.MapFrom(src => src.FilialId))
                .ForMember(dest => dest.Filial, opt => opt.MapFrom(src => src.Filial))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ReverseMap();
        }
    }
}
