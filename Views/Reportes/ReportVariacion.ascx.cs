using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Net;

namespace AppWebHojaCosto.Views.Reportes
{
    public partial class ReportVariacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string inputInfo = Request.QueryString["Id"];
                    if (!string.IsNullOrEmpty(inputInfo))
                    {
                        if (!ConfigurationManager.AppSettings["ReportPath"].EndsWith("/"))
                            this.reporte.ServerReport.ReportPath = string.Format("{0}/{1}", ConfigurationManager.AppSettings["ReportPath"], inputInfo);
                        else
                            this.reporte.ServerReport.ReportPath = string.Format("{0}{1}", ConfigurationManager.AppSettings["ReportPath"], inputInfo);

                        IReportServerCredentials rdcre = new CustomReportCredentials(ConfigurationManager.AppSettings["UserReports"], ConfigurationManager.AppSettings["PasswordReports"], "");
                        this.reporte.ServerReport.ReportServerCredentials = rdcre;
                        this.reporte.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServer"]);
                    }
                }
            }
            catch (Exception exError)
            {
                //base.MasterSite.ShowError(exError);
            }
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