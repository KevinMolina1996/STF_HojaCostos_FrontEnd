using AppWebHojaCosto.Services;
using System;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class DesfileController : Controller
    {
        private DesfileService _services;

        public DesfileController()
        {
            _services = new DesfileService();
        }

        // GET: Desfile
        public ActionResult Seguimiento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultarReferencia(string Referencia, string Codigo)
        {
            try
            {
                string Descripcion = String.Empty, PrecMinimo = String.Empty, PrecMaximo = String.Empty, Costo = String.Empty, MargenBruto = String.Empty, Tipo = String.Empty;
                _services.ConsultaReferencia(Referencia, ref Descripcion, ref PrecMinimo, ref PrecMaximo, ref Costo, ref MargenBruto, ref Tipo);
                if (String.IsNullOrEmpty(Descripcion))
                {
                    return Json(new { warning = "No existen registros para la referencia ingresada.", Codigo }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Codigo, Descripcion, PrecMinimo, PrecMaximo, Costo, MargenBruto, Tipo }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = "X", mensaje = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}