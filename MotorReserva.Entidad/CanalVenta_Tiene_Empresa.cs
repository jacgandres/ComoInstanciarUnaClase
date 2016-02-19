using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MotorReservas.Entidad
{
    [Table("CanalVenta_Tiene_Empresa")]
    [DataContractAttribute(Name = "CanalVenta_Tiene_Empresa")]
    [Serializable]
    public class CanalVenta_Tiene_Empresa
    {
        [Key]
        [DataMemberAttribute]
        public int IdCanalVenta_Tiene_Empresa { get; set; }

        [DataMemberAttribute]
        public int IdEmpresa { get; set; }

        [DataMemberAttribute]
        public int IdCanalVenta { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }
         
    }
}
