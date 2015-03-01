namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TipoIdentificacion")]
    public class TipoIdentificacion
    {
        
        public TipoIdentificacion()
        {
        }

        [Key]
        public int IdTipoIdentificacion { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
