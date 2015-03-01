namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Rol")]
    public class Rol
    {
        
        public Rol()
        {
        }

        [Key]
        public int IdRol { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

    }
}
