using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Servicios
{
    public class MenuEnums
    {
        public enum estatusUsuarios
        {
            Activo = 1,
            Desactivado = 0,
          
        }

        public enum roles
        {
            Administrador = 1,
            Vendedor = 2,
            Administrativo = 3

        }
    }
}