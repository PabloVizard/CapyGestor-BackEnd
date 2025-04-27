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
    public class UsuarioMappings : Profile
    {
        public UsuarioMappings()
        {
            CreateMap<Usuario, UsuarioModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.Removido, opt => opt.MapFrom(src => src.Removido))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ForMember(dest => dest.UltimoAcesso, opt => opt.MapFrom(src => src.UltimoAcesso))
                .ForMember(dest => dest.EmpresasCadastradas, opt => opt.MapFrom(src => src.EmpresasCadastradas))
                .ForMember(dest => dest.UsuarioEmpresas, opt => opt.MapFrom(src => src.UsuarioEmpresas))
                .ReverseMap();
        }
    }

}
