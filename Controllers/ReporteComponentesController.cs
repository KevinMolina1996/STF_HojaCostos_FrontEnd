using AppWebHojaCosto.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AppWebHojaCosto.Controllers
{
    public class ReporteComponentesController : Controller
    {
        private ReportesService _services;

        public ReporteComponentesController()
        {
            _services = new ReportesService();
        }

        // GET: ReporteComponentes
        public ActionResult Consulta()
        {
            return View();
        }

        public ActionResult Buscar(string FechaInicio, string FechaFin)
        {
            SetLocalReport(FechaInicio, FechaFin);
            return View("Consulta");
        }

        private void SetLocalReport(string FechaInicio, string FechaFin)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports/ReportComponentesGenericos.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsPendientes", _services.CargarComponentesGenericos(FechaInicio, FechaFin)));
            //reportViewer.LocalReport.SetParameters(GetParametersLocal());

            ViewBag.visible = true;
            ViewBag.ReportViewer = reportViewer;
        }
    }
}