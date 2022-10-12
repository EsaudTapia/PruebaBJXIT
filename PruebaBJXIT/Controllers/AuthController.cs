using PruebaBJXIT.Models;
using PruebaBJXIT.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PruebaBJXIT.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            ViewBag.guardado = TempData["guardado"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuarios user, string Retorno)
        {

            if (LoginServicios.ValidarCampos(user))
            {
                ViewBag.error = "Por favor llene todos los campos";
                return View();

            }




            if (LoginServicios.ValidarCuenta(user))
            {
                ViewBag.error = "Usuario / contraseña incorrectos papi";
                return View();
            }
            else
            {

                if (LoginServicios.ValidarEstatus(user))
                {                    
                                  
                    ViewBag.error = "Su cuenta esta inactiva consulte con el administrador";
                    return View();

                }
                else
                {
                    bool persist = true;
                    var correo = user.Correo;
                    FormsAuthentication.SetAuthCookie(correo, persist);                                      
                    return RedirectToAction("Index", "Home");
                }
            }


        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }




    }
}