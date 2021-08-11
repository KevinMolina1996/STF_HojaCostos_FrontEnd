using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Services
{
    public class HojaCostoPNPService
    {
        public List<SelectListItem> ObtenerTiposHojas()
        {
            List<SelectListItem> lstTipos = new List<SelectListItem>();
            lstTipos.Add(new SelectListItem
            {
                Text = "--Seleccione--",
                Value = ""
            });
            lstTipos.Add(new SelectListItem
            {
                Text = "Hoja de Costo Estandar",
                Value = "CE"
            });
            lstTipos.Add(new SelectListItem
            {
                Text = "Hoja de Costo Simulada",
                Value = "CS"
            });
            return lstTipos;
        }

        public List<string> ObtenerReferencias(string Tipo)
        {
            if (Tipo == "CE")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PNP
                        .Select(x => x.PnpReferenciaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PNP
                        .Select(x => x.SimPnpReferenciaS).Distinct().ToList();
                }
            }
            else
                return new List<string>();
        }

        public List<string> ObtenerMarcas(string Tipo)
        {
            if (Tipo == "CE")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PNP
                        .Select(x => x.PnpMarcaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PNP
                        .Select(x => x.SimPnpMarcaS).Distinct().ToList();
                }
            }
            else
                return new List<string>();
        }

        public List<string> ObtenerColeccion(string Tipo, string Marca)
        {
            if (Tipo == "CE")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == Marca)
                        .Select(x => x.PnpColeccionS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpMarcaS == Marca)
                        .Select(x => x.SimPnpColeccionS).Distinct().ToList();
                }
            }
            else
                return new List<string>();
        }

        public List<string> ObtenerLinea(string Tipo, string Marca, string Coleccion)
        {
            if (Tipo == "CE")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == Marca && x.PnpColeccionS == Coleccion)
                        .Select(x => x.PnpLineaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpMarcaS == Marca && x.SimPnpColeccionS == Coleccion)
                        .Select(x => x.SimPnpLineaS).Distinct().ToList();
                }
            }
            else
                return new List<string>();
        }

        public List<string> ObtenerEstado(string Tipo, string Marca, string Coleccion, string Linea)
        {
            if (Tipo == "CE")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == Marca && x.PnpColeccionS == Coleccion && x.PnpLineaS == Linea)
                        .Select(x => x.PnpEstadoS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (var db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpMarcaS == Marca && x.SimPnpColeccionS == Coleccion && x.SimPnpLineaS == Linea)
                        .Select(x => x.SimPnpEstadoS).Distinct().ToList();
                }
            }
            else
                return new List<string>();
        }

        public TBL_HOJA_COSTO_PNP _HOJA_COSTO_PNP(string Referencia)
        {
            TBL_HOJA_COSTO_PNP model = new TBL_HOJA_COSTO_PNP();
            using (var db = new DataBaseContext())
            {
                model = db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpReferenciaS == Referencia)
                    .FirstOrDefault();
                if(model != null)
                {
                    model.PnpCostoCompraPorcF = Convert.ToInt32(model.PnpCostoCompraPorcF * 100);
                    model.PnpPinSeguridadPorcF = Convert.ToInt32(model.PnpPinSeguridadPorcF * 100);
                    model.PnpGastosOrigenPorcF = Convert.ToInt32(model.PnpGastosOrigenPorcF * 100);
                    model.PnpGastosFletePorcF = Convert.ToInt32(model.PnpGastosFletePorcF * 100);
                    model.PnpGastosArancelPorcF = Convert.ToInt32(model.PnpGastosArancelPorcF * 100);
                    model.PnpGastosSeguroPorcF = Convert.ToInt32(model.PnpGastosSeguroPorcF * 100);
                    model.PnpGastosDestinoPorcF = Convert.ToInt32(model.PnpGastosDestinoPorcF * 100);
                    model.PnpGastosOtrosPorcF = Convert.ToInt32(model.PnpGastosOtrosPorcF * 100);
                }
            }
            return model;
        }

        //LISTA HOJA COSTO NO PRODUCIDO PARA EL REPORTE PDF
        public List<TBL_HOJA_COSTO_PNP> _LST_HOJA_COSTO_PNP(string Referencia)
        {
            List<TBL_HOJA_COSTO_PNP> model = new List<TBL_HOJA_COSTO_PNP>();
            using (var db = new DataBaseContext())
            {
                model = db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpReferenciaS == Referencia)
                    .ToList();
            }
            return model;
        }

        //LISTA HOJA COSTO NO PRODUCIDO PARA EL REPORTE PDF - SIMULADA
        public List<TBL_SIM_HOJA_COSTO_PNP> _LST__HOJA_SIM_COSTO_PNP(string Referencia)
        {
            List<TBL_SIM_HOJA_COSTO_PNP> model = new List<TBL_SIM_HOJA_COSTO_PNP>();
            using (var db = new DataBaseContext())
            {
                model = db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpReferenciaS == Referencia)
                    .ToList();
            }
            return model;
        }

        //HOJA COSTO NO PRODUCIDO SIMULADA
        public TBL_SIM_HOJA_COSTO_PNP _HOJA_SIM_COSTO_PNP(string Referencia)
        {
            TBL_SIM_HOJA_COSTO_PNP model = new TBL_SIM_HOJA_COSTO_PNP();
            using (var db = new DataBaseContext())
            {
                model = db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpReferenciaS == Referencia)
                    .FirstOrDefault();
            }
            return model;
        }

        public HOJA_COSTO_PNP _LST_COSTO_PNP(string Tipo, string Marca, string Coleccion, string Linea, string Estado)
        {
            HOJA_COSTO_PNP model = new HOJA_COSTO_PNP();
            if (Tipo == "CE")
            {
                using (var db = new DataBaseContext())
                {
                    if (!string.IsNullOrEmpty(Linea) && !string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_HOJA_COSTO_PNP = db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == Marca && x.PnpColeccionS == Coleccion
                                                                            && x.PnpLineaS == Linea && x.PnpEstadoS == Estado).ToList();
                    }
                    else if (!string.IsNullOrEmpty(Linea) && string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_HOJA_COSTO_PNP = db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == Marca && x.PnpColeccionS == Coleccion
                                                                            && x.PnpLineaS == Linea).ToList();
                    }
                    else
                    {
                        model.LST_TBL_HOJA_COSTO_PNP = db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == Marca && x.PnpColeccionS == Coleccion).ToList();
                    }
                }
                return model;
            }
            else if (Tipo == "CS")
            {
                using (var db = new DataBaseContext())
                {
                    if (!string.IsNullOrEmpty(Linea) && !string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_SIM_HOJA_COSTO_PNP = db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpMarcaS == Marca && x.SimPnpColeccionS == Coleccion
                                                                            && x.SimPnpLineaS == Linea && x.SimPnpEstadoS == Estado).ToList();
                    }
                    else if (!string.IsNullOrEmpty(Linea) && string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_SIM_HOJA_COSTO_PNP = db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpMarcaS == Marca && x.SimPnpColeccionS == Coleccion
                                                                            && x.SimPnpLineaS == Linea).ToList();
                    }
                    else
                    {
                        model.LST_TBL_SIM_HOJA_COSTO_PNP = db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpMarcaS == Marca && x.SimPnpColeccionS == Coleccion).ToList();
                    }
                }
                return model;
            }
            else
                return null;
        }

        //ACTUALIZO LOS ESTADOS DE CIERRE DE LA HOJA DE COSTOS
        public List<string> CerrarHojas(string Estado, List<string> Referencias, string Tipo)
        {
            List<string> lstEstados = new List<string>();
            int Codigo = 0;
            foreach (string var in Referencias)
            {
                try
                {
                    if (Tipo == "CE")
                    {
                        using (var db = new DataBaseContext())
                        {
                            db.Configuration.ValidateOnSaveEnabled = false;
                            Codigo = db.TBL_HOJA_COSTO_PNP.Where(e => e.PnpReferenciaS == var).Select(e => e.PnpCodigoN).FirstOrDefault();
                            TBL_HOJA_COSTO_PNP _model = new TBL_HOJA_COSTO_PNP { PnpCodigoN = Codigo, PnpEstadoS = Estado, PnpReferenciaS = var };
                            db.TBL_HOJA_COSTO_PNP.Attach(_model);
                            db.Entry(_model).Property(e => e.PnpEstadoS).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                    else if (Tipo == "CS")
                    {

                    }
                }
                catch (Exception ex)
                {
                    lstEstados.Add("Ocurrio un error en la referencia: " + var);
                }
            }
            return lstEstados;
        }
    }
}