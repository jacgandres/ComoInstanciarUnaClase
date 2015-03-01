namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Departamento")]
    public class Departamento
    {
        
        public Departamento()
        {
        }

        [Key]
        public int IdDepartamento { get; set; }

        public int IdPais { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
