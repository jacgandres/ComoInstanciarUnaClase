using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;
namespace MotorReservas.ModeloAdministrativo.ModeloAdministrativo
{
    public class RolModelo
    {
        public static List<Rol> ListarRoles()
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var ListaRol = from cntx in contexto.Rol
                                   orderby cntx.Nombre
                                   select cntx;

                    return ListaRol.ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static bool ActualizarRoles()
        {
            throw new NotImplementedException();
        }

        public static List<Rol> ObtenerRolesPorUsuario(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                List<Rol> roles = new List<Rol>();

                var qRoles = from rol in contexto.Database.SqlQuery<Rol>("ObtenerRolesPorUsuario @IdUsuario",
                                 new SqlParameter("IdUsuario", pUsuario.IdUsuario))
                             orderby rol.Nombre ascending
                             select rol;

                roles = qRoles.ToList();

                return roles;
            }
        }

        public static bool RegistrarRol(Rol pRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    pRol.FechaRegistro = DateTime.Now;
                    contexto.Rol.Add(pRol);
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool EliminarRol(Rol pRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var rol = contexto.Entry(pRol);
                    rol.State = System.Data.Entity.EntityState.Deleted;

                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool ActualizarRol(Rol pRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var rol = contexto.Entry(pRol);
                    rol.State = System.Data.Entity.EntityState.Deleted;

                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Rol ObtenerRolPorId(Rol pRol)
        {
            try
            {
                using (MotorReservasContexto contexto = new MotorReservasContexto())
                {

                    Rol qRol = (from rol in contexto.Rol
                                where rol.IdRol == pRol.IdRol
                                select rol).FirstOrDefault();

                    return qRol;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static List<Modulo> ObtenerModulosPorRol(Rol pRol)
        {
            try
            {
                using (MotorReservasContexto contexto = new MotorReservasContexto())
                {
                    List<Modulo> modulos = new List<Modulo>();

                    var qModulos = from mod in contexto.Database.SqlQuery<Modulo>("ObtenerModulosPorRol @IdRol",
                                     new SqlParameter("IdRol", pRol.IdRol))
                                   orderby mod.Nombre ascending
                                   select mod;

                    modulos = qModulos.ToList();

                    return modulos;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
