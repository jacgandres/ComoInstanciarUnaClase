namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Servicio_Tiene_Reserva")]
    [Serializable]
    public class Servicio_Tiene_Reserva
    {
        [Key]
        public int IdServicio_Tiene_Reserva { get; set; }

        public int? IdReserva { get; set; }

        public int? IdServicio { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Reserva Reserva { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
