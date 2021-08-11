using AppWebHojaCosto.Models.Json;
using AppWebHojaCosto.Models.Response;
using AppWebHojaCosto.Services;
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
                string json = JSONOutput.GETJson(JSONOutput.GETUrl("SincronizacionManual", new object[]{
                    "Inventario=" + Inventario,
                    "&Referencia=" + Referencia
                }));
                _response = JsonConvert.DeserializeObject<HelperResponse>(json);
            }
            catch (Exception)
            {
                return Json(new { estado = 0, mensaje = "Error en comunicación con el servicio, intente nuevamente."/*ex.Message.ToString()*/ });
            }
            return Json(new { estado = _response._respuesta, mensaje = _response._mensaje });
        }
    }
}