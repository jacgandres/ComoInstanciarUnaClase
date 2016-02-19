namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TipoProducto")]
    public class TipoProducto
    {
        
        public TipoProducto()
        {
        }

        [Key]
        public int IdTipoProducto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }
    }
}
