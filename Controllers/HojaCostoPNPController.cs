using AppWebHojaCosto.Models;
using AppWebHojaCosto.Services;
using FastMember;
using Microsoft.Reporting.WebForms;
//using SelectPdf;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Drawing.Printing;
using Spire.Pdf.Annotations;
using Spire.Pdf.Widget;
using Spire.Pdf;
using Ionic.Zip;
using System.IO;
using System;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using AppWebHojaCosto.Controllers.Helpers;

namespace AppWebHojaCosto.Controllers
{
    public class HojaCostoPNPController : Controller
    {
        private HojaCostoPNPService _services;

        public HojaCostoPNPController()
        {
            _services = new HojaCostoPNPService();
        }

        public HOJA_COSTO_PNP LoadModel()
        {
            var model = new HOJA_COSTO_PNP();
            return model;
        }

        public HOJA_COSTO_PNP CargarTabla(HOJA_COSTO_PNP model)
        {
            HOJA_COSTO_PNP _model = _services._LST_COSTO_PNP(model.TipoHojaCosto, model.TBL_HOJA_COSTO_PNP.PnpMarcaS, model.TBL_HOJA_COSTO_PNP.PnpColeccionS, model.TBL_HOJA_COSTO_PNP.PnpLineaS, model.TBL_HOJA_COSTO_PNP.PnpEstadoS);
            _model.TipoHojaCosto = model.TipoHojaCosto;
            _model.Referencias = GetSelectListItems(new List<string>());
            _model.TipoHojas = _services.ObtenerTiposHojas();
            _model.Marcas = GetSelectListItems(new List<string> { model.TBL_HOJA_COSTO_PNP.PnpMarcaS });
            _model.Colecciones = GetSelectListItems(new List<string> { model.TBL_HOJA_COSTO_PNP.PnpColeccionS });
            _model.Lineas = GetSelectListItems(new List<string> { model.TBL_HOJA_COSTO_PNP.PnpLineaS });
            _model.Estados = GetSelectListItems(new List<string> { model.TBL_HOJA_COSTO_PNP.PnpEstadoS });
            _model.TBL_HOJA_COSTO_PNP = model.TBL_HOJA_COSTO_PNP;
            return _model;
        }

