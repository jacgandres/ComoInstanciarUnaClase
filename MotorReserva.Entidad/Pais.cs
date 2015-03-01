namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class Pais
    {
        
        public Pais()
        {
        }

        [Key]
        public int IdPais { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime FecheRegistro { get; set; }
        
    }
}
