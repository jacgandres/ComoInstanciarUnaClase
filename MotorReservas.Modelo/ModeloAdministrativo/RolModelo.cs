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
        public static bool Insertar(Rol pRol)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    contexto.Rol.Add(pRol);
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

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
    }
}
