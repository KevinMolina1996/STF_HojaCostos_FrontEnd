using AppWebHojaCosto.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    [NoDirectAccess]
    public class DashBoardLvl1Controller : Controller
    {
        private DashBoardNivel1Service _service;

        public DashBoardLvl1Controller()
        {
            _service = new DashBoardNivel1Service();
        }

        [HttpPost]
        public ActionResult FiltroMarca()
        {
            var marcas = _service.obtenerMarcas();
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Tipo, string Marca)
        {
            var colecciones = _service.obtenerColecciones(Marca);
            return Json(colecciones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReferenciasAprobadasPN(string Id, string Marca, string Coleccion, string Fecha)
        {
            string aprobadas_pn;
            _service.ConsultarReferenciasAprobadasPN(Id, Marca, Coleccion, Fecha, out aprobadas_pn);
            return Json(aprobadas_pn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReferenciasAprobadasPNP(string Id, string Marca, string Coleccion, string Fecha)
        {
            string aprobadas_pnp;
            _service.ConsultarReferenciasAprobadasPNP(Id, Marca, Coleccion, Fecha, out aprobadas_pnp);
            return Json(aprobadas_pnp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConsultarFechas(string Marca, string Coleccion)
        {
            var fechas = _service.ConsultarFechas(Marca, Coleccion);
            return Json(fechas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConsultaPendientesVelocimetro(string Marca, string Coleccion)
        {
            string pendientes, completas, pendientes_pnp, completas_pnp, con_precio, sin_precio, con_precio_pnp, sin_precio_pnp, no_tracking;
            _service.ConsultaProductoAprobado(Marca, Coleccion, out pendientes, out completas, out pendientes_pnp, out completas_pnp, out con_precio, out sin_precio, 
                out con_precio_pnp, out sin_precio_pnp, out no_tracking);
            return Json(new { pendientes, completas, pendientes_pnp, completas_pnp, con_precio, sin_precio, con_precio_pnp, sin_precio_pnp, no_tracking }, JsonRequestBehavior.AllowGet);
        }

        // GET: DashBoardLvl1
        public ActionResult Graficos()
        {
            //string pendientes, completas, pendientes_pnp, completas_pnp;
            //_service.ConsultaProductoAprobado(out pendientes, out completas, out pendientes_pnp, out completas_pnp);
            //ViewBag.pendientes = pendientes;
            //ViewBag.completas = completas;
            //ViewBag.pendientes_pnp = pendientes_pnp;
            //ViewBag.completas_pnp = completas_pnp;
            return View();
        }

        [HttpPost]
        public JsonResult ChartPendientes(string Marca, string Coleccion)
        {
            List<object> iData = new List<object>();
            iData.Add(_service.PendientesProducidoStf("STUDIO F", Coleccion));
            iData.Add(_service.PendientesProducidoEla("ELA", Coleccion));
            //Source data returned as JSON
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ConsultarUltimaFecha(string Marca, string Coleccion)
        {
            string Fecha;
            _service.obtenerFecha(Marca, Coleccion, out Fecha);
            //Source data returned as JSON
            return Json(Fecha = null, JsonRequestBehavior.AllowGet);
        }
    }
}