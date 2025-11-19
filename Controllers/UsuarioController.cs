using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_caldas.Data.Services;
using proyecto_caldas.Models;

namespace proyecto_caldas.Controllers
{
    [Route("user")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioservice usuarioservice;
        public UsuarioController(IUsuarioservice usuarioservice)
        {
            this.usuarioservice = usuarioservice;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register(Usuariomodel usuario)
        {
            if (ModelState.IsValid)
            {
                await usuarioservice.CrearUsuario(usuario);
                return RedirectToAction("Indrex", "Home");
            }
                return View(usuario);
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}