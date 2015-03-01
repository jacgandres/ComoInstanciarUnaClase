namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class FormaPago_Tiene_Reserva
    {
        [Key]
        public int IdFormaPago_Tiene_Reserva { get; set; }

        public int IdReserva { get; set; }

        public bool Activo  { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdFormaDePago { get; set; }

    }
}
