namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Sede")]
    public class Sede
    {
        [Key]
        public int IdSede { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int IdEmpresa { get; set; }

        public bool Activo  { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdCiudad { get; set; }

    }
}
