using AppWebHojaCosto.Models.Json;
using AppWebHojaCosto.Models.Response;
using AppWebHojaCosto.Services;
using ClassLibraryService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class SincronizacionController : Controller
    {
        private SincService _service;

        public SincronizacionController()
        {
            _service = new SincService();
        }

        // GET: Sincronizacion
        public ActionResult Parametrizar()
        {
            return View();
        }

        public ActionResult Consulta(string Inventario)
        {
            List<Models.TBL_REF_SINC> lista = _service.ConsultarRefSinc(Inventario);
            return View(lista);
        }

        [HttpPost]
        public ActionResult Carga(HttpPostedFileBase file)
        {
            try
            {
                _service.ActualizarReferencias(file);
                return Json("ok");
            }
            catch (Exception)
            {
                return Json("error");
            }
        }

        [HttpPost]
        public ActionResult SincronizacionManual(string Inventario, string Referencia)
        {
            HelperResponse _response = new HelperResponse();
            try
            {
                RunProcessService service = new RunProcessService();
                var respuesta = service.RunService(Referencia, Inventario);

                if (!respuesta)
                {
                    return Json(new { estado = 0, mensaje = "Proceso finalizado con problemas, por favor intente nuevamente."/*ex.Message.ToString()*/ });
                }
            }
            catch (Exception)
            {
                return Json(new { estado = 0, mensaje = "Error en comunicación con el servicio, intente nuevamente."/*ex.Message.ToString()*/ });
            }
            return Json(new { estado = 1, mensaje = "El proceso finalizó correctamente" });
        }
    }
}