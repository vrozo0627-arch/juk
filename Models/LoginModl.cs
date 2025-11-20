using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_caldas.Models
{
    public class LoginModl
    {
         [Required(ErrorMessage = "Correo Obligatorio.")]
        public required string Login_Correo { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 8 caracteres con numeros.")]
        public required string Login_Contrasena { get; set; }
    }
}