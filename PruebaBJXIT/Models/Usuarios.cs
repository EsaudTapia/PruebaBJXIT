using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models
{
    public class Usuarios
    {


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            Pedidos = new HashSet<Pedidos>();
        }
        
        [Key]
        public int Id { get; set; }            
        
        [Required]
        [StringLength(200)]
        [Display(Name = "Nombre")]
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
        [Display(Name = "Correo")]
        public String Correo { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Contraseña")]
        public String Contrasenia { get; set; }

        public bool Estatus { get; set; }

        public int? IdRol { get; set; }
        public virtual Roles Rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }

    }
}