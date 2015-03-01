namespace MotorReservas.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class Usuario_Tiene_Rol
    {
        [Key]
        public int IdUsuario_Tiene_Rol { get; set; }

        public int IdRol { get; set; }

        public int IdUsuario { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

    }
}
