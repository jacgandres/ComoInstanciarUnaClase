namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("DetalleReserva")]
    public class DetalleReserva
    {
        
        public DetalleReserva()
        {
        }

        [Key]
        public int IdDetalleReserva { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo  { get; set; }

    }
}
