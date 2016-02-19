namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    
    [Serializable]
    [Table("Modulos_Tiene_Rol")]
    [DataContractAttribute(Name = "Modulos_Tiene_Rol")]
    public class Modulos_Tiene_Rol
    {
        [Key]
        [DataMemberAttribute]
        public int IdModulos_Tiene_Rol { get; set; }

        [DataMemberAttribute]
        [Column("IdRol")]
        [Display(Name = "Nombre Rol")]
        public int IdRol { get; set; }

        [DataMemberAttribute]
        [Display(Name = "Nombre Modulo")]
        public int IdModulo { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }
    }
}
