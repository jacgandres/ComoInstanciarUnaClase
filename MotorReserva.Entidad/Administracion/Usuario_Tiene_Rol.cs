namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("Usuario_Tiene_Rol")]
    [DataContractAttribute(Name = "Usuario_Tiene_Rol")]
    [Serializable]
    public class Usuario_Tiene_Rol
    {
        [Key]
        public int IdUsuario_Tiene_Rol { get; set; }

        [DataMemberAttribute]
        [Column("IdRol")]
        [Display(Name = "Nombre Rol")]
        public int IdRol { get; set; }

        [DataMemberAttribute]
        public int IdUsuario { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

    }
}
