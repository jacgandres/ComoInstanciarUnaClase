using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using GenericCustomLog;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using MotorReserva.Entidad;
using MotorReservas.Entidad;
using MotorReservas.Entidad.Exceptions.Exceptions;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers.Administracion
{
    [IfLoggedActionAttribute]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult Acceder(string Correo, string Clave)
        {
            AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient();
            Usuario pUsuario = new Usuario();
            using (new GenericTracer("Trace", Correo, "LoginController.Acceder", "", ""))
            {
                if (ModelState.IsValid)
                {
                    FaultException faultExc = null;
                    Clave = Helper.HashHelper.MD5(Clave);
                    pUsuario.Clave = Clave;
                    pUsuario.Correo = Correo;
                    ResponseModel mResponse = null;
                    try
                    {
                        mResponse = new ResponseModel();
                        pUsuario = servicio.IniciarSesionUsuario(pUsuario);
                        if (pUsuario == null)
                            return Json(new { response = false, message = "El Correo o Clave tienen algun dato invalido." });
                        else
                        {
                            Helper.SessionHelper.AddUserToSession((pUsuario).IdUsuario.ToString());

                            mResponse.SetResponse(true);
                            mResponse.href = "home";

                            List<Modulo> modulos = servicio.ObtenerModulosRolPorUsuario(pUsuario);

                            Session["modulos"] = modulos;

                        }
                    }
                    catch (FaultException ServExc)
                    {
                        faultExc = ServExc;
                    }
                    catch (ServiceException servExc)
                    {
                        throw new ServiceException(servExc.CodigoError + "*" + servExc.Messages);
                    }
                    catch (NegocioException posBolivarcomponentExc)
                    {
                        throw new NegocioException(posBolivarcomponentExc.CodigoError + "*" + posBolivarcomponentExc.Messages);
                    }
                    catch (Exception exc)
                    {
                        Helper.FuncionesComun.CommonFunctions.ExtendesExceptionProperties("", "Acceder", pUsuario, exc, Correo + " " + Clave);
                        bool rethrow = ExceptionPolicy.HandleException(exc, "Politica Controlador");
                        throw;
                    }
                    finally
                    {
                        if (faultExc != null)
                            throw faultExc;
                    }
                    return Json(mResponse);
                }
                else
                    return Json(new { response = false, message = "Ocurrio un error con la validación del Formulario." });
            }
        }
    
	}
}