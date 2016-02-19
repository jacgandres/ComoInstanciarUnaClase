using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;

namespace MotorReservas.ModeloAdministrativo
{
    public class Modulo_Tiene_RolModelo
    {
        public static bool VerificarRolTieneModulo(Modulos_Tiene_Rol pModuloRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                var tieneModuloRol = from ctx in contexto.Modulos_Tiene_Rol
                                     where ctx.IdModulo == pModuloRol.IdModulo && ctx.IdRol == pModuloRol.IdRol
                                     select ctx;

                return tieneModuloRol.FirstOrDefault() == null;
            }
        }

        public static bool EliminarModuloRolPorId(Modulos_Tiene_Rol pModuloRol)
        {
            using (MotorReservasContexto ctx = new MotorReservasContexto())
            {
                Modulos_Tiene_Rol modulRol = (from context in ctx.Modulos_Tiene_Rol
                                              where context.IdRol == pModuloRol.IdRol && context.IdModulo == pModuloRol.IdModulo
                                              select context).FirstOrDefault();

                if (modulRol == null)
                    return false;
                else
                {
                    var qModRol = ctx.Entry(modulRol);
                    qModRol.State = System.Data.Entity.EntityState.Deleted;
                    return ctx.SaveChanges() > 0;
                }

            }
        }

        public static bool RegistrarModuloRol(Modulos_Tiene_Rol pModuloRol)
        {
            using (MotorReservasContexto ctx = new MotorReservasContexto())
            {
                pModuloRol.FechaRegistro = DateTime.Now;
                pModuloRol.Activo = true;
                ctx.Modulos_Tiene_Rol.Add(pModuloRol);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
