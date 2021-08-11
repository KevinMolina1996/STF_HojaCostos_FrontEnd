using AppWebHojaCosto.Controllers.Helpers;
using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using Ionic.Zip;
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
    public class HojaCostoPNController : Controller
    {
        private HojaCostoService _services;

        public HojaCostoPNController()
        {
            _services = new HojaCostoService();
        }

        public HOJA_COSTO_PN LoadModel()
        {
            HOJA_COSTO_PN model = new HOJA_COSTO_PN();
            return model;
        }

        public HOJA_COSTO_PN CargarTabla(HOJA_COSTO_PN model)
        {
            HOJA_COSTO_PN _model = _services._LST_COSTO_PN(model.TipoHojaCosto, model.TBL_HOJA_COSTO_PN.HcMarcaS, model.TBL_HOJA_COSTO_PN.HcColeccionS, model.TBL_HOJA_COSTO_PN.HcLineaS, model.TBL_HOJA_COSTO_PN.HcEstadoAproS);
            _model.TBL_HOJA_COSTO_PN = model.TBL_HOJA_COSTO_PN;
            return _model;
        }

        // GET: HojaCostoPN
        public ActionResult Index()
        {
            HOJA_COSTO_PN model = new HOJA_COSTO_PN();
            return View(model);
        }

        [HttpPost]
        public ActionResult ConsultarxRef(HOJA_COSTO_PN model)
        {
            if (model.TBL_HOJA_COSTO_PN.HcReferenciaS != null && model.TipoHojaCosto != null)
            {
                if (model.TipoHojaCosto == "CE")
                {
                    HOJA_COSTO_ESTANDAR _model = _services._COSTO_ESTANDAR(model.TBL_HOJA_COSTO_PN.HcReferenciaS);
                    if(_model.TBL_HOJA_COSTO_PN.Count > 0)
                    {
                        return RedirectToAction("Index", "HojaEstandar", new { Referencia = model.TBL_HOJA_COSTO_PN.HcReferenciaS });
                    }
                    else
                    {
                        ViewBag.cargar_listas = "X";
                        ViewBag.alerta = "La referencia no existe.";
                        return View("Index", model);
                    }
                }
                else if (model.TipoHojaCosto == "CS")
                {
                    HOJA_COSTO_SIMULADA _model = _services._COSTO_SIMLUADA(model.TBL_HOJA_COSTO_PN.HcReferenciaS);
                    if (_model.TBL_SIM_HOJA_COSTO_PN != null)
                    {
                        return RedirectToAction("Index", "HojaSimulada", new { Referencia = model.TBL_HOJA_COSTO_PN.HcReferenciaS });
                    }
                    else
                    {
                        ViewBag.cargar_listas = "X";
                        ViewBag.alerta = "La referencia no existe.";
                        return View("Index", model);
                    }
                }
                else if (model.TipoHojaCosto == "CP")
                {
                    HOJA_COSTO_PRECOSTEO _model = _services._COSTO_PRECOSTEO(model.TBL_HOJA_COSTO_PN.HcReferenciaS);
                    if (_model.TBL_PRE_HOJA_COSTO_PN != null)
                    {
                        return RedirectToAction("Index", "HojaPrecosteo", new { Referencia = model.TBL_HOJA_COSTO_PN.HcReferenciaS });
                    }
                    else
                    {
                        ViewBag.cargar_listas = "X";
                        ViewBag.alerta = "La referencia no existe.";
                        return View("Index", model);
                    }
                }
                return View("Index", model);
            }
            else
            {
                ViewBag.alerta = "Falta datos por diligenciar.";
                return View("Index", model);
            }
        }

        public ActionResult ConsultarxRef(string Tipo, string Referencia)
        {
            if (Referencia != null && Tipo != null)
            {
                if (Tipo == "CE")
                {
                    return RedirectToAction("Index", "HojaEstandar", new { Referencia = Referencia });
                }
                else if (Tipo == "CS")
                {
                    return RedirectToAction("Index", "HojaSimulada", new { Referencia = Referencia });
                }
                else if (Tipo == "CP")
                {
                    return RedirectToAction("Index", "HojaPrecosteo", new { Referencia = Referencia });
                }
                ViewBag.alerta = "Se presentaron problemas al cargar";
                return RedirectToAction("Index");
            }
            else
            {
                HOJA_COSTO_PN model = LoadModel();
                ViewBag.alerta = "Falta datos por diligenciar.";
                return View("Index", model);
            }
        }

        [HttpPost]
        public ActionResult ConsultaMasiva(HOJA_COSTO_PN model)
        {
            try
            {
                if(model.TipoHojaCosto == null || model.TipoHojaCosto == "")
                {
                    ViewBag.alerta = "Debe diligenciar el tipo de hoja de costos.";
                    return View("Index", model);
                }
                if (model.TipoHojaCosto != null && model.TBL_HOJA_COSTO_PN.HcMarcaS != null && model.TBL_HOJA_COSTO_PN.HcColeccionS != null)
                {
                    ViewBag.cargar_listas = "X";
                    HOJA_COSTO_PN _model = CargarTabla(model);
                    return View("Index", _model);
                }
                else
                {
                    ViewBag.alerta = "Falta datos por diligenciar.";
                    return View("Index", model);
                }
            }
            catch(Exception ex)
            {
                ViewBag.alerta = "Ocurrio un error al procesar la solicitud, detalle: " + ex.Message;
                return View("Index", model);
            }
        }

        [HttpPost]
        public ActionResult GenerarPdf(HOJA_COSTO_PN model, string Referencias)
        {
            Guid miGuid = Guid.NewGuid();
            string nombre = miGuid.ToString();
            try
            {
                Referencias = Referencias.TrimEnd('|');
                string[] split = Referencias.Split('|');
                List<string> archivos = new List<string>();
                foreach (string var in split)
                {
                    //Ejecuto el reporte para obtener el informe en bytes
                    LocalReport localReport = new LocalReport();
                    if (model.TipoHojaCosto == "CE")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPN.rdlc");
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPN.rdlc");
                    }
                    else if (model.TipoHojaCosto == "CP")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPrePN.rdlc");
                    }

                    localReport.EnableExternalImages = true;

                    if (model.TipoHojaCosto == "CE")
                    {
                        HOJA_COSTO_ESTANDAR data = _services._COSTO_ESTANDAR(var);
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
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        HOJA_COSTO_SIMULADA data = _services._COSTO_SIMLUADA(var);
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
                    }
                    else if (model.TipoHojaCosto == "CP")
                    {
                        HOJA_COSTO_PRECOSTEO data = _services._COSTO_PRECOSTEO(var);
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
                    }

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
                    string dataFile = Server.MapPath("~/Documents/" + var + ".pdf");
                    System.IO.File.WriteAllBytes(dataFile, renderedBytes);

                    archivos.Add(Server.MapPath("~/Documents/" + var + ".pdf"));

                    //SendToPrinter(dataFile);
                }
                CombinePDF.CombineMultiplePDFs(archivos, Server.MapPath("~/Documents/" + nombre + ".pdf"));
            }
            catch (Exception)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", LoadModel());
            }

            //ViewBag.exito = "Proceso terminado correctamente";
            ViewBag.pdf = nombre + ".pdf";
            return View("Index", CargarTabla(model));
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
                ViewBag.error = ex.Message.ToString();
            }
        }

        [HttpPost]
        public virtual ActionResult ExportPDF(HOJA_COSTO_PNP model, string Referencias)
        {
            try
            {
                ZipFile zip = new ZipFile();
                string nombreZip = "Hojas_costo.zip";
                Referencias = Referencias.TrimEnd('|');
                string[] split = Referencias.Split('|');
                foreach (string var in split)
                {
                    //Ejecuto el reporte para obtener el informe en bytes
                    LocalReport localReport = new LocalReport();
                    if (model.TipoHojaCosto == "CE")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPN.rdlc");
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPN.rdlc");
                    }
                    else if (model.TipoHojaCosto == "CP")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPrePN.rdlc");
                    }

                    localReport.EnableExternalImages = true;

                    if (model.TipoHojaCosto == "CE")
                    {
                        HOJA_COSTO_ESTANDAR data = _services._COSTO_ESTANDAR(var);
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
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        HOJA_COSTO_SIMULADA data = _services._COSTO_SIMLUADA(var);
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
                    }
                    else if (model.TipoHojaCosto == "CP")
                    {
                        HOJA_COSTO_PRECOSTEO data = _services._COSTO_PRECOSTEO(var);
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
                    }
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

                    //Guardo el archivo en bytes
                    zip.AddEntry(var + ".pdf", renderedBytes);
                }

                using (MemoryStream output = new MemoryStream())
                {
                    zip.Save(output);
                    ViewBag.exito = "Proceso terminado correctamente";
                    return File(output.ToArray(), "application/zip", nombreZip);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", LoadModel());
            }
        }

        [HttpPost]
        public virtual ActionResult ExportExcel(HOJA_COSTO_PNP model, string Referencias)
        {
            try
            {
                ZipFile zip = new ZipFile();
                string nombreZip = "Hojas_costo.zip";
                Referencias = Referencias.TrimEnd('|');
                string[] split = Referencias.Split('|');
                foreach (string var in split)
                {
                    //Ejecuto el reporte para obtener el informe en bytes
                    LocalReport localReport = new LocalReport();
                    if (model.TipoHojaCosto == "CE")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPN.rdlc");
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPN.rdlc");
                    }
                    else if (model.TipoHojaCosto == "CP")
                    {
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPrePN.rdlc");
                    }

                    localReport.EnableExternalImages = true;

                    if (model.TipoHojaCosto == "CE")
                    {
                        HOJA_COSTO_ESTANDAR data = _services._COSTO_ESTANDAR(var);
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
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        HOJA_COSTO_SIMULADA data = _services._COSTO_SIMLUADA(var);
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
                    }
                    else if (model.TipoHojaCosto == "CP")
                    {
                        HOJA_COSTO_PRECOSTEO data = _services._COSTO_PRECOSTEO(var);
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
                    }
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

                    //Guardo el archivo en bytes
                    zip.AddEntry(var + ".xls", renderedBytes);
                }

                using (MemoryStream output = new MemoryStream())
                {
                    zip.Save(output);
                    ViewBag.exito = "Proceso terminado correctamente";
                    return File(output.ToArray(), "application/zip", nombreZip);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", LoadModel());
            }
        }

        [HttpPost]
        public ActionResult CerrarHojas(HOJA_COSTO_PN model, string Referencias)
        {
            List<string> lstReferencias = new List<string>();
            Referencias = Referencias.TrimEnd('|');
            string[] split = Referencias.Split('|');
            foreach (string var in split)
            {
                lstReferencias.Add(var);
            }
            List<string> result = _services.CerrarHojas("CERRADA", lstReferencias, model.TipoHojaCosto);
            if (result.Count > 0)
            {
                string errores = string.Empty;
                foreach (string resul in result)
                {
                    errores = errores + resul;
                }
                ViewBag.error = "Errores en las referencias: " + errores;
                HOJA_COSTO_PN _model = CargarTabla(model);
                return View("Index", _model);
            }
            else
            {
                ViewBag.exito = "Proceso terminado correctamente";
            }
            return View("Index", CargarTabla(model));
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (string element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }

        [HttpPost]
        public ActionResult FiltroRef(string Tipo)
        {
            List<string> refs = _services.ObtenerReferencias(Tipo);
            return Json(refs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroMarca(string Tipo)
        {
            List<string> marcas = _services.ObtenerMarcas(Tipo);
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Tipo, string Marca)
        {
            List<string> coleccion = _services.ObtenerColeccion(Tipo, Marca);
            return Json(coleccion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLinea(string Tipo, string Marca, string Coleccion)
        {
            List<string> linea = _services.ObtenerLinea(Tipo, Marca, Coleccion);
            return Json(linea, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroEstado(string Tipo, string Marca, string Coleccion, string Linea)
        {
            List<string> estado = _services.ObtenerEstado(Tipo, Marca, Coleccion, Linea);
            return Json(estado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroEstadoCierre(string Tipo, string Marca, string Coleccion, string Linea/*, string Estado*/)
        {
            List<string> estadoCierre = _services.ObtenerEstadoCierre(Tipo, Marca, Coleccion, Linea/*, Estado*/);
            return Json(estadoCierre, JsonRequestBehavior.AllowGet);
        }
    }
}