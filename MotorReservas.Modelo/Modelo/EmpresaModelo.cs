using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorReservas.Entidad;

namespace MotorReservas.ModeloAdministrativo
{
    public class EmpresaModelo
    {
        public static bool Insertar(Empresa pEmpresa)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            try
            {
                contexto.Empresa.Add(pEmpresa);
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                    
                throw ex;
            }
        }

        public static bool ActualizarEmpresa(Empresa pEmpresa)
        {

            using(MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var emp = contexto.Entry(pEmpresa);
                    emp.State = System.Data.Entity.EntityState.Modified;
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
        }

        public static bool EliminarEmpresa(Empresa pEmpresa)
        {
            using(MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var emp = contexto.Entry(pEmpresa);
                    emp.State = System.Data.Entity.EntityState.Deleted;
                    return contexto.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
        }

        public static Empresa ObtenerEmpresaPorId(Empresa pEmpresa)
        {
            using (MotorReservasContexto contexto = new MotorReservasContexto())
            {
                try
                {
                    var listaEmpresa = from cntx in contexto.Empresa
                                       where cntx.IdEmpresa == pEmpresa.IdEmpresa
                                       select cntx;

                    return listaEmpresa.FirstOrDefault();
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
