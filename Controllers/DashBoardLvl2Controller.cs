using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class DashBoardLvl2Controller : Controller
    {
        private DashBoardNivel2Service _services;

        public DashBoardLvl2Controller()
        {
            _services = new DashBoardNivel2Service();
        }

        // GET: DashBoardLvl2
        public ActionResult Consulta()
        {
            DASHBOARDLVL2 model = new DASHBOARDLVL2();
            model.Marcas = GetSelectListItems(new List<string>());
            model.Colecciones = GetSelectListItems(new List<string>());
            model.Lineas = GetSelectListItems(new List<string>());
            model.Sublineas = GetSelectListItems(new List<string>());
            return View(model);
        }

        //Producido
        [HttpPost]
        public ActionResult FiltroMarca()
        {
            var marcas = _services.obtenerMarcas();
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Marca)
        {
            var colecciones = _services.obtenerColecciones(Marca);
            return Json(colecciones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLinea(string Marca, string Coleccion)
        {
            var lineas = _services.obtenerLineas(Marca, Coleccion);
            return Json(lineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroSublinea(string Marca, string Coleccion, string Linea)
        {
            var sublineas = _services.obtenerSublineas(Marca, Coleccion, Linea);
            return Json(sublineas, JsonRequestBehavior.AllowGet);
        }

        //Precosteo
        [HttpPost]
        public ActionResult FiltroMarcaPrecosteo()
        {
            var marcas = _services.obtenerMarcasPrecosteo();
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccionPrecosteo(string Marca)
        {
            var colecciones = _services.obtenerColeccionesPrecosteo(Marca);
            return Json(colecciones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLineaPrecosteo(string Marca, string Coleccion)
        {
            var lineas = _services.obtenerLineasPrecosteo(Marca, Coleccion);
            return Json(lineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroSublineaPrecosteo(string Marca, string Coleccion, string Linea)
        {
            var sublineas = _services.obtenerSublineasPrecosteo(Marca, Coleccion, Linea);
            return Json(sublineas, JsonRequestBehavior.AllowGet);
        }

        //No Producido
        [HttpPost]
        public ActionResult FiltroMarcaNoProducido()
        {
            var marcas = _services.obtenerMarcasNoProducido();
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccionNoProducido(string Marca)
        {
            var colecciones = _services.obtenerColeccionesNoProducido(Marca);
            return Json(colecciones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLineaNoProducido(string Marca, string Coleccion)
        {
            var lineas = _services.obtenerLineasNoProducido(Marca, Coleccion);
            return Json(lineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroSublineaNoProducido(string Marca, string Coleccion, string Linea)
        {
            var sublineas = _services.obtenerSublineasNoProducido(Marca, Coleccion, Linea);
            return Json(sublineas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConsultarProducido(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            try
            {
                DASHBOARDLVL2 model = _services.ConsultarProducido(Marca, Coleccion, Linea, Sublinea);
                string viewContent = ConvertViewToString("_ListaProducido", model);
                return Json(new { PartialView = viewContent, mensaje = "" });
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Ocurrio un error en el sistema." });
            }
        }

        [HttpPost]
        public ActionResult ConsultarPrecosteo(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            try
            {
                DASHBOARDLVL2 model = _services.ConsultarPrecosteo(Marca, Coleccion, Linea, Sublinea);
                string viewContent = ConvertViewToString("_ListaPrecosteo", model);
                return Json(new { PartialView = viewContent, mensaje = "" });
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Ocurrio un error en el sistema." });
            }
        }

        [HttpPost]
        public ActionResult ConsultarNoProducido(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            try
            {
                DASHBOARDLVL2 model = _services.ConsultarNoProducido(Marca, Coleccion, Linea, Sublinea);
                string viewContent = ConvertViewToString("_ListaNoProducido", model);
                return Json(new { PartialView = viewContent, mensaje = "" });
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = "Ocurrio un error en el sistema." });
            }
        }

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

        private List<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
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
    }
}