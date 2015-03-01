namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Producto")]
    public class Producto
    {

        public Producto()
        {
        }

        [Key]
        public int IdProducto { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }

        public int IdEmpresa { get; set; }

        [StringLength(100)]
        public string UrlImagen1 { get; set; }

        [StringLength(100)]
        public string UrlImagen2 { get; set; }

        [StringLength(100)]
        public string UrlImagen3 { get; set; }

        public int IdTipoProducto { get; set; }

    }
}
