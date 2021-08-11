using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class HojaNoProducidoSimuladaController : Controller
    {
        private HojaCostoSimPNPService _services;

        public HojaNoProducidoSimuladaController()
        {
            _services = new HojaCostoSimPNPService();
        }

        public TBL_SIM_HOJA_COSTO_PNP Modelo(string Referencia)
        {
            var model = _services._HOJA_COSTO_PNP(Referencia);

            FormulaService _service_form = new FormulaService();
            ViewBag.formulas = _service_form.obtenerFormulasPNP();
            ViewBag.parametros = _services.ListParametrosPNP(model.SimPnpMarcaS, model.SimPnpColeccionS, model.SimPnpLineaS, model.SimPnpSubLineaS);

            return model;
        }

        // GET: HojaNoProducidoSimulada
        public ActionResult Index(string Referencia)
        {
            ViewBag.error = TempData["Error"];
            ViewBag.exito = TempData["Exito"];
            //var model = _services._HOJA_COSTO_PNP(Referencia);

            //FormulaService _service_form = new FormulaService();
            //ViewBag.formulas = _service_form.obtenerFormulasPNP();
            //ViewBag.parametros = _services.ListParametrosPNP(model.SimPnpMarcaS, model.SimPnpColeccionS, model.SimPnpLineaS, model.SimPnpSubLineaS);
            return View(Modelo(Referencia));
        }

        [HttpPost]
        public ActionResult Guardar(TBL_SIM_HOJA_COSTO_PNP model)
        {
            FormulaService _service_form = new FormulaService();

            string mensaje = _services.Guardar(model);

            ViewBag.mensaje = mensaje;
            ViewBag.formulas = _service_form.obtenerFormulasPNP();
            ViewBag.parametros = _services.ListParametrosPNP(model.SimPnpMarcaS, model.SimPnpColeccionS, model.SimPnpLineaS, model.SimPnpSubLineaS);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult EjecutarFormula(string formula)
        {
            String mensaje = String.Empty;
            try
            {
                string url = HttpContext.Request.MapPath("~");
                FormulaService service = new FormulaService();
                string result = "0";
                result = service.testFormulaSQLLite(formula.Replace("$", ""), url, ref mensaje);
                Double valor = Convert.ToDouble(result.Replace(".", ","));
                return Json(new { mensaje = valor }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = "X", mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GenerarPdf(TBL_SIM_HOJA_COSTO_PNP model)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPNP.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsHojaCostoPNP";

                var data = _services._LST__HOJA_SIM_COSTO_PNP(model.SimPnpReferenciaS);
                reportDataSource.Value = data;

                localReport.EnableExternalImages = true;
                localReport.DataSources.Add(reportDataSource);
                string reportType = "PDF";
                string mimeType = "PDF";
                string encoding;
                string fileNameExtension;
                string deviceInfo = "";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                //Renderizo el reporte en bytes para luego enviarse a imprimir
                renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                //Guardo el archivo en formato pdf para su impresion posterior
                var dataFile = Server.MapPath("~/Documents/" + model.SimPnpReferenciaS + ".pdf");
                System.IO.File.WriteAllBytes(dataFile, renderedBytes);

                //ImprimirPdf(dataFile);
                //SendToPrinter(dataFile);
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                //return View("Index", model);
                return View("Index", Modelo(model.SimPnpReferenciaS));
            }

            ViewBag.pdf = model.SimPnpReferenciaS + ".pdf";
            //ViewBag.exito = "Proceso terminado correctamente";
            return View("Index", Modelo(model.SimPnpReferenciaS));
            //return View("Index", model);
        }

        private void SendToPrinter(string pdf)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = pdf;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
        }

        [HttpPost]
        public virtual ActionResult ExportExcel(TBL_SIM_HOJA_COSTO_PNP model)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPNP.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsHojaCostoPNP";

                var data = _services._LST__HOJA_SIM_COSTO_PNP(model.SimPnpReferenciaS);
                reportDataSource.Value = data;

                localReport.EnableExternalImages = true;
                localReport.DataSources.Add(reportDataSource);
                string reportType = "excel";
                string mimeType = "excel";
                string encoding;
                string fileNameExtension;
                string deviceInfo = "";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                //Renderizo el reporte en bytes para luego descargarse en formato excel
                renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                using (MemoryStream output = new MemoryStream())
                {
                    ViewBag.exito = "Proceso terminado correctamente";
                    return File(renderedBytes, "application/vnd.ms-excel", model.SimPnpReferenciaS + ".xls");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", Modelo(model.SimPnpReferenciaS));
            }
        }

        [HttpPost]
        public virtual ActionResult ExportPDF(TBL_SIM_HOJA_COSTO_PNP model)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPNP.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsHojaCostoPNP";
                var data = _services._LST__HOJA_SIM_COSTO_PNP(model.SimPnpReferenciaS);
                reportDataSource.Value = data;
                localReport.EnableExternalImages = true;
                localReport.DataSources.Add(reportDataSource);
                string reportType = "PDF";
                string mimeType = "PDF";
                string encoding;
                string fileNameExtension;
                string deviceInfo = "";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                //Renderizo el reporte en bytes para luego descargarse en formato excel
                renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                using (MemoryStream output = new MemoryStream())
                {
                    ViewBag.exito = "Proceso terminado correctamente";
                    return File(renderedBytes, "application/pdf", model.SimPnpReferenciaS + ".pdf");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", Modelo(model.SimPnpReferenciaS));
            }
        }
    }
}