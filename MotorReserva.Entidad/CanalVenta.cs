namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("CanalVenta")]
    public class CanalVenta
    {
        public CanalVenta()
        {
        }

        [Key]
        public int IdCanalVenta { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

    }
}
