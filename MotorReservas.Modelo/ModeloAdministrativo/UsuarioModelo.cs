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
                                        orderby cntx.Nombre
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
                    if (pUsuario.FechaUltimaSesion == null)
                        pUsuario.FechaUltimaSesion = (from cont in contexto.Usuario
                                                        where cont.IdUsuario == pUsuario.IdUsuario
                                                        select cont.FechaUltimaSesion).FirstOrDefault();

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
                    var usr = contexto.Entry(pUsuario);
                    usr.State = System.Data.Entity.EntityState.Deleted;
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Usuario IniciarSesionUsuario(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var usuarioLogeado = from usr in contexto.Usuario
                                         where usr.Correo == pUsuario.Correo && usr.Clave == pUsuario.Clave
                                         select usr;

                    Usuario respuestaUI = usuarioLogeado.FirstOrDefault();

                    if (respuestaUI != null)
                    {
                        respuestaUI.FechaUltimaSesion = DateTime.Now;
                        ActualizarUsuario(respuestaUI);
                    }

                    return respuestaUI;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Usuario ObtenerUsuarioPorId(Usuario pUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var listaUsuario = from cntx in contexto.Usuario
                                       where cntx.IdUsuario == pUsuario.IdUsuario
                                       select cntx;

                    return listaUsuario.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static List<Empresa> ObtenerEmpresas()
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var listaEmpresas = from cntx in contexto.Empresa
                                        orderby cntx.Nombre
                                        where cntx.Activo == true
                                        select cntx;

                    return listaEmpresas.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
