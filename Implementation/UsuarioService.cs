using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyecto_caldas.Data;
using proyecto_caldas.Data.Services;
using proyecto_caldas.Models;

namespace proyecto_caldas.Implementation
{
    public class UsuarioService : IUsuarioservice
    {
        private readonly DBContext dBContext;
        public UsuarioService(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async void CrearUsuario(usuariomodel usuario)
        {
            if (usuario != null)

                dBContext.Usuarios.Add(usuario);
            await dBContext.SaveChangesAsync();
        }
    }
}
