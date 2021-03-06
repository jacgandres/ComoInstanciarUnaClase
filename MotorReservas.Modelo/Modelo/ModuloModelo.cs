﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;


namespace MotorReservas.Modelo
{
    public class ModuloModelo
    {
        public static List<Modulo> ObtenerModulosRolesPorUsuario(int intUsuario)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var lstModulos = contexto.Database.SqlQuery<Modulo>("ObtenerModulosRolesPorUsuario @IdUsuario", intUsuario);

                    List<Modulo> resModulos = (from mod in lstModulos
                                               orderby mod.IdModulo
                                               select mod).ToList();
                    return resModulos;

                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                
            }
        }
    }
}
