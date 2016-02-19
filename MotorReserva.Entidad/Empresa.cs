namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    [Table("Empresa")]
    [DataContractAttribute(Name = "Empresa")]
    [Serializable]
    public class Empresa
    {  
        [Key]
        [DataMemberAttribute]
        public int IdEmpresa { get; set; }

        [DataMemberAttribute]
        [Display(Name = "Tipo Identificación")]
        public int IdTipoIdentificacion { get; set; }
        
        [DataMemberAttribute]
        [Display(Name = "Nombre Ciudad")]
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        [Display(Name="Empresa")]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        public string Identificacion { get; set; }

        [StringLength(15)]
        [DataMemberAttribute]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string Direccion { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        [Display(Name = "Imagen")]
        public string UrlImagen1 { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string UrlImagen2 { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string UrlImagen3 { get; set; }

    }
}
