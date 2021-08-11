using AppWebHojaCosto.Context;
using FastMember;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebHojaCosto.Views.Reportes
{
    public partial class Visualizador : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string FechaInicio = string.Empty;
                //string FechaFin = string.Empty;

                //if (Request.QueryString["FechaInicio"] != null && Request.QueryString["FechaFin"] != null)
                //{
                //    FechaInicio = Request.QueryString["FechaInicio"].ToString();
                //    FechaFin = Request.QueryString["FechaFin"].ToString();
                //}

                //using (var db = new DataBaseContext())
                //{
                //    DataTable dt = new DataTable();
                //    var consulta = (from hoja in db.TBL_HOJA_COSTO_PN
                //                    from telas in db.TBL_CONSUMO_TELAS.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                //                    from insumos in db.TBL_INS_ACC.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                //                    from marquillas in db.TBL_ETIQ_MAR_EMP.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                //                    from mod in db.TBL_MOD_CIF.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                //                    from procesos in db.TBL_PROCESO.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                //                    where hoja.HcFecCreD >= Convert.ToDateTime(FechaInicio) && hoja.HcFecCreD <= Convert.ToDateTime(FechaFin)
                //                    select new
                //                    {
                //                        Referencia = hoja.HcReferenciaS,
                //                        Estado = hoja.HcEstadoAproS,
                //                        Pendiente = hoja.HcLineaS,
                //                        CodigoPendiente = (telas.CtConF == 0 ? "PENDIENTE" : telas.CtConF.ToString()),
                //                        DescripcionPendiente = (telas.CtCtsxMtD == 0 ? "PENDIENTE" : telas.CtCtsxMtD.ToString()),
                //                        Coleccion = hoja.HcColeccionS
                //                    }).ToList();
                //    using (var reader = ObjectReader.Create(consulta))
                //    {
                //        dt.Load(reader);
                //    }
                //    Reporte.LocalReport.ReportPath = Server.MapPath("~/Reports/ReportComponentesGenericos.rdlc");
                //    Reporte.LocalReport.DataSources.Clear();
                //    ReportDataSource rdc = new ReportDataSource("dsPendientes", dt);
                //    Reporte.LocalReport.DataSources.Add(rdc);
                //    Reporte.LocalReport.Refresh();
                //    Reporte.DataBind();
                //}
            }
        }
    }
}