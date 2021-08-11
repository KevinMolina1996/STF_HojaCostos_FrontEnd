using AppWebHojaCosto.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using AppWebHojaCosto.Models;
using System.Data.Entity;

namespace AppWebHojaCosto.Services
{
    public class DashBoardNivel1Service
    {
        public List<string> obtenerMarcas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PN
                    .Select(x => x.HcMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColecciones(string Marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca)
                    .Select(x => x.HcColeccionS).Distinct().ToList();
            }
        }

        public void obtenerFecha(string Marca, string Coleccion, out string fecha)
        {
            using (var db = new DataBaseContext())
            {
                fecha = ((from pn in db.TBL_HOJA_COSTO_PN
                          where pn.HcMarcaS == Marca && pn.HcColeccionS == Coleccion
                          select pn.HcFechaAprobacionD)
                         .Union(from pnp in db.TBL_HOJA_COSTO_PNP
                                where pnp.PnpMarcaS == Marca && pnp.PnpColeccionS == Coleccion
                                select pnp.PnpFechaAprobacionD)
                         ).Min().ToString();
            }
        }

        public List<TBL_FECHAS_DASHBOARD> ConsultarFechas(string Marca, string Coleccion)
        {
            using(var db = new DataBaseContext())
            {
                return db.TBL_FECHAS_DASHBOARD.Where(x => x.FdMarcaS == Marca && x.FdColeccionS == Coleccion).ToList();
            }
        }

