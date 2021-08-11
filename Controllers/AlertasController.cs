using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class AlertasController : Controller
    {
        private AlertaService _service;

        public AlertasController()
        {
            _service = new AlertaService();
        }

        // GET: Alertas
        public ActionResult Index()
        {
            ALERTA model = new ALERTA();
            model.Marcas = GetSelectListItems(new List<string>());
            model.Colecciones = GetSelectListItems(new List<string>());
            model.Lineas = GetSelectListItems(new List<string>());
            model.Referencias = GetSelectListItems(new List<string>());
            return View(model);
        }

        public ActionResult ConsultarAlertas(ALERTA model)
        {
            var _model = _service.ConsultarAlertas(model.FechaInicio, model.FechaFin, model.Coleccion, model.Marca, model.Linea, model.Referencia);
            _model.Marcas = GetSelectListItems(new List<string>());
            _model.Colecciones = GetSelectListItems(new List<string>());
            _model.Lineas = GetSelectListItems(new List<string>());
            _model.Referencias = GetSelectListItems(new List<string>());
            if(_model.TBL_ALERTA == null || _model.TBL_ALERTA.Count() <= 0)
            {
                ViewBag.alerta = "No existen registros para mostrar";
            }

            return View("Index", _model);
        }

        [HttpPost]
        public ActionResult FiltroMarca()
        {
            var marcas = _service.ObtenerMarcas();
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Marca)
        {
            var coleccion = _service.ObtenerColeccion(Marca);
            return Json(coleccion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLinea(string Marca, string Coleccion)
        {
            var linea = _service.ObtenerLinea(Marca, Coleccion);
            return Json(linea, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroReferencia(string Marca, string Coleccion, string Linea)
        {
            var referencias = _service.ObtenerReferencia(Marca, Coleccion, Linea);
            return Json(referencias, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }

        public JsonResult LeerAlerta(int codigo)
        {
            _service.LeerAlerta(codigo);
            return new JsonResult { Data = codigo, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetNotificationContacts()
        {
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            NotificationComponent NC = new NotificationComponent();
            var list = NC.GetContacts(notificationRegisterTime);
            //update session here for get only new added contacts (notification)
            Session["LastUpdate"] = DateTime.Now;
            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}