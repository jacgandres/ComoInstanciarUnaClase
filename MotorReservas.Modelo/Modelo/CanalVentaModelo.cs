using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;

namespace MotorReservas.ModeloAdministrativo
{
    public class CanalVentaModelo
    {
        public static bool Insertar(CanalVenta pCanalVenta)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    pCanalVenta.FechaRegistro = DateTime.Now;
                    pCanalVenta.Activo = true;

                    contexto.CanalVenta.Add(pCanalVenta);
                    return contexto.SaveChanges() > 0;
                }
                catch (DbEntityValidationException dbExc)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach(DbEntityValidationResult ve in dbExc.EntityValidationErrors)
                    {
                        sb.AppendLine(ve.ValidationErrors.FirstOrDefault().ErrorMessage);
                    }

                    throw new Exception(sb.ToString());
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
