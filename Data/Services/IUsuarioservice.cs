using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyecto_caldas.Models;

namespace proyecto_caldas.Data.Services
{
    public interface IUsuarioservice
    {
        void CrearUsuario(usuariomodel usuario);
    }
}