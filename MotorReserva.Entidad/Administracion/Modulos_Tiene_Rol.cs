namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class Modulos_Tiene_Rol
    {
        [Key]
        public int IdModulos_Tiene_Rol { get; set; }

        public int IdRol { get; set; }

        public int IdModulo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }
    }
}
