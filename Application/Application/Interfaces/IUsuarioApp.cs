﻿using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Interfaces
{
    public interface IUsuarioApp : IBaseApp<Usuario, UsuarioModel>
    {
    }
}
