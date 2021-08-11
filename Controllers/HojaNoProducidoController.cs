using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class HojaNoProducidoController : Controller
    {
        private HojaCostoPNPService _services;

        public HojaNoProducidoController()
        {
            _services = new HojaCostoPNPService();
        }

        public TBL_HOJA_COSTO_PNP Modelo(string Referencia)
        {
            TBL_HOJA_COSTO_PNP _model = _services._HOJA_COSTO_PNP(Referencia);
            return _model;
        }

        // GET: HojaNoProducido
        public ActionResult Index(string Referencia)
        {
            ViewBag.error = TempData["Error"];
            ViewBag.exito = TempData["Exito"];
            return View(Modelo(Referencia));
        }

        [HttpPost]
        public ActionResult GenerarPdf(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPNP.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsHojaCostoPNP";

                var data = _services._LST_HOJA_COSTO_PNP(Referencia);
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
                var dataFile = Server.MapPath("~/Documents/" + Referencia + ".pdf");
                System.IO.File.WriteAllBytes(dataFile, renderedBytes);

                //ImprimirPdf(dataFile);
                //SendToPrinter(dataFile);
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", Modelo(Referencia));
            }

            //ViewBag.exito = "Proceso terminado correctamente";
            ViewBag.pdf = Referencia + ".pdf";
            return View("Index", Modelo(Referencia));
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
        public virtual ActionResult ExportExcel(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPNP.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsHojaCostoPNP";

                var data = _services._LST_HOJA_COSTO_PNP(Referencia);
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
                    return File(renderedBytes, "application/vnd.ms-excel", Referencia + ".xls");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", Modelo(Referencia));
            }
        }

        [HttpPost]
        public virtual ActionResult ExportPDF(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPNP.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsHojaCostoPNP";
                var data = _services._LST_HOJA_COSTO_PNP(Referencia);
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
                    return File(renderedBytes, "application/pdf", Referencia + ".pdf");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", Modelo(Referencia));
            }
        }

        [HttpPost]
        public ActionResult CerrarHojas(string Referencia)
        {
            string TipoHoja = "CE"; // Tipo de hoja estandar
            List<string> result = _services.CerrarHojas("CERRADA", new List<string>() { Referencia }, TipoHoja);
            if (result.Count > 0)
            {
                string errores = string.Empty;
                foreach (string resul in result)
                {
                    errores = errores + resul;
                }
                //TempData["Error"] = "Errores en las referencias: " + errores;
                ViewBag.error = "Errores en las referencias: " + errores;
            }
            else
            {
                ViewBag.exito = "Proceso terminado correctamente";
                //TempData["Exito"] = "Proceso terminado correctamente";
            }
            return View("Index", Modelo(Referencia));
        }
    }
}