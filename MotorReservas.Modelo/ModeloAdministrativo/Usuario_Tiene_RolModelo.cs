using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;

namespace MotorReservas.ModeloAdministrativo
{
    public class Usuario_Tiene_RolModelo
    {
        public static bool VerificarUsuarioTieneRol(Usuario_Tiene_Rol pUsuarioRol)
        {
            using(MotorReservasContexto contexto = new MotorReservasContexto())
            {
                var tieneUsurioRol = from ctx in contexto.Usuario_Tiene_Rol
                                     where ctx.IdUsuario == pUsuarioRol.IdUsuario && ctx.IdRol == pUsuarioRol.IdRol
                                     select ctx;

                return tieneUsurioRol.FirstOrDefault() == null;
            }
        }

        public static bool IngresarRolUsuario(Usuario_Tiene_Rol pUsuarioRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                contexto.Usuario_Tiene_Rol.Add(pUsuarioRol); 
                return contexto.SaveChanges() > 0;
            }
        }

        public static bool EliminarRolUsuario(Usuario_Tiene_Rol pUsuarioRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                var usuarioRol = (from ctx in contexto.Usuario_Tiene_Rol
                                 where ctx.IdUsuario == pUsuarioRol.IdUsuario && ctx.IdRol == pUsuarioRol.IdRol
                                  select ctx).FirstOrDefault();
                if (usuarioRol != null)
                {
                    var entidad = contexto.Entry(usuarioRol);
                    entidad.State = System.Data.Entity.EntityState.Deleted;
                    return contexto.SaveChanges() > 0;
                }
                else
                    return false;
            }
        }
    }
}
