namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TipoInventario")]
    public class TipoInventario
    {
        
        public TipoInventario()
        {
        }

        [Key]
        public int IdTtipoInventario { get; set; }

        public DateTime FechaRegistro { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
