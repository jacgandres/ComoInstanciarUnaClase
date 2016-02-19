namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("CanalVenta")]
    [DataContractAttribute(Name = "CanalVenta")]
    [Serializable]
    public class CanalVenta
    {
        
        public CanalVenta()
        {
        }

        [Key]
        [DataMemberAttribute]
        public int IdCanalVenta { get; set; }

        [Required]
        [StringLength(50)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public bool Activo  { get; set; }

        [Required]
        [DataMemberAttribute]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
