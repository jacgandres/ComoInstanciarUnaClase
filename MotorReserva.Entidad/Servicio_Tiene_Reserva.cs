namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class Servicio_Tiene_Reserva
    {
        [Key]
        public int IdServicio_Tiene_Reserva { get; set; }

        public int? IdReserva { get; set; }

        public int? IdServicio { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
