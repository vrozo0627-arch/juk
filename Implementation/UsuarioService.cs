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
        private readonly IPaswordServicio paswordServicio;

        public UsuarioService(DBContext dBContext,IPaswordServicio paswordServicio)
        {
            this.dBContext = dBContext;
            this.paswordServicio = paswordServicio;
        }
        public async Task CrearUsuario(Usuariomodel usuario)
        {
            if (usuario != null)
            {
                usuario.Usuario_Contrasena = paswordServicio.HashPassword(usuario.Usuario_Contrasena, out string Salt);
                usuario.Usuario_Salt = Salt;
                dBContext.Usuarios.Add(usuario);
                await dBContext.SaveChangesAsync();
            }
        }
    }
}
