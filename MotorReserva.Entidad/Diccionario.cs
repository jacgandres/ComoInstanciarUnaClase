namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Diccionario")]
    public class Diccionario
    {
        [Key]
        public int IdDiccionario { get; set; }

        [StringLength(4)]
        public string Llave { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }

        public int? IdProducto { get; set; }

        public int? IdServicio { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
