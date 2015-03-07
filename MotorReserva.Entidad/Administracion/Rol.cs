namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("Rol")]
    [DataContractAttribute(Name = "Rol")]
    [Serializable]
    public class Rol
    {

        public Rol()
        {
        }

        [Key]
        [DataMemberAttribute]
        [Column("IdRol")]
        [Display(Name = "Nombre Rol")]
        public int IdRol { get; set; }

        [Required]
        [StringLength(50)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [DataMemberAttribute]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Descripcion { get; set; }

    }
}
