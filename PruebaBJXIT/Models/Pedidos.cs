using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models
{
    public class Pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedidos()
        {
            PedidoDetalle = new HashSet<PedidoDetalle>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public double Total { get; set; }        
        
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de realizacion")]
        public DateTime Fecha { get; set; }
        
        public int? IdCliente { get; set; }
        public virtual Clientes Cliente { get; set; }
        public int? IdUsuario { get; set; }
        public virtual Usuarios Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }


    }
}