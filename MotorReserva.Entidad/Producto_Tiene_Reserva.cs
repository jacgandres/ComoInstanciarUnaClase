namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Producto_Tiene_Reserva")]
    public class Producto_Tiene_Reserva
    {
        [Key]
        public int IdProducto_Tiene_Reserva { get; set; }

        public int IdReserva { get; set; }

        public int IdProducto { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
