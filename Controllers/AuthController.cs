using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace proyecto_caldas.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
     [HttpGet]
     [Route("login")]
     public IActionResult Login()
        {
            return View();
        }
     }

 }
