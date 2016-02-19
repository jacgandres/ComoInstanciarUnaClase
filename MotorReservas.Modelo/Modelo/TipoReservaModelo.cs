using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;

namespace MotorReservas.ModeloAdministrativo
{
    public class TipoReservaModelo
    {
        public static bool Insertar(TipoReserva pTipoReserva)
        {
            using (MotorReservasContexto context = new MotorReservasContexto())
            {
                context.TipoReserva.Add(pTipoReserva);
                return context.SaveChanges() > 0;
            }
        }
    }
}
