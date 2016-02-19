namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("Perfil")]
    [DataContractAttribute(Name = "Perfil")]
    [Serializable]
    public class Perfil
    {
        [Key]
        [DataMemberAttribute]
        public int IdPerfil { get; set; }

        [Required]
        [StringLength(150)]
        [DataMemberAttribute]
        public string Descripcion { get; set; }

        [StringLength(200)]
        [DataMemberAttribute]
        public string IdFacebook { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string IdTwitter { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string IdInstagram { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string IdGoogle { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public int? IdEmpresa { get; set; }

        [DataMemberAttribute]
        public int? IdCliente { get; set; }
    }
}
