namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Contrato")]
    public class Contrato
    {
        [Key]
        public int IdContrato { get; set; }

        public int IdEmpresa { get; set; }

        public int IdEstadoContrato { get; set; }

        [Required]
        [StringLength(2000)]
        public string Descripcion { get; set; }

        public decimal Valor { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public int PlazoEjecucion { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }


    }
}
