using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;

namespace MotorReservas.ModeloAdministrativo
{
    public class ModuloModelo
    {
        public static List<Modulo> ObtenerModulosRolesPorUsuario(int intUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var lstModulos = contexto.Database.SqlQuery<Modulo>("ObtenerModulosRolesPorUsuario @IdUsuario",
                        new SqlParameter("IdUsuario", intUsuario));

                    List<Modulo> resModulos = (from mod in lstModulos
                                               orderby mod.IdModulo
                                               select mod).ToList();
                    return resModulos;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        public static List<Modulo> ObtenerModulos()
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    List<Modulo> modulos = (from mod in contexto.Modulo
                                            orderby mod.Nombre ascending
                                            select mod).ToList();

                    return modulos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public static bool EmiminarModulo(Modulo pModulo)
        {
            using(MotorReservasContexto contexto = new MotorReservasContexto())
            {
                var qrModulo = contexto.Entry(pModulo);
                qrModulo.State = System.Data.Entity.EntityState.Deleted;
                return contexto.SaveChanges() > 0;
            }
        }

        public static bool RegistrarModulo(Modulo pModulo)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                contexto.Modulo.Add(pModulo);
                return contexto.SaveChanges() > 0;
            }
        }

        public static bool ActualizarModulo(Modulo pModulo)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                var qrModulo = contexto.Entry(pModulo);
                qrModulo.State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }

        public static Modulo ObtenerModuloPorId(Modulo pModulo)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                Modulo qrModulo = (from ctx in contexto.Modulo
                                where ctx.IdModulo == pModulo.IdModulo
                                select ctx).FirstOrDefault();

                return qrModulo;
            }
        }
    }
}
