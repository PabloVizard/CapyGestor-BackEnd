using Application.Application.Interfaces;
using Application.Application;
using Application.Mappings;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Domain.Services;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Interfaces;

namespace Infrastructure.Utils
{
    public static class InjectorDependencies
    {
        public static void Registrer(IServiceCollection services)
        {
            #region Validators

            #endregion

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            #region Application

            services.AddScoped(typeof(IBaseApp<,>), typeof(BaseApp<,>));
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IEmpresaApp, EmpresaApp>();
            services.AddScoped<IUsuarioEmpresaApp, UsuarioEmpresaApp>();
            services.AddScoped<IFilialApp, FilialApp>();
            services.AddScoped<IUsuarioFilialApp, UsuarioFilialApp>();

            #endregion

            #region Services

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IUsuarioEmpresaService, UsuarioEmpresaService>();
            services.AddScoped<IFilialService, FilialService>();
            services.AddScoped<IUsuarioFilialService, UsuarioFilialService>();

            #endregion

            #region Repositories 

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IUsuarioEmpresaRepository, UsuarioEmpresaRepository>();
            services.AddScoped<IFilialRepository, FilialRepository>();
            services.AddScoped<IUsuarioFilialRepository, UsuarioFilialRepository>();
            #endregion
        }
    }
}
