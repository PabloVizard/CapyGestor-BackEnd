﻿using Domain.Entities;
using Domain.Repositories.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioEmpresaRepository : BaseRepository<UsuarioEmpresa>, IUsuarioEmpresaRepository
    {
        public UsuarioEmpresaRepository(DataContext dataContext) : base(dataContext) { }
    }
}
