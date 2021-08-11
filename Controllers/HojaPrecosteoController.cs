using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class HojaPrecosteoController : Controller
    {
        private HojaCostoService _services;

        public HojaPrecosteoController()
        {
            _services = new HojaCostoService();
        }

        public HOJA_COSTO_PRECOSTEO Modelo(string Referencia)
        {
            HOJA_COSTO_PRECOSTEO model = _services._COSTO_PRECOSTEO(Referencia);
            FormulaService _service_form = new FormulaService();
            var modelparam = _services.ListParametros(model.TBL_PRE_HOJA_COSTO_PN.PreHcMarcaS, model.TBL_PRE_HOJA_COSTO_PN.PreHcColeccionS
                                                            , model.TBL_PRE_HOJA_COSTO_PN.PreHcLineaS, model.TBL_PRE_HOJA_COSTO_PN.PreHcSubLineaS);
            if (modelparam.Count > 0)
            {
                ViewBag.parametros = modelparam;
                ViewBag.formulas = _service_form.obtenerFormulasPrecosteo();
            }
            else
            {
                ViewBag.mensaje = "Formulación dinámica inhabilitada, ya que no existen parametros para la referencia.";
            }
            return model;
        }

        // GET: HojaPrecosteo
        public ActionResult Index(string Referencia)
        {
            //HOJA_COSTO_PRECOSTEO model = _services._COSTO_PRECOSTEO(Referencia);
            //FormulaService _service_form = new FormulaService();
            //var modelparam = _services.ListParametros(model.TBL_PRE_HOJA_COSTO_PN.PreHcMarcaS, model.TBL_PRE_HOJA_COSTO_PN.PreHcColeccionS
            //                                                , model.TBL_PRE_HOJA_COSTO_PN.PreHcLineaS, model.TBL_PRE_HOJA_COSTO_PN.PreHcSubLineaS);
            //if(modelparam.Count > 0)
            //{
            //    ViewBag.parametros = modelparam;
            //    ViewBag.formulas = _service_form.obtenerFormulasPrecosteo();
            //}
            //else
            //{
            //    ViewBag.mensaje = "Formulación dinámica inhabilitada, ya que no existen parametros para la referencia.";
            //}
            return View(Modelo(Referencia));
        }

        [HttpPost]
        public ActionResult Guardar(HOJA_COSTO_PRECOSTEO model)
        {
            FormulaService _service_form = new FormulaService();

            string mensaje = _services.GuardarHojaPrecosteo(model);

            ViewBag.mensaje = mensaje;

            var modelparam = _services.ListParametros(model.TBL_PRE_HOJA_COSTO_PN.PreHcMarcaS, model.TBL_PRE_HOJA_COSTO_PN.PreHcColeccionS
                                                            , model.TBL_PRE_HOJA_COSTO_PN.PreHcLineaS, model.TBL_PRE_HOJA_COSTO_PN.PreHcSubLineaS);
            if (modelparam.Count > 0)
            {
                ViewBag.parametros = modelparam;
                ViewBag.formulas = _service_form.obtenerFormulasPrecosteo();
            }
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
        public ActionResult GenerarPdf(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPrePN.rdlc");
                localReport.EnableExternalImages = true;

                var data = _services.LST_COSTO_PRECOSTEO(Referencia);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_HOJA_COSTO_PN",
                    Value = data.TBL_PRE_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_CONSUMO_TELAS",
                    Value = data.TBL_PRE_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_PROCESO",
                    Value = data.TBL_PRE_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_INS_ACC",
                    Value = data.TBL_PRE_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_ETIQ_MAR_EMP",
                    Value = data.TBL_PRE_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_MOD_CIF",
                    Value = data.TBL_PRE_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_RES_GEN_COS_PRD",
                    Value = data.TBL_PRE_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_RES_GAS_COS_DIS",
                    Value = data.TBL_PRE_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_ANALISIS_PREC",
                    Value = data.TBL_PRE_ANALISIS_PREC
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
                var dataFile = Server.MapPath("~/Documents/" + Referencia + ".pdf");
                System.IO.File.WriteAllBytes(dataFile, renderedBytes);

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
        public virtual ActionResult ExportPDF(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPrePN.rdlc");

                localReport.EnableExternalImages = true;

                var data = _services.LST_COSTO_PRECOSTEO(Referencia);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_HOJA_COSTO_PN",
                    Value = data.TBL_PRE_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_CONSUMO_TELAS",
                    Value = data.TBL_PRE_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_PROCESO",
                    Value = data.TBL_PRE_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_INS_ACC",
                    Value = data.TBL_PRE_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_ETIQ_MAR_EMP",
                    Value = data.TBL_PRE_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_MOD_CIF",
                    Value = data.TBL_PRE_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_RES_GEN_COS_PRD",
                    Value = data.TBL_PRE_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_RES_GAS_COS_DIS",
                    Value = data.TBL_PRE_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_ANALISIS_PREC",
                    Value = data.TBL_PRE_ANALISIS_PREC
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
        public virtual ActionResult ExportExcel(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPrePN.rdlc");

                localReport.EnableExternalImages = true;

                var data = _services.LST_COSTO_PRECOSTEO(Referencia);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_HOJA_COSTO_PN",
                    Value = data.TBL_PRE_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_CONSUMO_TELAS",
                    Value = data.TBL_PRE_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_PROCESO",
                    Value = data.TBL_PRE_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_INS_ACC",
                    Value = data.TBL_PRE_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_ETIQ_MAR_EMP",
                    Value = data.TBL_PRE_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_MOD_CIF",
                    Value = data.TBL_PRE_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_RES_GEN_COS_PRD",
                    Value = data.TBL_PRE_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_RES_GAS_COS_DIS",
                    Value = data.TBL_PRE_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PRE_ANALISIS_PREC",
                    Value = data.TBL_PRE_ANALISIS_PREC
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
                    return File(renderedBytes, "application/vnd.ms-excel", Referencia + ".xls");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", Modelo(Referencia));
            }
        }
    }
}