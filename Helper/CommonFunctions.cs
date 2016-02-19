using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using MotorReserva.Entidad;
using MotorReservas.Entidad;

namespace Helper.FuncionesComun
{
    public class CommonFunctions
    {  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="pAction"></param>
        /// <param name="pUsuario"></param>
        /// <param name="pExc"></param>
        /// <param name="pParams"></param>
        public static void ExtendesExceptionProperties(string IdProducto, string pAction, Usuario pUsuario, Exception pExc, dynamic pParams)
        {
            string value = Helper.FuncionesComun.ConvercionXML.ObjectSerialize<dynamic>(pParams).ToString();
            pExc.Data.Add("appUsuarioCorreo", string.IsNullOrEmpty(pUsuario.Correo) ? "UnKnow" : pUsuario.Correo);
            pExc.Data.Add("appUsuarioNombre", string.IsNullOrEmpty(pUsuario.Nombre) ? "UnKnow" : pUsuario.Nombre);
            pExc.Data.Add("action", pAction);
            pExc.Data.Add("CodigoProducto", IdProducto);
            pExc.Data.Add("Params", value);
        }

    }  
}
