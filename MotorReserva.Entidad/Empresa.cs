namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Empresa")]
    public class Empresa
    {
        public Empresa()
        {
        }

        [Key]
        public int IdEmpresa { get; set; }

        public int IdPerfil { get; set; }

        public int IdCiudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

        [StringLength(100)]
        public string UrlImagen1 { get; set; }

        [StringLength(100)]
        public string UrlImagen2 { get; set; }

        [StringLength(100)]
        public string UrlImagen3 { get; set; }

        public virtual Ciudad Ciudad { get; set; }

    }
}
