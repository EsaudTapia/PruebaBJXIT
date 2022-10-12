using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaBJXIT.Models.ViewModel;
using PruebaBJXIT.Models;
using PruebaBJXIT.Servicios;

namespace PruebaBJXIT.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        private DBContext db = new DBContext();

        public ActionResult MostrarPedidos()
        {
            var pedidos = db.Pedidos.ToList();

            return View(pedidos);
        }

        public ActionResult Details(int id) {
            //buscar pedido por id y traer con detallepedido

            var pedido = db.Pedidos.Find(id);

            return View(pedido);
        }
        public ActionResult Index()
        {
            //traer todos lo clientes de la base de datos
            var clientes = new List<Clientes>();
            var productos = new List<Productos>();
            var lisclie= db.Clientes.ToList();
            productos = db.Productos.ToList();
           

            foreach (var item in lisclie) {
                item.Nombre = item.Nombre + " " + item.ApellidoPaterno + " " + item.Telefono;
                clientes.Add(item);
            }

            ViewBag.Clientes = clientes;
            ViewBag.productos = productos;

            return View();
        }

        [HttpPost]
        public JsonResult GetPrecio(Productos pro) {
            db.Configuration.LazyLoadingEnabled = false;
            var producto = db.Productos.Find(pro.Id);
            return Json(producto.Precio, JsonRequestBehavior.AllowGet);

//alan.mata@bjxit.com
        }
        
        [HttpPost]
        public ActionResult Add(PedidoViewModel model) {
            try {

                Pedidos pedido = new Pedidos();
                pedido.Fecha = DateTime.Now;
                pedido.IdCliente = model.Cliente;
                pedido.IdUsuario = SessionService.Id(User.Identity.Name);
                
                db.Pedidos.Add(pedido);
                db.SaveChanges();

                foreach(var item in model.conceptos)
                {
                    PedidoDetalle oConcepto = new PedidoDetalle();
                    oConcepto.Cantidad = item.Cantidad;
                    oConcepto.IdProducto = item.idProducto;
                    oConcepto.Precio = item.Precio;
                    oConcepto.Total = item.Cantidad * item.Precio;
                    oConcepto.IdPedido = pedido.Id;
                    db.PedidoDetalle.Add(oConcepto);
                    
                }

                db.SaveChanges();

                TempData["msj"] = "se guardo";
                return RedirectToAction("Index", "Home");


            }
            
            catch (Exception ex) {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

