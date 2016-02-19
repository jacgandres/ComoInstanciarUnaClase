namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Servicio")]
    public class Servicio
    {
        
        public Servicio()
        {
        }

        [Key]
        public int IdServicio { get; set; }

        public int IdEmpresa { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaRegistro { get; set; }

        [StringLength(100)]
        public string UrlImagen1 { get; set; }

        [StringLength(100)]
        public string UrlImagen2 { get; set; }

        [StringLength(100)]
        public string UrlImagen3 { get; set; }

        public int? IdTipoServicio { get; set; }

    }
}
