using PruebaBJXIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Servicios
{
    public class SessionService
    {
        public static int Id(string correo)
        {
            using (var db = new DBContext())
            {
                //traer cookies
                var user = db.Usuarios.FirstOrDefault(x => x.Correo == correo);
                return user.Id;
            }

        }
    }
}