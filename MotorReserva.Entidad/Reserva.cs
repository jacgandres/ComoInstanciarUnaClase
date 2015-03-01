namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Reserva")]
    public class Reserva
    {
        public Reserva()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdReserva { get; set; }

        public int IdEmpresa { get; set; }

        public int IdCliente { get; set; }

        public int IdDetalleReserva { get; set; }

        public bool? Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int IdCanalVenta { get; set; }

        public int IdTipoReserva { get; set; }

        public virtual CanalVenta CanalVenta { get; set; }

        public virtual DetalleReserva DetalleReserva { get; set; }

        public virtual Empresa Empresa { get; set; }

    }
}
