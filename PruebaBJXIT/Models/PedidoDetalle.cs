using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models
{
    public class PedidoDetalle
    {

       
        
        [Key]
        public int Id { get; set; } 
        [Required]
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
        public int? IdPedido { get; set; }
        public int? IdProducto { get; set; }
        public virtual Pedidos Pedido { get; set; }
        public virtual Productos Producto { get; set; }
    }
}