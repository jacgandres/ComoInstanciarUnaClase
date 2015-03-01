using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReserva.Entidad.ProcedimientosAlmacenados;

namespace MotorReservas.Modelo
{
    public class InventarioModelo
    {
        public static InventariosPorEmpresa ObtenerInventarioPorEmpresa(int pIdEmpresa)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                InventariosPorEmpresa reporte = new InventariosPorEmpresa();

                reporte = contexto.Database.SqlQuery<InventariosPorEmpresa>("InventariosPorEmpresa @IdEmpresa",  pIdEmpresa).FirstOrDefault();

                return reporte;
            }
        }
    }
}
