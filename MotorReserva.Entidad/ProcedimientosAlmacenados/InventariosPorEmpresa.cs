using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorReserva.Entidad.ProcedimientosAlmacenados
{
    public class InventariosPorEmpresa
    {
        [Key]
        public int IdInventario { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int? IdEmpresa { get; set; }

        public int? IdTipoInventario { get; set; }

    }
}
