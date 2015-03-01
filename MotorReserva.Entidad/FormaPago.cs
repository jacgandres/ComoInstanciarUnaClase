namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("FormaPago")]
    public class FormaPago
    {
        
        public FormaPago()
        {
        }

        [Key]
        public int IdFormaPago { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

    }
}
