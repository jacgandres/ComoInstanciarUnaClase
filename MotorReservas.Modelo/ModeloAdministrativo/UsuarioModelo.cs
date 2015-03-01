using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;


namespace MotorReservas.Modelo.ModeloAdministrativo
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


    }
}
