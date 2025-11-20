using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyecto_caldas.Data;
using proyecto_caldas.Data.Services;
using proyecto_caldas.Models;

namespace proyecto_caldas.Implementation
{
    public class LoginServicio : ILoginServicio
    {
       private readonly DBContext dBContext;
       private readonly IPaswordServicio paswordServicio;
       public LoginServicio(DBContext dBContext, IPaswordServicio paswordServicio)
        {
            this.dBContext = dBContext;
            this.paswordServicio = paswordServicio;
        }
        public async Task<Usuariomodel?> Login(LoginModl login)
        {
            
            var usuario = await dBContext.Usuarios.FirstOrDefaultAsync(u => u.Usuario_Correo == login.Login_Correo);
            if (usuario == null)
            {
                return null;
            }
            bool esContrasenaValida = paswordServicio
            .CompararContrasenas(login.Login_Contrasena, usuario.Usuario_Contrasena, usuario.Usuario_Salt!);
            if (esContrasenaValida)
            {
                return usuario;
            }
            return null;
        }


     } 
        
 }
