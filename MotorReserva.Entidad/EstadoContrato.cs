namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("EstadoContrato")]
    public class EstadoContrato
    {
        
        public EstadoContrato()
        {
        }

        [Key]
        public int IdEstadoContrato { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
