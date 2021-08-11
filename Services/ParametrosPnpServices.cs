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
    public class ParametrosPnpServices
    {
        public List<string> obtenerMarcas(string factor)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PNP.Where(x => x.PnFactorS == factor)
                    .Select(x => x.PnMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColecciones(string factor, string marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PNP.Where(x => x.PnMarcaS == marca && x.PnFactorS == factor)
                    .Select(x => x.PnColeccionS).Distinct().ToList();
            }
        }

        public List<string> obtenerLineas(string factor, string marca, string coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PNP.Where(x => x.PnFactorS == factor && x.PnColeccionS == coleccion && x.PnMarcaS == marca)
                    .Select(x => x.PnLineaS).Distinct().ToList();
            }
        }

        public List<string> obtenerSublineas(string factor, string marca, string coleccion, string linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PNP.Where(x => x.PnFactorS == factor && x.PnColeccionS == coleccion
                                                        && x.PnMarcaS == marca && x.PnLineaS == linea)
                    .Select(x => x.PnSubLineaS).Distinct().ToList();
            }
        }

        public PARAMETROS_PNP obtenerParametros(string Factor, string Marca, string Coleccion, string Linea, string Sublinea)
        {
            using (var db = new DataBaseContext())
            {
                PARAMETROS_PNP model = new PARAMETROS_PNP();
                model.Marcas = GetSelectListItems(new List<string>() { Marca });
                model.Colecciones = GetSelectListItems(new List<string>() { Coleccion });
                model.Lineas = GetSelectListItems(new List<string>() { Linea });
                model.Sublineas = GetSelectListItems(new List<string>() { Sublinea });
                model._TBL_PARAM_PNP = db.TBL_PARAM_PNP.Where(x => x.PnFactorS == Factor
                                                    && x.PnColeccionS == Coleccion
                                                    && x.PnMarcaS == Marca
                                                    && x.PnLineaS == Linea
                                                    && x.PnSubLineaS == Sublinea).FirstOrDefault();
                return model;
            }
        }

        public string actualizar_crearParametros(TBL_PARAM_PNP param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Entry(param).State = param.PnCodigoN == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    strMensaje = "Proceso terminado correctamente";
                    return strMensaje;
                }
            }
            catch (Exception ex)
            {
                return strMensaje = ex.Message;
            }
        }

        public string cargueParametros(TBL_PARAM_PNP param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    param.PnCodigoN = db.TBL_PARAM_PNP.Where(x => x.PnFactorS == param.PnFactorS
                                                    && x.PnColeccionS == param.PnColeccionS
                                                    && x.PnMarcaS == param.PnMarcaS
                                                    && x.PnLineaS == param.PnLineaS
                                                    && x.PnSubLineaS == param.PnSubLineaS)
                                 .Select(x => x.PnCodigoN).FirstOrDefault();

                    if (param.PnCodigoN != 0)
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PARAM_PNP.Attach(param);
                        db.Entry(param).Property(x => x.ID_Coleccion).IsModified = true;
                        db.Entry(param).Property(x => x.ID_Linea).IsModified = true;
                        db.Entry(param).Property(x => x.ID_Sublinea).IsModified = true;
                        db.Entry(param).Property(x => x.PnColeccionS).IsModified = true;
                        db.Entry(param).Property(x => x.PnMarcaS).IsModified = true;
                        db.Entry(param).Property(x => x.PnLineaS).IsModified = true;
                        db.Entry(param).Property(x => x.PnSubLineaS).IsModified = true;
                        db.Entry(param).Property(x => x.PnPinSeguridadF).IsModified = true;
                        db.Entry(param).Property(x => x.PnGastosOrigenF).IsModified = true;
                        db.Entry(param).Property(x => x.PnGastosFleteF).IsModified = true;
                        db.Entry(param).Property(x => x.PnArancelF).IsModified = true;
                        db.Entry(param).Property(x => x.PnSeguroIntF).IsModified = true;
                        db.Entry(param).Property(x => x.PnGastosDestF).IsModified = true;
                        db.Entry(param).Property(x => x.PnOtrosGastosF).IsModified = true;
                        db.Entry(param).Property(x => x.PnAdcPrdM).IsModified = true;
                        db.Entry(param).Property(x => x.PnSensorizacionM).IsModified = true;
                        db.Entry(param).Property(x => x.PnArregloPrdM).IsModified = true;
                        db.Entry(param).Property(x => x.PnReconstruccionM).IsModified = true;
                        db.Entry(param).Property(x => x.PnPorcGastosEstimadoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnPorcGastosRealF).IsModified = true;
                        db.Entry(param).Property(x => x.PnFactorMinF).IsModified = true;
                        db.Entry(param).Property(x => x.PnFactorMaxF).IsModified = true;
                        db.Entry(param).Property(x => x.PnIvaF).IsModified = true;
                        db.Entry(param).Property(x => x.PnTRMF).IsModified = true;
                        db.Entry(param).Property(x => x.PnEnterpriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PnMediumPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PnPremiumPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PnDivisorCocienteF).IsModified = true;
                        db.Entry(param).Property(x => x.PnDivisorCocienteDosF).IsModified = true;
                        db.Entry(param).Property(x => x.PnDivisorResiduoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnTopeMinimoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnTopeMaximoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnValorVerdaderoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnValorFalsoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnRedondeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PnFecActD).IsModified = true;

                        param.PnFecActD = DateTime.Now;
                    }
                    else
                    {
                        param.PnFecCreD = DateTime.Now;
                        db.Entry(param).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    //db.Entry(param).State = param.PpCodigoN == 0 ? EntityState.Added : EntityState.Modified;
                    //db.SaveChanges();
                    strMensaje = "Registro actualizado correctamente";
                    return strMensaje;
                }
            }
            catch (Exception ex)
            {
                return strMensaje = ex.Message;
            }
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
    }
}