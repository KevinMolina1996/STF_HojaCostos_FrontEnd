using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AppWebHojaCosto.Controllers
{
    public class ReporteVariacionesController : Controller
    {
        // GET: ReporteVariaciones
        public ActionResult Consulta()
        {
            SetRemoteReport();
            return View();
        }

        private void SetRemoteReport()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            reportViewer.ServerReport.ReportPath = "/Costos/Reporte_VariacionCosto";
            reportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["UrlReports"]);

            IReportServerCredentials rdcre = new CustomReportCredentials(ConfigurationManager.AppSettings["UserReports"], ConfigurationManager.AppSettings["PasswordReports"], "");
            reportViewer.ServerReport.ReportServerCredentials = rdcre;

            ViewBag.ReportViewer = reportViewer;
        }

        public class CustomReportCredentials : IReportServerCredentials
        {
            private string _UserName;
            private string _PassWord;
            private string _DomainName;
            public CustomReportCredentials(string UserName, string PassWord, string DomainName)
            {
                _UserName = UserName;
                _PassWord = PassWord;
                _DomainName = DomainName;
            }
            public System.Security.Principal.WindowsIdentity ImpersonationUser
            {
                get { return null; }
            }
            public ICredentials NetworkCredentials
            {
                get { return new NetworkCredential(_UserName, _PassWord); }
            }
            public bool GetFormsCredentials(out Cookie authCookie, out string user,
             out string password, out string authority)
            {
                authCookie = null;
                user = password = authority = null;
                return false;
            }
        }
    }
}