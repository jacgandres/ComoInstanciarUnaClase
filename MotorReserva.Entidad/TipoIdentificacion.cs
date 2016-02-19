namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("TipoIdentificacion")]
    [Serializable]
    [DataContractAttribute(Name = "TipoIdentificacion")]
    public class TipoIdentificacion
    {
        [Key]
        [DataMemberAttribute]
        [Display(Name = "Tipo Identificación")]
        public int IdTipoIdentificacion { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

    }
}
