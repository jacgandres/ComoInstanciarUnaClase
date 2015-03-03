namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    

    [Table("Modulo")]
    [Serializable]
    [DataContractAttribute(Name = "Modulo")] 
    public class Modulo
    {
        
        public Modulo()
        {
        }

        [Key]
        [DataMemberAttribute]
        public int IdModulo { get; set; }

        [Required]
        [StringLength(50)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Descripcion { get; set; }

    }
}
