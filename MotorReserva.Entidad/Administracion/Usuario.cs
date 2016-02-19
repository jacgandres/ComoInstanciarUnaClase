namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("Usuario")]
    [DataContractAttribute(Name = "Usuario")]
    [Serializable]
    public class Usuario
    {

        public Usuario()
        {
        }

        [Key]
        [DataMemberAttribute]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [DataMemberAttribute]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [DataMemberAttribute]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [DataMemberAttribute]
        public string Clave { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [EmailAddress]
        [DataMemberAttribute]
        public string Correo { get; set; }

        [DataMemberAttribute]
        public bool Activo { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataMemberAttribute]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Empresa")]
        [DataMemberAttribute]
        public int IdEmpresa { get; set; }

        [StringLength(100)]
        [Display(Name = "Imagen")]
        [DataMemberAttribute]
        public string UrlImagen1 { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string UrlImagen2 { get; set; }

        [StringLength(100)]
        [DataMemberAttribute]
        public string UrlImagen3 { get; set; }

        [Required]
        [StringLength(100)]
        [DataMemberAttribute]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Ultima Sesión")]
        [DataMemberAttribute]
        public DateTime? FechaUltimaSesion { get; set; }

    }
}
