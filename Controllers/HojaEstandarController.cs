using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    [NoDirectAccess]
    public class HojaEstandarController : Controller
    {
        private HojaCostoService _services;

        public HojaEstandarController()
        {
            _services = new HojaCostoService();
        }

        // GET: HojaEstandar
        public ActionResult Index(string Referencia)
        {
            HOJA_COSTO_ESTANDAR model = _services._COSTO_ESTANDAR(Referencia);
            return View(model);
        }

        [HttpPost]
        public ActionResult GenerarPdf(string Referencia)
        {
            try
            {
                string msgImpresion = string.Empty;
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPN.rdlc");
                localReport.EnableExternalImages = true;

                bool bo = _services.ValidaImpresion(Referencia, ref msgImpresion);
                if (!bo)
                {
                    HOJA_COSTO_ESTANDAR data = _services._COSTO_ESTANDAR(Referencia);
                    ReportDataSource reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_HOJA_COSTO_PN",
                        Value = data.TBL_HOJA_COSTO_PN
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_CONSUMO_TELAS",
                        Value = data.TBL_CONSUMO_TELAS
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_PROCESO",
                        Value = data.TBL_PROCESO
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_INS_ACC",
                        Value = data.TBL_INS_ACC
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_ETIQ_MAR_EMP",
                        Value = data.TBL_ETIQ_MAR_EMP
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_MOD_CIF",
                        Value = data.TBL_MOD_CIF
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_RES_GEN_COS_PRD",
                        Value = data.TBL_RES_GEN_COS_PRD
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_RES_GAS_COS_DIS",
                        Value = data.TBL_RES_GAS_COS_DIS
                    };
                    localReport.DataSources.Add(reportDataSource);

                    reportDataSource = new ReportDataSource
                    {
                        Name = "TBL_ANALISIS_PREC",
                        Value = data.TBL_ANALISIS_PREC
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
                    string dataFile = Server.MapPath("~/Documents/" + Referencia + ".pdf");
                    System.IO.File.WriteAllBytes(dataFile, renderedBytes);

                    //SendToPrinter(dataFile);
                }
                else
                {
                    ViewBag.alerta = msgImpresion;
                    return View("Index", modelo(Referencia));
                }
            }
            catch (Exception ex)
            {
                //ViewBag.error = "Ocurrio un error al procesar la solicitud";
                ViewBag.error = ex.Message.ToString();
                return View("Index", modelo(Referencia));
            }

            //ViewBag.exito = "Proceso terminado correctamente";
            ViewBag.pdf = Referencia + ".pdf";
            return View("Index", modelo(Referencia));
        }

        private void SendToPrinter(string pdf)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = pdf;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Normal;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                if (false == p.CloseMainWindow())
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public virtual ActionResult ExportPDF(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPN.rdlc");

                localReport.EnableExternalImages = true;

                HOJA_COSTO_ESTANDAR data = _services._COSTO_ESTANDAR(Referencia);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_HOJA_COSTO_PN",
                    Value = data.TBL_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_CONSUMO_TELAS",
                    Value = data.TBL_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PROCESO",
                    Value = data.TBL_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_INS_ACC",
                    Value = data.TBL_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_ETIQ_MAR_EMP",
                    Value = data.TBL_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_MOD_CIF",
                    Value = data.TBL_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_RES_GEN_COS_PRD",
                    Value = data.TBL_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_RES_GAS_COS_DIS",
                    Value = data.TBL_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_ANALISIS_PREC",
                    Value = data.TBL_ANALISIS_PREC
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
            catch (Exception)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", modelo(Referencia));
            }
        }

        [HttpPost]
        public virtual ActionResult ExportExcel(string Referencia)
        {
            try
            {
                //Ejecuto el reporte para obtener el informe en bytes
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPN.rdlc");

                localReport.EnableExternalImages = true;

                HOJA_COSTO_ESTANDAR data = _services._COSTO_ESTANDAR(Referencia);
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "TBL_HOJA_COSTO_PN",
                    Value = data.TBL_HOJA_COSTO_PN
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_CONSUMO_TELAS",
                    Value = data.TBL_CONSUMO_TELAS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_PROCESO",
                    Value = data.TBL_PROCESO
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_INS_ACC",
                    Value = data.TBL_INS_ACC
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_ETIQ_MAR_EMP",
                    Value = data.TBL_ETIQ_MAR_EMP
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_MOD_CIF",
                    Value = data.TBL_MOD_CIF
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_RES_GEN_COS_PRD",
                    Value = data.TBL_RES_GEN_COS_PRD
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_RES_GAS_COS_DIS",
                    Value = data.TBL_RES_GAS_COS_DIS
                };
                localReport.DataSources.Add(reportDataSource);

                reportDataSource = new ReportDataSource
                {
                    Name = "TBL_ANALISIS_PREC",
                    Value = data.TBL_ANALISIS_PREC
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
            catch (Exception)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", modelo(Referencia));
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
                ViewBag.error = "Errores en las referencias: " + errores;
                return View("Index", modelo(Referencia));
            }
            else
            {
                ViewBag.exito = "Proceso terminado correctamente";
            }
            return View("Index", modelo(Referencia));
        }

        public HOJA_COSTO_ESTANDAR modelo(string Referencia)
        {
            try
            {
                HOJA_COSTO_ESTANDAR model = new HOJA_COSTO_ESTANDAR();
                model = _services._COSTO_ESTANDAR(Referencia);
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}