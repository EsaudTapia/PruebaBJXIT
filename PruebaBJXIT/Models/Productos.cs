using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models
{
    public class Productos
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            PedidoDetalle = new HashSet<PedidoDetalle>();
        }
        
        [Key]
        public int Id { get; set; }        
        public String Descripcion { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double Precio { get; set; }

        [Display(Name = "Existencias")]
        public int Existencias { get; set; }
        public bool Estatus { get; set; }
        public int? IdProvedor { get; set; }
        public virtual Proveedores Proveedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}