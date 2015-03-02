namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Usuario")]
    [Serializable]
    public class Usuario
    {

        public Usuario()
        {
        }

        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Empresa")]
        public int? IdEmpresa { get; set; }

        [StringLength(100)]
        [Display(Name = "Imagen")]
        public string UrlImagen1 { get; set; }

        [StringLength(100)]
        public string UrlImagen2 { get; set; }

        [StringLength(100)]
        public string UrlImagen3 { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public DateTime? FechaUltimoRegistro { get; set; }

        [Column("Nombre")]
        [StringLength(50)]
        
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }
    }
}
