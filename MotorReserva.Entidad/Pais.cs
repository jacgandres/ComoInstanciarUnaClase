namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("Pais")]
    [DataContractAttribute(Name = "Pais")]
    [Serializable]
    public class Pais
    {
        
        public Pais()
        {
        }

        [Key]
        [DataMemberAttribute]
        public int IdPais { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [DataMemberAttribute]
        public DateTime FecheRegistro { get; set; }
        
    }
}
