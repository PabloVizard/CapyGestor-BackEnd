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
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(src => src.RazaoSocial))
                .ForMember(dest => dest.InscricaoEstadual, opt => opt.MapFrom(src => src.InscricaoEstadual))
                .ForMember(dest => dest.InscricaoMunicipal, opt => opt.MapFrom(src => src.InscricaoMunicipal))
                .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest => dest.CpfCnpj, opt => opt.MapFrom(src => src.CpfCnpj))
                .ForMember(dest => dest.TelefoneEmpresa, opt => opt.MapFrom(src => src.TelefoneEmpresa))
                .ForMember(dest => dest.TelefoneResponsavel, opt => opt.MapFrom(src => src.TelefoneResponsavel))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Rua))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
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
