using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class HojaSimuladaController : Controller
    {
        private HojaCostoService _services;

        public HojaSimuladaController()
        {
            _services = new HojaCostoService();
        }

        // GET: HojaSimulada
        public ActionResult Index(string Referencia)
        {
            HOJA_COSTO_SIMULADA model = _services._COSTO_SIMLUADA(Referencia);
            FormulaService _service_form = new FormulaService();
            ViewBag.formulas = _service_form.obtenerFormulas();
            ViewBag.parametros = _services.ListParametros(model.TBL_SIM_HOJA_COSTO_PN.SimHcMarcaS, model.TBL_SIM_HOJA_COSTO_PN.SimHcColeccionS
                                                            , model.TBL_SIM_HOJA_COSTO_PN.SimHcLineaS, model.TBL_SIM_HOJA_COSTO_PN.SimHcSubLineaS);
            return View(model);
        }

        [HttpPost]
        public ActionResult Guardar(HOJA_COSTO_SIMULADA model)
        {
            FormulaService _service_form = new FormulaService();

            string mensaje = _services.GuardarHojaSimulada(model);

            ViewBag.mensaje = mensaje;
            ViewBag.formulas = _service_form.obtenerFormulas();
            ViewBag.parametros = _services.ListParametros(model.TBL_SIM_HOJA_COSTO_PN.SimHcMarcaS, model.TBL_SIM_HOJA_COSTO_PN.SimHcColeccionS
                                                            , model.TBL_SIM_HOJA_COSTO_PN.SimHcLineaS, model.TBL_SIM_HOJA_COSTO_PN.SimHcSubLineaS);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult EjecutarFormula(string formula)
        {
            String mensaje = String.Empty;
            try
            {
                FormulaService service = new FormulaService();
                string result = "0";
                string url = HttpContext.Request.MapPath("~");
                result = service.testFormulaSQLLite(formula, url, ref mensaje);
                return Json(new { mensaje = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = "X", mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GenerarPdf(HOJA_COSTO_SIMULADA model)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPN.rdlc");
                localReport.EnableExternalImages = true;

                var data = _services.LST_COSTO_SIMLUADA(model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_HOJA_COSTO_PN",
                    Value = data.TBL_SIM_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_CONSUMO_TELAS",
                    Value = data.TBL_SIM_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_PROCESO",
                    Value = data.TBL_SIM_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_INS_ACC",
                    Value = data.TBL_SIM_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_ETIQ_MAR_EMP",
                    Value = data.TBL_SIM_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_MOD_CIF",
                    Value = data.TBL_SIM_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_RES_GEN_COS_PRD",
                    Value = data.TBL_SIM_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_RES_GAS_COS_DIS",
                    Value = data.TBL_SIM_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_ANALISIS_PREC",
                    Value = data.TBL_SIM_ANALISIS_PREC
                };
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
                var dataFile = Server.MapPath("~/Documents/" + model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS + ".pdf");
                System.IO.File.WriteAllBytes(dataFile, renderedBytes);

                //SendToPrinter(dataFile);
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", model);
            }

            //ViewBag.exito = "Proceso terminado correctamente";
            ViewBag.pdf = model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS + ".pdf";
            return View("Index", model);
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
        public virtual ActionResult ExportPDF(HOJA_COSTO_SIMULADA model)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPN.rdlc");

                localReport.EnableExternalImages = true;

                var data = _services.LST_COSTO_SIMLUADA(model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS);

                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_HOJA_COSTO_PN",
                    Value = data.TBL_SIM_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_CONSUMO_TELAS",
                    Value = data.TBL_SIM_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_PROCESO",
                    Value = data.TBL_SIM_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_INS_ACC",
                    Value = data.TBL_SIM_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_ETIQ_MAR_EMP",
                    Value = data.TBL_SIM_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_MOD_CIF",
                    Value = data.TBL_SIM_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_RES_GEN_COS_PRD",
                    Value = data.TBL_SIM_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_RES_GAS_COS_DIS",
                    Value = data.TBL_SIM_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_ANALISIS_PREC",
                    Value = data.TBL_SIM_ANALISIS_PREC
                };
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
                    return File(renderedBytes, "application/pdf", model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS + ".pdf");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", model);
            }
        }

        [HttpPost]
        public virtual ActionResult ExportExcel(HOJA_COSTO_SIMULADA model)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPN.rdlc");

                localReport.EnableExternalImages = true;

                var data = _services.LST_COSTO_SIMLUADA(model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_HOJA_COSTO_PN",
                    Value = data.TBL_SIM_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_CONSUMO_TELAS",
                    Value = data.TBL_SIM_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_PROCESO",
                    Value = data.TBL_SIM_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_INS_ACC",
                    Value = data.TBL_SIM_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_ETIQ_MAR_EMP",
                    Value = data.TBL_SIM_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_MOD_CIF",
                    Value = data.TBL_SIM_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_RES_GEN_COS_PRD",
                    Value = data.TBL_SIM_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_RES_GAS_COS_DIS",
                    Value = data.TBL_SIM_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_SIM_ANALISIS_PREC",
                    Value = data.TBL_SIM_ANALISIS_PREC
                };
                localReport.DataSources.Add(reportDataSource);

                string reportType = "Excel";
                string mimeType = "Excel";
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
                    return File(renderedBytes, "application/vnd.ms-excel", model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS + ".xls");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", model);
            }
        }

        [HttpPost]
        public ActionResult Volver(HOJA_COSTO_SIMULADA model)
        {
            return RedirectToAction("Index", "HojaEstandar", new { Referencia = model.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS });
        }
    }
}