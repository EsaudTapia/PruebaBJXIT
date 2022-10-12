using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models.ViewModel
{
    public class PedidoViewModel
    {
        public int Cliente { get; set; }
        public int Usuario { get; set; }
        public List <Concepto> conceptos { get; set; }
    }

    public class Concepto {
        public int Cantidad { get; set; }
        public int idProducto { get; set; }
        public double Precio { get; set; }

    }
}