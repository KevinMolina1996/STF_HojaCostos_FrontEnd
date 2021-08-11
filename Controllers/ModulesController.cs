using AppWebHojaCosto.Models;
using AppWebHojaCosto.Models.Json;
using AppWebHojaCosto.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class ModulesController : Controller
    {
        // GET: Modules
        public ActionResult Index()
        {
            string json = JSONOutput.POSTJson(JSONOutput.GETUrl("ConsultaTodosModulos", null));
            List<Modulos> lstModulos = JsonConvert.DeserializeObject<List<Modulos>>(json);
            return View(lstModulos);
        }

        [HttpPost]
        public ActionResult CrearModulo(String txtNombre, String txtDescrip, Boolean cbEstado)
        {
            //Creacion de modulos
            HelperResponse helper = new HelperResponse();
            string json = JSONOutput.POSTJson(JSONOutput.GETUrl("InsertarModulos", new object[]{
                "MoNombreS=" + txtNombre,
                "&MoDescripS=" + txtDescrip,
                "&MoEstadoB=" + cbEstado
            }));
            List<HelperResponse> _response = JsonConvert.DeserializeObject<List<HelperResponse>>(json);

            return Json(new { respuesta = _response[0]._respuesta, mensaje = _response[0]._mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ActualizarModulo(Int32 intCodMod, String txtNombre, String txtDescrip, Boolean cbEstado)
        {
            HelperResponse helper = new HelperResponse();
            string json = JSONOutput.POSTJson(JSONOutput.GETUrl("ActualizarModulos", new object[]{
                "MoCodigoN=" + intCodMod,
                "&MoNombreS=" + txtNombre,
                "&MoDescripS=" + txtDescrip,
                "&MoEstadoB=" + cbEstado
            }));
            List<HelperResponse> _response = JsonConvert.DeserializeObject<List<HelperResponse>>(json);

            return Json(new { respuesta = _response[0]._respuesta, mensaje = _response[0]._mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarModulo(Int32 txtCodigo)
        {
            HelperResponse helper = new HelperResponse();
            string json = JSONOutput.POSTJson(JSONOutput.GETUrl("EliminarModulos", new object[]{
                "MoCodigoN=" + txtCodigo
            }));
            List<HelperResponse> _response = JsonConvert.DeserializeObject<List<HelperResponse>>(json);

            return Json(new { respuesta = _response[0]._respuesta, mensaje = _response[0]._mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}