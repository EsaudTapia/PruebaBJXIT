using PruebaBJXIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PruebaBJXIT.Servicios.MenuEnums;

namespace PruebaBJXIT.Servicios
{
    public class LoginServicios
    {
        public static bool ValidarCampos(Usuarios user)
        {

            return (user.Correo == null && user.Contrasenia == null);

        }

        public static bool ValidarCuenta(Usuarios user)
        {
            //estatus, correo , contraseña, 
            using (var db = new DBContext())
            {
                var usuario = db.Usuarios.Where(x => x.Correo == user.Correo && x.Contrasenia == user.Contrasenia).FirstOrDefault();
                return (usuario == null);

            }
        }

        public static bool ValidarEstatus(Usuarios user)
        {
            //estatus, correo , contraseña, 
            using (var db = new DBContext())
            {
                var usuario = db.Usuarios.Where(x => x.Correo == user.Correo && x.Contrasenia == user.Contrasenia).FirstOrDefault();
                return ( estatusUsuarios.Desactivado.Equals(usuario.Estatus));

            }
        }


        public static Usuarios usuarioGet(Usuarios user)
        {

            using (var db = new DBContext())
            {
                var usuario = db.Usuarios.Where(x => x.Correo == user.Correo && x.Contrasenia == user.Contrasenia).FirstOrDefault();
                return usuario;
            }

        }
    }
}