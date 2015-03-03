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

        #region Seccion de servicios de usuarios
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

        public List<Modulo> ObtenerModulosRolPorUsuario(Usuario pUsuario)
        {
            return ModuloModelo.ObtenerModulosRolesPorUsuario(pUsuario.IdUsuario);
        }
        #endregion

        public List<Empresa> ObtenerEmpresas()
        {
            return UsuarioModelo.ObtenerEmpresas();
        }

        #region Seccion de servicios de Rol
        public bool RegistrarRol(Rol pRol)
        {
            return RolModelo.Insertar(pRol);
        }

        public List<Rol> ListarRoles()
        {
            return RolModelo.ListarRoles();
        }

        public List<Rol> ObtenerRolesPorUsuario(Usuario pUsuario)
        {
            return RolModelo.ObtenerRolesPorUsuario(pUsuario);
        }
        #endregion

        #region Seccion de servicios de Usuarios_Tiene_Rol
        public bool VerificarUsuarioTieneRol(Usuario_Tiene_Rol pUsuarioRol)
        {
           return Usuario_Tiene_RolModelo.VerificarUsuarioTieneRol(pUsuarioRol);
        }

        public bool IngresarRolUsuario(Usuario_Tiene_Rol pUsuarioRol)
        {
            return Usuario_Tiene_RolModelo.IngresarRolUsuario(pUsuarioRol);
        }

        public bool EliminarRolUsuario(Usuario_Tiene_Rol pUsuarioRol)
        {
            return Usuario_Tiene_RolModelo.EliminarRolUsuario(pUsuarioRol);
        }

        #endregion
        #endregion
    }
}
