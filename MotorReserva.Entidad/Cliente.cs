namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int IdTipoIdentificacion { get; set; }

        [Required]
        [StringLength(100)]
        public string Identificacion { get; set; }

        public int IdPerfil { get; set; }

        public int IdCiudad { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
