using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AppWebHojaCosto.Services
{
    public class ParametrosServices
    {
        public List<string> obtenerMarcas(string factor)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PN.Where(x => x.PpFactorS == factor)
                    .Select(x => x.PpMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColecciones(string factor, string marca)
        {
            using(var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PN.Where(x => x.PpMarcaS == marca && x.PpFactorS == factor)
                    .Select(x => x.PpColeccionS).Distinct().ToList();
            }
        }

        public List<string> obtenerLineas(string factor, string marca, string coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PN.Where(x => x.PpFactorS == factor && x.PpColeccionS == coleccion && x.PpMarcaS == marca)
                    .Select(x => x.PpLineaS).Distinct().ToList();
            }
        }

        public List<string> obtenerSublineas(string factor, string marca, string coleccion, string linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PN.Where(x => x.PpFactorS == factor && x.PpColeccionS == coleccion
                                                        && x.PpMarcaS == marca && x.PpLineaS == linea)
                    .Select(x => x.PpSubLineaS).Distinct().ToList();
            }
        }

        public PARAMETROS_PN obtenerParametros(string Factor, string Marca, string Coleccion, string Linea, string Sublinea)
        {
            using (var db = new DataBaseContext())
            {
                PARAMETROS_PN model = new PARAMETROS_PN();
                model.Marcas = GetSelectListItems(new List<string>() { Marca });
                model.Colecciones = GetSelectListItems(new List<string>() { Coleccion });
                model.Lineas = GetSelectListItems(new List<string>() { Linea });
                model.Sublineas = GetSelectListItems(new List<string>() { Sublinea });
                model._TBL_PARAM_PN = db.TBL_PARAM_PN.Where(x => x.PpFactorS == Factor
                                                    && x.PpColeccionS == Coleccion
                                                    && x.PpMarcaS == Marca
                                                    && x.PpLineaS == Linea
                                                    && x.PpSubLineaS == Sublinea).FirstOrDefault();
                return model;
            }
        }

        public string actualizar_crearParametros(TBL_PARAM_PN param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Entry(param).State = param.PpCodigoN == 0 ? EntityState.Added : EntityState.Modified;
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

        public string cargueParametros(TBL_PARAM_PN param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    param.PpCodigoN = db.TBL_PARAM_PN.Where(x => x.PpFactorS == param.PpFactorS
                                                    && x.PpColeccionS == param.PpColeccionS
                                                    && x.PpMarcaS == param.PpMarcaS
                                                    && x.PpLineaS == param.PpLineaS
                                                    && x.PpSubLineaS == param.PpSubLineaS)
                                 .Select(x=> x.PpCodigoN).FirstOrDefault();

                    if(param.PpCodigoN != 0)
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PARAM_PN.Attach(param);
                        db.Entry(param).Property(x => x.ID_Coleccion).IsModified = true;
                        db.Entry(param).Property(x => x.ID_Linea).IsModified = true;
                        db.Entry(param).Property(x => x.ID_Sublinea).IsModified = true;
                        db.Entry(param).Property(x => x.PpColeccionS).IsModified = true;
                        db.Entry(param).Property(x => x.PpMarcaS).IsModified = true;
                        db.Entry(param).Property(x => x.PpLineaS).IsModified = true;
                        db.Entry(param).Property(x => x.PpSubLineaS).IsModified = true;
                        db.Entry(param).Property(x => x.PpFactorRentabilidadMinF).IsModified = true;
                        db.Entry(param).Property(x => x.PpFactorRentabilidadMaxF).IsModified = true;
                        db.Entry(param).Property(x => x.PpGastosAdminF).IsModified = true;
                        db.Entry(param).Property(x => x.PpGastosFinanF).IsModified = true;
                        db.Entry(param).Property(x => x.PpGastosMercadeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PpAlmacenLineaCanalF).IsModified = true;
                        db.Entry(param).Property(x => x.PpIvaF).IsModified = true;
                        db.Entry(param).Property(x => x.PpAdminxFinanF).IsModified = true;
                        db.Entry(param).Property(x => x.PpMercadeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PpVntsxCanalLineaF).IsModified = true;
                        db.Entry(param).Property(x => x.PpParticipacionAdminF).IsModified = true;
                        db.Entry(param).Property(x => x.PpParticipacionFinanF).IsModified = true;
                        db.Entry(param).Property(x => x.PpParticipacionMercadeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PpEnterPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PpMediumPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PpPremiumPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PpCocienteDivisorF).IsModified = true;
                        db.Entry(param).Property(x => x.PpCocienteDivisor2F).IsModified = true;
                        db.Entry(param).Property(x => x.PpResiduoDivisorF).IsModified = true;
                        db.Entry(param).Property(x => x.PpTopePrecioMilesF).IsModified = true;
                        db.Entry(param).Property(x => x.PpPrecioMinimoF).IsModified = true;
                        db.Entry(param).Property(x => x.PpPrecioMaximoF).IsModified = true;
                        db.Entry(param).Property(x => x.PpTerminoPrecioF).IsModified = true;

                        param.PpFecActD = DateTime.Now;
                    }
                    else
                    {
                        param.PpFecCreD = DateTime.Now;
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