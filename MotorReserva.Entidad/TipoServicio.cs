namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TipoServicio")]
    public class TipoServicio
    {
        
        public TipoServicio()
        {
        }

        [Key]
        public int IdTipoServicio { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo  { get; set; }

        public int? IdServicio { get; set; }
        
    }
}
