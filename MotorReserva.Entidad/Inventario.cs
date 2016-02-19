namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Inventario")]
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdEmpresa { get; set; }

        public int IdTipoInventario { get; set; }

    }
}
