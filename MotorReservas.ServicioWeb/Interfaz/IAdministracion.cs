using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MotorReservas.Entidad;

namespace MotorReservas.ServicioWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdministracion" in both code and config file together.
    [ServiceContract]
    public interface IAdministracion
    {
        #region Seccion de servicios de Usuario
        [OperationContract]
        bool RegistrarUsuario(Usuario pUsuario);

        [OperationContract]
        List<Usuario> ListarUsuarios();

        [OperationContract]
        bool ActualizarUsuario(Usuario pUsuario);

        [OperationContract]
        bool EliminarUsuario(Usuario pUsuario);

        [OperationContract]
        List<Modulo> ObtenerModulosRolPorUsuario(Usuario pUsuario);

        [OperationContract]
        Usuario IniciarSesionUsuario(Usuario pUsuario);

        [OperationContract]
        Usuario ObtenerUsuarioPorId(Usuario pUsuario);
        #endregion       

        #region Seccion de servicios de Rol
        [OperationContract]
        List<Rol> ListarRoles();

        [OperationContract]
        List<Rol> ObtenerRolesPorUsuario(Usuario pUsuario);

        [OperationContract]
        bool RegistrarRol(Rol pRol);

        [OperationContract]
        bool ActualizarRol(Rol pRol);

        [OperationContract]
        bool EliminarRol(Rol pRol);

        [OperationContract]
        Rol ObtenerRolPorId(Rol pRol);

        [OperationContract]
        List<Modulo> ObtenerModulosPorRol(Rol pRol);
        #endregion

        #region Seccion de servicios de Usuarios_Tiene_Rol
        [OperationContract]
        bool VerificarUsuarioTieneRol(Usuario_Tiene_Rol pUsuarioRol);

        [OperationContract]
        bool IngresarRolUsuario(Usuario_Tiene_Rol pUsuarioRol);

        [OperationContract]
        bool EliminarRolUsuario(Usuario_Tiene_Rol pUsuarioRol);
        #endregion

        #region seccion de servicios de Modulo_Tiene_Rol

        [OperationContract]
        bool VerificarRolTieneModulo(Modulos_Tiene_Rol pModuloRol);

        [OperationContract]
        bool EliminarModuloRolPorId(Modulos_Tiene_Rol pModuloRol);

        [OperationContract]
        bool RegistrarModuloRol(Modulos_Tiene_Rol pModuloRol);
        #endregion

        #region Seccion de servicios para Modulo

        [OperationContract]
        List<Modulo> ObtenerModulos();

        [OperationContract]
        bool EliminarModulo(Modulo pModulo);

        [OperationContract]
        bool RegistrarModulo(Modulo pModulo);

        [OperationContract]
        bool ActualizarModulo(Modulo pModulo);

        [OperationContract]
        Modulo ObtenerModuloPorId(Modulo pModulo);
        #endregion

        #region Administracion Empresas

        [OperationContract]
        bool RegistrarEmpresa(Empresa pEmpresa);

        [OperationContract]
        bool EliminarEmpresa(Empresa pEmpresa);

        [OperationContract]
        Empresa ObtenerEmpresaPorId(Empresa pEmpresa);

        [OperationContract]
        List<Empresa> ObtenerEmpresas();

        [OperationContract]
        bool ActualizarEmpresa(Empresa pEmpresa);
        #endregion 
    }
}
