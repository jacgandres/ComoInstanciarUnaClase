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
        [OperationContract]
        bool RegistrarUsuario(Usuario pUsuario);
        [OperationContract]
        List<Usuario> ListarUsuarios();
        [OperationContract]
        bool ActualizarUsuario(Usuario pUsuario);
        [OperationContract]
        bool EliminarUsuario(Usuario pUsuario);

        [OperationContract]
        List<object> IniciarSesionUsuario(Usuario pUsuario);
        [OperationContract]
        List<Rol> ListarRoles();
        [OperationContract]
        bool Insertar(Rol pRol);
    }
}
