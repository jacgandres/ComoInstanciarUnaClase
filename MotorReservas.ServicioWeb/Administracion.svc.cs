﻿using System;
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

        #region Seccion de servicios para Modulo

        public List<Modulo> ObtenerModulos()
        {
            return ModuloModelo.ObtenerModulos();
        }

        #endregion

        #region Seccion de servicios de Rol

        public List<Rol> ListarRoles()
        {
            return RolModelo.ListarRoles();
        }

        public List<Rol> ObtenerRolesPorUsuario(Usuario pUsuario)
        {
            return RolModelo.ObtenerRolesPorUsuario(pUsuario);
        }

        public bool RegistrarRol(Rol pRol)
        {
            return RolModelo.RegistrarRol(pRol);
        }
        public bool ActualizarRol(Rol pRol)
        {
            return RolModelo.ActualizarRol(pRol);
        }
        public bool EliminarRol(Rol pRol)
        {
            return RolModelo.EliminarRol(pRol);
        }
        public Rol ObtenerRolPorId(Rol pRol)
        {
            return RolModelo.ObtenerRolPorId(pRol);
        }
        public List<Modulo> ObtenerModulosPorRol(Rol pRol)
        {
            return RolModelo.ObtenerModulosPorRol(pRol);
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

        #region seccion de servicios de Modulo_Tiene_Rol

        public bool EliminarModuloRolPorId(Modulos_Tiene_Rol pModuloRol)
        {
            return Modulo_Tiene_RolModelo.EliminarModuloRolPorId(pModuloRol);
        }

        public bool RegistrarModuloRol(Modulos_Tiene_Rol pModuloRol)
        {
            return Modulo_Tiene_RolModelo.RegistrarModuloRol(pModuloRol);
        }
        #endregion

        #endregion
    }
}
