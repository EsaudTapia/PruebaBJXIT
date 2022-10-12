using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models
{
    public class Clientes
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            Pedidos = new HashSet<Pedidos>();
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Nombre del cliente")]
        public String Nombre { get; set; }


        [Required]
        [StringLength(200)]
        [Display(Name = "Apellido Paterno")]
        public String ApellidoPaterno { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Apellido Materno")]
        public String ApellidoMaterno { get; set; }



        [Required]
        [StringLength(200)]
        [Display(Name = "Colonia")]
        public String Colonia { get; set; }
        
        [Required]
        [StringLength(200)]
        [Display(Name = "Calle")]
        public String Calle { get; set; }

        [Display(Name = "Numero de la casa")]
        public String Numero { get; set; }
        
        [Required]
        [Range(10000, 99999, ErrorMessage = "El codigo postal debe tener 5 numeros")]

        [Display(Name = "Codigo postal")]
        public String Cp { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El telefono debe tener 10 numeros")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }        
        public bool Estatus { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}