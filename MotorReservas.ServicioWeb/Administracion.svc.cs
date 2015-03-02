using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MotorReservas.Entidad;
using MotorReservas.ModeloAdministrativo;
using MotorReservas.ModeloAdministrativo.ModeloAdministrativo;

namespace MotorReservas.ServicioWeb
{
    public partial class Administracion : IAdministracion
    {
        #region Administracion de Usuarios

        public bool RegistrarUsuario(Usuario pUsuario)
        {
            return UsuarioModelo.Insertar(pUsuario);
        }

        public List<Usuario> ListarUsuarios()
        {
           return UsuarioModelo.ListarUsuarios();
        }
        
        public bool ActualizarUsuario(Usuario pUsuario)
        {
            return UsuarioModelo.ActualizarUsuario(pUsuario);
        }

        public bool EliminarUsuario(Usuario pUsuario)
        {
            return UsuarioModelo.EliminarUsuario(pUsuario);
        }

        public Usuario IniciarSesionUsuario(Usuario pUsuario)
        {
            return UsuarioModelo.IniciarSesionUsuario(pUsuario);
        }

        public Usuario ObtenerUsuarioPorId(Usuario pUsuario)
        {
            return UsuarioModelo.ObtenerUsuarioPorId(pUsuario);
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return UsuarioModelo.ObtenerEmpresas();
        }

        public List<Modulo> ObtenerModulosRolPorUsuario(Usuario pUsuario)
        {
            return ModuloModelo.ObtenerModulosRolesPorUsuario(pUsuario.IdUsuario);
        }

        public bool Insertar(Rol pRol)
        {
            return RolModelo.Insertar(pRol);
        }

        public List<Rol> ListarRoles()
        {
            return RolModelo.ListarRoles();
        }

        #endregion
    }
}
