using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_caldas.Models
{
    public class Usuariomodel
    {
        public int Usuario_Id { get; set; }
       [Required(ErrorMessage = "Primer Nombre.")]
        public required string Usuario_Nombre { get; set; }
        [Required(ErrorMessage = "Primer Apellido.")]
        public required string Usuario_Apellido { get; set; }
        [Required(ErrorMessage = "Correo Obligatorio.")]
        public required string Usuario_Correo { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 8 caracteres con numeros.")]
        public required string Usuario_Contrasena { get; set; }
        public string? Usuario_Salt {get; set;}
       
    }
}