        // GET: HojaCostoPNP
        public ActionResult Index()
        {
            var model = LoadModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ConsultarxRef(HOJA_COSTO_PNP model)
        {
            try
            {
                if (model.TBL_HOJA_COSTO_PNP.PnpReferenciaS != null && model.TipoHojaCosto != null)
                {
                    if (model.TipoHojaCosto == "CE")
                    {
                        TBL_HOJA_COSTO_PNP _model = _services._HOJA_COSTO_PNP(model.TBL_HOJA_COSTO_PNP.PnpReferenciaS);
                        if (_model != null)
                        {
                            return RedirectToAction("Index", "HojaNoProducido", new { Referencia = model.TBL_HOJA_COSTO_PNP.PnpReferenciaS });
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
                        return RedirectToAction("Index", "HojaNoProducidoSimulada", new { Referencia = model.TBL_HOJA_COSTO_PNP.PnpReferenciaS });
                    }
                    return View("Index", model);
                }
                else
                {
                    ViewBag.alerta = "Falta datos por diligenciar.";
                    return View("Index", model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Se presentó un error, detalle: " + ex.Message;
                return View("Index", model);
            }
        }

        public ActionResult ConsultarxRef(string Tipo, string Referencia)
        {
            try
            {
                if (Referencia != null && Tipo != null)
                {
                    if (Tipo == "CE")
                    {
                        return RedirectToAction("Index", "HojaNoProducido", new { Referencia = Referencia });
                    }
                    else if (Tipo == "CS")
                    {
                        return RedirectToAction("Index", "HojaNoProducidoSimulada", new { Referencia = Referencia });
                    }
                    ViewBag.alerta = "Se presentaron problemas al cargar";
                    return RedirectToAction("Index");
                }
                return View("Index", null);
            }
            catch(Exception ex)
            {
                ViewBag.error = "Se presentó un error, detalle: " + ex.Message;
                return View("Index", null);
            }
        }

        [HttpPost]
        public ActionResult ConsultaMasiva(HOJA_COSTO_PNP model)
        {
            if (model.TBL_HOJA_COSTO_PNP.PnpMarcaS != null && model.TBL_HOJA_COSTO_PNP.PnpColeccionS != null && model.TipoHojaCosto != null)
            {
                var _model = CargarTabla(model);
                ViewBag.cargar_listas = "X";
                return View("Index", _model);
            }
            else
            {
                model.Referencias = GetSelectListItems(new List<string>());
                model.TipoHojas = _services.ObtenerTiposHojas();
                model.Marcas = GetSelectListItems(new List<string>());
                model.Colecciones = GetSelectListItems(new List<string>());
                model.Lineas = GetSelectListItems(new List<string>());
                model.Estados = GetSelectListItems(new List<string>());
                ViewBag.alerta = "Falta datos por diligenciar.";
                return View("Index", model);
            }
        }

        [HttpPost]
        public ActionResult GenerarPdf(HOJA_COSTO_PNP model, string Referencias)
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
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPNP.rdlc");
                    else if (model.TipoHojaCosto == "CS")
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPNP.rdlc");

                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsHojaCostoPNP";

                    if (model.TipoHojaCosto == "CE")
                    {
                        var data = _services._LST_HOJA_COSTO_PNP(var);
                        reportDataSource.Value = data;
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        var data = _services._LST__HOJA_SIM_COSTO_PNP(var);
                        reportDataSource.Value = data;
                    }

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
                    var dataFile = Server.MapPath("~/Documents/" + var + ".pdf");
                    System.IO.File.WriteAllBytes(dataFile, renderedBytes);

                    archivos.Add(Server.MapPath("~/Documents/" + var + ".pdf"));

                    //ImprimirPdf(dataFile);
                    //SendToPrinter(dataFile);
                }
                CombinePDF.CombineMultiplePDFs(archivos, Server.MapPath("~/Documents/" + nombre + ".pdf"));
            }
            catch (Exception ex)
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
        public virtual ActionResult ExportExcel(HOJA_COSTO_PNP model, string Referencias)
        {
            try
            {
                ZipFile zip = new ZipFile();
                var nombreZip = "Hojas_costo.zip";
                Referencias = Referencias.TrimEnd('|');
                string[] split = Referencias.Split('|');
                foreach (string var in split)
                {
                    //Ejecuto el reporte para obtener el informe en bytes
                    LocalReport localReport = new LocalReport();
                    if (model.TipoHojaCosto == "CE")
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPNP.rdlc");
                    else if (model.TipoHojaCosto == "CS")
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPNP.rdlc");

                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsHojaCostoPNP";

                    if (model.TipoHojaCosto == "CE")
                    {
                        var data = _services._LST_HOJA_COSTO_PNP(var);
                        reportDataSource.Value = data;
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        var data = _services._LST__HOJA_SIM_COSTO_PNP(var);
                        reportDataSource.Value = data;
                    }

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
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", LoadModel());
            }
        }

        [HttpPost]
        public virtual ActionResult ExportPDF(HOJA_COSTO_PNP model, string Referencias)
        {
            try
            {
                ZipFile zip = new ZipFile();
                var nombreZip = "Hojas_costo.zip";
                Referencias = Referencias.TrimEnd('|');
                string[] split = Referencias.Split('|');
                foreach (string var in split)
                {
                    //Ejecuto el reporte para obtener el informe en bytes
                    LocalReport localReport = new LocalReport();
                    if (model.TipoHojaCosto == "CE")
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoPNP.rdlc");
                    else if (model.TipoHojaCosto == "CS")
                        localReport.ReportPath = Server.MapPath("~/Reports/ReportHojaCostoSimPNP.rdlc");

                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "dsHojaCostoPNP";

                    if (model.TipoHojaCosto == "CE")
                    {
                        var data = _services._LST_HOJA_COSTO_PNP(var);
                        reportDataSource.Value = data;
                    }
                    else if (model.TipoHojaCosto == "CS")
                    {
                        var data = _services._LST__HOJA_SIM_COSTO_PNP(var);
                        reportDataSource.Value = data;
                    }

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
            catch (Exception ex)
            {
                ViewBag.error = "Ocurrio un error al procesar la solicitud";
                return View("Index", LoadModel());
            }
        }

        [HttpPost]
        public ActionResult CerrarHojas(HOJA_COSTO_PNP model, string Referencias)
        {
            List<string> lstReferencias = new List<string>();
            Referencias = Referencias.TrimEnd('|');
            string[] split = Referencias.Split('|');
            foreach (string var in split)
            {
                lstReferencias.Add(var);
            }
            model.TBL_HOJA_COSTO_PNP.PnpEstadoS = "CERRADA";
            List<string> result = _services.CerrarHojas(model.TBL_HOJA_COSTO_PNP.PnpEstadoS, lstReferencias, model.TipoHojaCosto);
            if (result.Count > 0)
            {
                string errores = string.Empty;
                foreach (string resul in result)
                {
                    errores = errores + resul;
                }
                ViewBag.error = "Errores en las referencias: " + errores;
                var _model = CargarTabla(model);
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

        [HttpPost]
        public ActionResult FiltroRef(string Tipo)
        {
            var refs = _services.ObtenerReferencias(Tipo);
            return Json(refs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroMarca(string Tipo)
        {
            var marcas = _services.ObtenerMarcas(Tipo);
            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroColeccion(string Tipo, string Marca)
        {
            var coleccion = _services.ObtenerColeccion(Tipo, Marca);
            return Json(coleccion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroLinea(string Tipo, string Marca, string Coleccion)
        {
            var linea = _services.ObtenerLinea(Tipo, Marca, Coleccion);
            return Json(linea, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FiltroEstado(string Tipo, string Marca, string Coleccion, string Linea)
        {
            var estado = _services.ObtenerEstado(Tipo, Marca, Coleccion, Linea);
            return Json(estado, JsonRequestBehavior.AllowGet);
        }
    }
}