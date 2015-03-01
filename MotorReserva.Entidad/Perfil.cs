namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Perfil")]
    public class Perfil
    {
        public Perfil()
        {
        }

        [Key]
        public int IdPerfil { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [StringLength(200)]
        public string IdFacebook { get; set; }

        [StringLength(100)]
        public string IdTwitter { get; set; }

        [StringLength(100)]
        public string IdInstagram { get; set; }

        [StringLength(100)]
        public string IdGoogle { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
