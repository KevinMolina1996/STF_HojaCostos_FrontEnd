using AppWebHojaCosto.Context;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Reporting.WebForms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebHojaCosto.Views.Reportes
{
    public partial class ReportControl : System.Web.Mvc.ViewUserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Required for report events to be handled properly.
            Context.Handler = Page;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string FechaInicio = string.Empty;
                string FechaFin = string.Empty;

                if (Request.QueryString["FechaInicio"] != null && Request.QueryString["FechaFin"] != null)
                {
                    FechaInicio = Request.QueryString["FechaInicio"].ToString();
                    FechaFin = Request.QueryString["FechaFin"].ToString();
                }

                using (var db = new DataBaseContext())
                {
                    DataTable dt = new DataTable();
                    var con_telas = (from hoja in db.TBL_HOJA_COSTO_PN
                                     from telas in db.TBL_CONSUMO_TELAS.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                     where telas.CtCtsxMtD == 0 || telas.CtConF == 0 || telas.CtTotalD == 0
                                     select new
                                     {
                                         Referencia = hoja.HcReferenciaS,
                                         Estado = hoja.HcEstadoAproS,
                                         Pendiente = (
                                             telas.CtConF == 0 ? "TELAS" : telas.CtCtsxMtD == 0 ? "TELAS" : telas.CtTotalD == 0 ? "TELAS" : ""
                                         ),
                                         CodigoPendiente = (
                                            telas.CtConF == 0 ? "?" : telas.CtCtsxMtD == 0 ? "?" : telas.CtTotalD == 0 ? "?" : ""
                                         ),
                                         DescripcionPendiente = (
                                            telas.CtConF == 0 ? telas.CtNombreS : telas.CtCtsxMtD == 0 ? telas.CtNombreS : telas.CtTotalD == 0 ? telas.CtNombreS : ""
                                         ),
                                         Coleccion = hoja.HcColeccionS
                                     }).ToList();

                    var con_insumos = (from hoja in db.TBL_HOJA_COSTO_PN
                                       from insumos in db.TBL_INS_ACC.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                       where insumos.IaCtsxMtD == 0 || insumos.IaConF == 0 || insumos.IaTotalD == 0
                                       select new
                                       {
                                           Referencia = hoja.HcReferenciaS,
                                           Estado = hoja.HcEstadoAproS,
                                           Pendiente = (
                                               insumos.IaConF == 0 ? "TELAS" : insumos.IaCtsxMtD == 0 ? "TELAS" : insumos.IaTotalD == 0 ? "TELAS" : ""
                                           ),
                                           CodigoPendiente = (
                                              insumos.IaConF == 0 ? "?" : insumos.IaCtsxMtD == 0 ? "?" : insumos.IaTotalD == 0 ? "?" : ""
                                           ),
                                           DescripcionPendiente = (
                                              insumos.IaConF == 0 ? insumos.IaNombreS : insumos.IaCtsxMtD == 0 ? insumos.IaNombreS : insumos.IaTotalD == 0 ? insumos.IaNombreS : ""
                                           ),
                                           Coleccion = hoja.HcColeccionS
                                       }).ToList();

                    var con_procesos = (from hoja in db.TBL_HOJA_COSTO_PN
                                        from procesos in db.TBL_PROCESO.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                        where procesos.PrCostoM == 0
                                        select new
                                        {
                                            Referencia = hoja.HcReferenciaS,
                                            Estado = hoja.HcEstadoAproS,
                                            Pendiente = (
                                                procesos.PrCostoM == 0 ? "TELAS" : ""
                                            ),
                                            CodigoPendiente = (
                                               procesos.PrCostoM == 0 ? "?" : ""
                                            ),
                                            DescripcionPendiente = (
                                               procesos.PrCostoM == 0 ? procesos.PrDetalleS : ""
                                            ),
                                            Coleccion = hoja.HcColeccionS
                                        }).ToList();

                    var con_tiempos = (from hoja in db.TBL_HOJA_COSTO_PN
                                       from tiempos in db.TBL_MOD_CIF.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                       where tiempos.McCostoIndirectosD == 6000 || tiempos.McCostoManoObraD == 60000
                                       select new
                                       {
                                           Referencia = hoja.HcReferenciaS,
                                           Estado = hoja.HcEstadoAproS,
                                           Pendiente = (
                                               tiempos.McCostoIndirectosD == 6000 ? "TIEMPOS" : tiempos.McCostoManoObraD == 60000 ? "TIEMPOS" : ""
                                           ),
                                           CodigoPendiente = (
                                              tiempos.McCostoIndirectosD == 6000 ? "?" : tiempos.McCostoManoObraD == 60000 ? "?" : ""
                                           ),
                                           DescripcionPendiente = (
                                              tiempos.McCostoIndirectosD == 6000 ? "" : tiempos.McCostoManoObraD == 60000 ? "" : ""
                                           ),
                                           Coleccion = hoja.HcColeccionS
                                       }).ToList();

                    var con_marquillas = (from hoja in db.TBL_HOJA_COSTO_PN
                                          from telas in db.TBL_CONSUMO_TELAS.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                          where telas.CtCtsxMtD == 0 || telas.CtConF == 0 || telas.CtTotalD == 0
                                          select new
                                          {
                                              Referencia = hoja.HcReferenciaS,
                                              Estado = hoja.HcEstadoAproS,
                                              Pendiente = (
                                                  telas.CtConF == 0 ? "TELAS" : telas.CtCtsxMtD == 0 ? "TELAS" : telas.CtTotalD == 0 ? "TELAS" : ""
                                              ),
                                              CodigoPendiente = (
                                                 telas.CtConF == 0 ? "?" : telas.CtCtsxMtD == 0 ? "?" : telas.CtTotalD == 0 ? "?" : ""
                                              ),
                                              DescripcionPendiente = (
                                                 telas.CtConF == 0 ? telas.CtNombreS : telas.CtCtsxMtD == 0 ? telas.CtNombreS : telas.CtTotalD == 0 ? telas.CtNombreS : ""
                                              ),
                                              Coleccion = hoja.HcColeccionS
                                          }).ToList();

                    var consulta = (from hoja in db.TBL_HOJA_COSTO_PN
                                    from telas in db.TBL_CONSUMO_TELAS.Where(m => m.HcCodigoN == hoja.HcCodigoN && (m.CtCtsxMtD == 0 || m.CtConF == 0 || m.CtTotalD == 0)).DefaultIfEmpty()
                                    from insumos in db.TBL_INS_ACC.Where(m => m.HcCodigoN == hoja.HcCodigoN && (m.IaCtsxMtD == 0 || m.IaConF == 0 || m.IaTotalD == 0)).DefaultIfEmpty()
                                    from marquillas in db.TBL_ETIQ_MAR_EMP.Where(m => m.HcCodigoN == hoja.HcCodigoN && (m.EmeCtsxMtD == 0 || m.EmeConF == 0 || m.EmeTotalD == 0)).DefaultIfEmpty()
                                    from mod in db.TBL_MOD_CIF.Where(m => m.HcCodigoN == hoja.HcCodigoN && (m.McCostoIndirectosD == 6000 || m.McCostoManoObraD == 60000)).DefaultIfEmpty()
                                    from procesos in db.TBL_PROCESO.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                        //where hoja.HcFecCreD >= Convert.ToDateTime(FechaInicio) && hoja.HcFecCreD <= Convert.ToDateTime(FechaFin)
                                    select new
                                    {
                                        Referencia = hoja.HcReferenciaS,
                                        Estado = hoja.HcEstadoAproS,
                                        Pendiente = (
                                            telas.CtConF == 0 ? "TELAS" : telas.CtCtsxMtD == 0 ? "TELAS" : telas.CtTotalD == 0 ? "TELAS" :
                                            insumos.IaConF == 0 ? "INSUMOS" : insumos.IaCtsxMtD == 0 ? "INSUMOS" : insumos.IaTotalD == 0 ? "INSUMOS" :
                                            marquillas.EmeConF == 0 ? "MARQUILLAS" : marquillas.EmeCtsxMtD == 0 ? "MARQUILLAS" : marquillas.EmeTotalD == 0 ? "MARQUILLAS" :
                                            mod.McCostoIndirectosD == 6000 ? "TIEMPOS" : mod.McCostoManoObraD == 60000 ? "TIEMPOS" :
                                            procesos.PrCostoM == 0 ? "PROCESOS" : ""
                                        ),
                                        CodigoPendiente = (telas.CtConF == 0 ? "PENDIENTE" : telas.CtConF.ToString()),
                                        DescripcionPendiente = (telas.CtCtsxMtD == 0 ? "PENDIENTE" : telas.CtCtsxMtD.ToString()),
                                        Coleccion = hoja.HcColeccionS
                                    }).ToList();
                    using (var reader = ObjectReader.Create(consulta))
                    {
                        dt.Load(reader);
                    }
                    reporte.LocalReport.ReportPath = Server.MapPath("~/Reports/ReportComponentesGenericos.rdlc");
                    reporte.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("dsPendientes", dt);
                    reporte.LocalReport.DataSources.Add(rdc);
                    reporte.LocalReport.Refresh();
                    reporte.DataBind();
                }
            }
        }
    }
}