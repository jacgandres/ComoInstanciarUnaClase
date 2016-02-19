namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    

    [Table("Ciudad")]
    [DataContractAttribute(Name = "Ciudad")]
    [Serializable]
    public class Ciudad
    {

        public Ciudad()
        {
        }
        public Ciudad(int pIdCiudad)
        {
            IdCiudad = pIdCiudad;
        }

        [Key]
        [DataMemberAttribute]
        public int IdCiudad { get; set; }

        [DataMemberAttribute]
        public int IdDepartamento { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }
        
    }
}
