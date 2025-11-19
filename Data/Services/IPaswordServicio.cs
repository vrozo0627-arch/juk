using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_caldas.Data.Services
{
    public interface IPaswordServicio
    {
        string HashPassword(string password, out string Salt);
    }
}