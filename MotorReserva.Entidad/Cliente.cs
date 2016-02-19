namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("Cliente")]
    [DataContractAttribute(Name = "Cliente")]
    [Serializable]
    public class Cliente
    {
        [Key]
        [DataMemberAttribute]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [DataMemberAttribute]
        public string Email { get; set; }

        [DataMemberAttribute]
        public int IdTipoIdentificacion { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Identificacion { get; set; }


        [DataMemberAttribute]
        public int IdCiudad { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

    }
}