        public void ConsultarReferenciasAprobadasPN(string Id, string Marca, string Coleccion, string Fecha, out string aprobadas)
        {
            TBL_FECHAS_DASHBOARD data = new TBL_FECHAS_DASHBOARD();
            using (var db = new DataBaseContext())
            {
                if (Fecha.Length > 0 && Fecha != null)
                {
                    string[] split = Fecha.Split('-');
                    DateTime dt1 = Convert.ToDateTime(split[0]);
                    DateTime dt2 = Convert.ToDateTime(split[1]);

                    aprobadas = (from hoja in db.TBL_HOJA_COSTO_PN
                                 where hoja.HcMarcaS == Marca && hoja.HcColeccionS == Coleccion &&
                                        hoja.HcFechaAprobacionD >= dt1 && hoja.HcFechaAprobacionD <= dt2 && hoja.HcEstadoAproS == "CERRADA"
                                 select hoja.HcCodigoN).Count().ToString();
                }
                else
                {
                    aprobadas = "0";
                }

                data.FdCodigoN = db.TBL_FECHAS_DASHBOARD.Where(x => x.FdMarcaS == Marca && x.FdColeccionS == Coleccion && x.FdTipoInventarioS == "PN")
                                    .Select(x => x.FdCodigoN).FirstOrDefault();

                db.Configuration.ValidateOnSaveEnabled = false;
                db.TBL_FECHAS_DASHBOARD.Attach(data);

                if (Id.Contains("1"))
                {
                    data.FdSemana1S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if(data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana1S).IsModified = true;
                }
                else if (Id.Contains("2"))
                {
                    data.FdSemana2S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana2S).IsModified = true;
                }
                else if (Id.Contains("3"))
                {
                    data.FdSemana3S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana3S).IsModified = true;
                }
                else if (Id.Contains("4"))
                {
                    data.FdSemana4S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana4S).IsModified = true;
                }
                else if (Id.Contains("5"))
                {
                    data.FdSemana5S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana5S).IsModified = true;
                }
                else if (Id.Contains("6"))
                {
                    data.FdSemana6S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana6S).IsModified = true;
                }
                else if (Id.Contains("7"))
                {
                    data.FdSemana7S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana7S).IsModified = true;
                }
                else if (Id.Contains("8"))
                {
                    data.FdSemana8S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana8S).IsModified = true;
                }
                else if (Id.Contains("9"))
                {
                    data.FdSemana9S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana9S).IsModified = true;
                }
                else if (Id.Contains("10"))
                {
                    data.FdSemana10S = (Fecha.Length > 0 && Fecha != null) ? Id + "=" + Fecha + ";" + aprobadas : "";
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana10S).IsModified = true;
                }

                data.FdMarcaS = Marca;
                data.FdColeccionS = Coleccion;
                data.FdTipoInventarioS = "PN";

                if (data.FdCodigoN == 0)
                    db.Entry(data).State = EntityState.Added;

                db.SaveChanges();
            }
        }

        public void ConsultarReferenciasAprobadasPNP(string Id, string Marca, string Coleccion, string Fecha, out string aprobadas)
        {
            TBL_FECHAS_DASHBOARD data = new TBL_FECHAS_DASHBOARD();
            string[] split = Fecha.Split('-');
            DateTime dt1 = Convert.ToDateTime(split[0]);
            DateTime dt2 = Convert.ToDateTime(split[1]);
            using (var db = new DataBaseContext())
            {
                aprobadas = (from hoja in db.TBL_HOJA_COSTO_PNP
                             where hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion &&
                                    hoja.PnpFechaAprobacionD >= dt1 && hoja.PnpFechaAprobacionD <= dt2 && hoja.PnpEstadoAprobacion == "CERRADA"
                             select hoja.PnpCodigoN).Count().ToString();

                data.FdCodigoN = db.TBL_FECHAS_DASHBOARD.Where(x => x.FdMarcaS == Marca && x.FdColeccionS == Coleccion && x.FdTipoInventarioS == "PNP")
                                    .Select(x => x.FdCodigoN).FirstOrDefault();

                db.Configuration.ValidateOnSaveEnabled = false;
                db.TBL_FECHAS_DASHBOARD.Attach(data);

                if (Id.Contains("11"))
                {
                    data.FdSemana1S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana1S).IsModified = true;
                }
                else if (Id.Contains("12"))
                {
                    data.FdSemana2S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana2S).IsModified = true;
                }
                else if (Id.Contains("13"))
                {
                    data.FdSemana3S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana3S).IsModified = true;
                }
                else if (Id.Contains("14"))
                {
                    data.FdSemana4S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana4S).IsModified = true;
                }
                else if (Id.Contains("15"))
                {
                    data.FdSemana5S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana5S).IsModified = true;
                }
                else if (Id.Contains("16"))
                {
                    data.FdSemana6S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana6S).IsModified = true;
                }
                else if (Id.Contains("17"))
                {
                    data.FdSemana7S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana7S).IsModified = true;
                }
                else if (Id.Contains("18"))
                {
                    data.FdSemana8S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana8S).IsModified = true;
                }
                else if (Id.Contains("19"))
                {
                    data.FdSemana9S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana9S).IsModified = true;
                }
                else if (Id.Contains("20"))
                {
                    data.FdSemana10S = Id + "=" + Fecha + ";" + aprobadas;
                    if (data.FdCodigoN != 0)
                        db.Entry(data).Property(x => x.FdSemana10S).IsModified = true;
                }

                data.FdMarcaS = Marca;
                data.FdColeccionS = Coleccion;
                data.FdTipoInventarioS = "PNP";

                if (data.FdCodigoN == 0)
                    db.Entry(data).State = EntityState.Added;

                db.SaveChanges();
            }
        }

        public void ConsultaProductoAprobado(string Marca, string Coleccion, out string pendientes, out string completas, out string pendientes_pnp, out string completas_pnp, out string con_precio, out string sin_precio,
            out string con_precio_pnp, out string sin_precio_pnp, out string no_tracking)
        {
            using (var db = new DataBaseContext())
            {
                pendientes = (from hoja in db.TBL_HOJA_COSTO_PN
                              where hoja.HcEstadoAproS != "CERRADA" && hoja.HcMarcaS == Marca && hoja.HcColeccionS == Coleccion
                              select hoja.HcCodigoN).Count().ToString();
                completas = (from hoja in db.TBL_HOJA_COSTO_PN
                             where hoja.HcEstadoAproS == "CERRADA" && hoja.HcMarcaS == Marca && hoja.HcColeccionS == Coleccion
                             select hoja.HcCodigoN).Count().ToString();
                pendientes_pnp = (from hoja in db.TBL_HOJA_COSTO_PNP
                                  where hoja.PnpEstadoAprobacion != "CERRADA" && hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion
                                  select hoja.PnpEstadoAprobacion).Count().ToString();
                completas_pnp = (from hoja in db.TBL_HOJA_COSTO_PNP
                                 where hoja.PnpEstadoAprobacion == "CERRADA" && hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion
                                 select hoja.PnpEstadoAprobacion).Count().ToString();
                con_precio = (from hoja in db.TBL_HOJA_COSTO_PN
                              where hoja.HcEstadoAproS == "CERRADA" && hoja.HcMarcaS == Marca && hoja.HcColeccionS == Coleccion && hoja.HcPrecioD > 0
                              select hoja.HcEstadoAproS).Count().ToString();
                sin_precio = (from hoja in db.TBL_HOJA_COSTO_PN
                              where hoja.HcEstadoAproS == "CERRADA" && hoja.HcMarcaS == Marca && hoja.HcColeccionS == Coleccion && hoja.HcPrecioD <= 0
                              select hoja.HcEstadoAproS).Count().ToString();
                con_precio_pnp = (from hoja in db.TBL_HOJA_COSTO_PNP
                                  where hoja.PnpEstadoAprobacion == "CERRADA" && hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion && hoja.PnpPrecioD > 0
                                  select hoja.PnpEstadoAprobacion).Count().ToString();
                sin_precio_pnp = (from hoja in db.TBL_HOJA_COSTO_PNP
                                  where hoja.PnpEstadoAprobacion == "CERRADA" && hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion && hoja.PnpPrecioD <= 0
                                  select hoja.PnpEstadoAprobacion).Count().ToString();
                no_tracking = (from hoja in db.TBL_HOJA_COSTO_PNP
                               where hoja.PnpEstadoAprobacion == "CERRADA" && hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion && hoja.PnpEstadoOrdenCompraS == "PENDIENTE"
                               select hoja.PnpEstadoAprobacion).Count().ToString();
            }
        }

        public List<string> PendientesProducidoStf(string Marca, string Coleccion)
        {
            List<string> lstPendientes = new List<string>();

            string sin_foto = "0", pte_hoja = "0", telas = "0", insumos = "0", tiempos = "0", procesos = "0", ruta = "0", maquila = "0";
            using (var db = new DataBaseContext())
            {
                sin_foto = (from h in db.TBL_HOJA_COSTO_PN
                            where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (h.HcImagenDS == "" || h.HcImagenDS == null)
                            select h.HcCodigoN).Count().ToString();
                telas = (from t in db.TBL_CONSUMO_TELAS
                         join h in db.TBL_HOJA_COSTO_PN
                         on t.HcCodigoN equals h.HcCodigoN
                         where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (t.CtCtsxMtD == 0 || t.CtConF == 0 || t.CtTotalD == 0)
                         select t.CtCodigoN).Count().ToString();
                insumos = (from i in db.TBL_INS_ACC
                           join h in db.TBL_HOJA_COSTO_PN
                           on i.HcCodigoN equals h.HcCodigoN
                           where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (i.IaCtsxMtD == 0 || i.IaConF == 0 || i.IaTotalD == 0)
                           select i.IaCodigoN).Count().ToString();
                tiempos = (from m in db.TBL_MOD_CIF
                           join h in db.TBL_HOJA_COSTO_PN
                           on m.HcCodigoN equals h.HcCodigoN
                           where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (m.McCostoManoObraD == 0 || m.McCostoIndirectosD == 0)
                           select m.McCodigoN).Count().ToString();
                procesos = (from p in db.TBL_PROCESO
                            join h in db.TBL_HOJA_COSTO_PN
                            on p.HcCodigoN equals h.HcCodigoN
                            where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (p.PrCostoM == 0)
                            select p.PrCodigoN).Count().ToString();
                maquila = (from e in db.TBL_ETIQ_MAR_EMP
                           join h in db.TBL_HOJA_COSTO_PN
                           on e.HcCodigoN equals h.HcCodigoN
                           where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (e.EmeCtsxMtD == 0 || e.EmeConF == 0 || e.EmeTotalD == 0)
                           select e.EmeCodigoN).Count().ToString();
            }
            lstPendientes.Add(sin_foto);
            lstPendientes.Add(pte_hoja);
            lstPendientes.Add(telas);
            lstPendientes.Add(insumos);
            lstPendientes.Add(tiempos);
            lstPendientes.Add(procesos);
            lstPendientes.Add(ruta);
            lstPendientes.Add(maquila);
            return lstPendientes;
        }

        public List<string> PendientesProducidoEla(string Marca, string Coleccion)
        {
            List<string> lstPendientes = new List<string>();

            string sin_foto = "0", pte_hoja = "0", telas = "0", insumos = "0", tiempos = "0", procesos = "0", ruta = "0", maquila = "0";
            using (var db = new DataBaseContext())
            {
                sin_foto = (from h in db.TBL_HOJA_COSTO_PN
                            where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (h.HcImagenDS == "" || h.HcImagenDS == null)
                            select h.HcCodigoN).Count().ToString();
                telas = (from t in db.TBL_CONSUMO_TELAS
                         join h in db.TBL_HOJA_COSTO_PN
                         on t.HcCodigoN equals h.HcCodigoN
                         where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (t.CtCtsxMtD == 0 || t.CtConF == 0 || t.CtTotalD == 0)
                         select t.CtCodigoN).Count().ToString();
                insumos = (from i in db.TBL_INS_ACC
                           join h in db.TBL_HOJA_COSTO_PN
                           on i.HcCodigoN equals h.HcCodigoN
                           where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (i.IaCtsxMtD == 0 || i.IaConF == 0 || i.IaTotalD == 0)
                           select i.IaCodigoN).Count().ToString();
                tiempos = (from m in db.TBL_MOD_CIF
                           join h in db.TBL_HOJA_COSTO_PN
                           on m.HcCodigoN equals h.HcCodigoN
                           where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (m.McCostoManoObraD == 0 || m.McCostoIndirectosD == 0)
                           select m.McCodigoN).Count().ToString();
                procesos = (from p in db.TBL_PROCESO
                            join h in db.TBL_HOJA_COSTO_PN
                            on p.HcCodigoN equals h.HcCodigoN
                            where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (p.PrCostoM == 0)
                            select p.PrCodigoN).Count().ToString();
                maquila = (from e in db.TBL_ETIQ_MAR_EMP
                           join h in db.TBL_HOJA_COSTO_PN
                           on e.HcCodigoN equals h.HcCodigoN
                           where h.HcMarcaS == Marca && h.HcColeccionS == Coleccion && (e.EmeCtsxMtD == 0 || e.EmeConF == 0 || e.EmeTotalD == 0)
                           select e.EmeCodigoN).Count().ToString();
            }
            lstPendientes.Add(sin_foto);
            lstPendientes.Add(pte_hoja);
            lstPendientes.Add(telas);
            lstPendientes.Add(insumos);
            lstPendientes.Add(tiempos);
            lstPendientes.Add(procesos);
            lstPendientes.Add(ruta);
            lstPendientes.Add(maquila);
            return lstPendientes;
        }
    }
}