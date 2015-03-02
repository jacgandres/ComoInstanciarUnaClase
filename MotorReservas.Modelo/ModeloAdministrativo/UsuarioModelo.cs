using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;


namespace MotorReservas.ModeloAdministrativo.ModeloAdministrativo
{
    public class UsuarioModelo
    {
        public static bool Insertar(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    contexto.Usuario.Add(pUsuario);
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static List<Usuario> ListarUsuarios()
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var listaUsuarios = from cntx in contexto.Usuario
                                        orderby cntx.User
                                        select cntx;

                    return listaUsuarios.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool ActualizarUsuario(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var User = contexto.Entry(pUsuario);
                    User.State = System.Data.Entity.EntityState.Modified;
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool EliminarUsuario(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    contexto.Usuario.Remove(pUsuario);
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static List<object> IniciarSesionUsuario(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var usuarioLogeado = from usr in contexto.Usuario
                                         where usr.Correo == pUsuario.Correo
                                         && usr.Clave == pUsuario.Clave
                                         select usr;

                    Usuario respuestaUI = usuarioLogeado.FirstOrDefault();
                    List<object> respuesta = new List<object>();

                    if (respuestaUI != null)
                    {
                        respuestaUI.FechaUltimoRegistro = DateTime.Now;
                        ActualizarUsuario(respuestaUI);
                        respuesta.Add(respuestaUI);

                        List<Modulo> modulos = ModuloModelo.ObtenerModulosRolesPorUsuario(respuestaUI.IdUsuario);

                        if (modulos != null && modulos.Count > 0)
                            respuesta.Add(modulos);
                    }

                    return respuesta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
