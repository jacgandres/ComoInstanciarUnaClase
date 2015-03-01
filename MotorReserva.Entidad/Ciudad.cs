namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Ciudad")]
    public class Ciudad
    {
        
        public Ciudad()
        {
        }

        [Key]
        public int IdCiudad { get; set; }

        public int IdDepartamento { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual Departamento Departamento { get; set; }

    }
}
