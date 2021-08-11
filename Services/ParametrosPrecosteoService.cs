using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AppWebHojaCosto.Services
{
    public class ParametrosPrecosteoService
    {
        public List<string> obtenerMarcas(string factor)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PRE.Where(x => x.PreFactorS == factor)
                    .Select(x => x.PreMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColecciones(string factor, string marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PRE.Where(x => x.PreMarcaS == marca && x.PreFactorS == factor)
                    .Select(x => x.PreColeccionS).Distinct().ToList();
            }
        }

        public List<string> obtenerLineas(string factor, string marca, string coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PRE.Where(x => x.PreFactorS == factor && x.PreColeccionS == coleccion && x.PreMarcaS == marca)
                    .Select(x => x.PreLineaS).Distinct().ToList();
            }
        }

        public List<string> obtenerSublineas(string factor, string marca, string coleccion, string linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PARAM_PRE.Where(x => x.PreFactorS == factor && x.PreColeccionS == coleccion
                                                        && x.PreMarcaS == marca && x.PreLineaS == linea)
                    .Select(x => x.PreSubLineaS).Distinct().ToList();
            }
        }

        public PARAMETROS_PRE obtenerParametros(string Factor, string Marca, string Coleccion, string Linea, string Sublinea)
        {
            using (var db = new DataBaseContext())
            {
                PARAMETROS_PRE model = new PARAMETROS_PRE();
                model.Marcas = GetSelectListItems(new List<string>() { Marca });
                model.Colecciones = GetSelectListItems(new List<string>() { Coleccion });
                model.Lineas = GetSelectListItems(new List<string>() { Linea });
                model.Sublineas = GetSelectListItems(new List<string>() { Sublinea });
                model._TBL_PARAM_PRE = db.TBL_PARAM_PRE.Where(x => x.PreFactorS == Factor
                                                    && x.PreColeccionS == Coleccion
                                                    && x.PreMarcaS == Marca
                                                    && x.PreLineaS == Linea
                                                    && x.PreSubLineaS == Sublinea).FirstOrDefault();
                return model;
            }
        }

        public string actualizar_crearParametros(TBL_PARAM_PRE param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Entry(param).State = param.PreCodigoN == 0 ? EntityState.Added : EntityState.Modified;
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

        public string cargueParametros(TBL_PARAM_PRE param)
        {
            string strMensaje = String.Empty;
            try
            {
                using (var db = new DataBaseContext())
                {
                    param.PreCodigoN = db.TBL_PARAM_PRE.Where(x => x.PreFactorS == param.PreFactorS
                                                    && x.PreColeccionS == param.PreColeccionS
                                                    && x.PreMarcaS == param.PreMarcaS
                                                    && x.PreLineaS == param.PreLineaS
                                                    && x.PreSubLineaS == param.PreSubLineaS)
                                 .Select(x => x.PreCodigoN).FirstOrDefault();

                    if (param.PreCodigoN != 0)
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PARAM_PRE.Attach(param);
                        db.Entry(param).Property(x => x.ID_Coleccion).IsModified = true;
                        db.Entry(param).Property(x => x.ID_Linea).IsModified = true;
                        db.Entry(param).Property(x => x.ID_Sublinea).IsModified = true;
                        db.Entry(param).Property(x => x.PreColeccionS).IsModified = true;
                        db.Entry(param).Property(x => x.PreMarcaS).IsModified = true;
                        db.Entry(param).Property(x => x.PreLineaS).IsModified = true;
                        db.Entry(param).Property(x => x.PreSubLineaS).IsModified = true;
                        db.Entry(param).Property(x => x.PreFactorRentabilidadMinF).IsModified = true;
                        db.Entry(param).Property(x => x.PreFactorRentabilidadMaxF).IsModified = true;
                        db.Entry(param).Property(x => x.PreGastosAdminF).IsModified = true;
                        db.Entry(param).Property(x => x.PreGastosFinanF).IsModified = true;
                        db.Entry(param).Property(x => x.PreGastosMercadeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PreAlmacenLineaCanalF).IsModified = true;
                        db.Entry(param).Property(x => x.PreIvaF).IsModified = true;
                        db.Entry(param).Property(x => x.PreAdminxFinanF).IsModified = true;
                        db.Entry(param).Property(x => x.PreMercadeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PreVntsxCanalLineaF).IsModified = true;
                        db.Entry(param).Property(x => x.PreParticipacionAdminF).IsModified = true;
                        db.Entry(param).Property(x => x.PreParticipacionFinanF).IsModified = true;
                        db.Entry(param).Property(x => x.PreParticipacionMercadeoF).IsModified = true;
                        db.Entry(param).Property(x => x.PreEnterPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PreMediumPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PrePremiumPriceM).IsModified = true;
                        db.Entry(param).Property(x => x.PreCocienteDivisorF).IsModified = true;
                        db.Entry(param).Property(x => x.PreCocienteDivisor2F).IsModified = true;
                        db.Entry(param).Property(x => x.PreResiduoDivisorF).IsModified = true;
                        db.Entry(param).Property(x => x.PreTopePrecioMilesF).IsModified = true;
                        db.Entry(param).Property(x => x.PrePrecioMinimoF).IsModified = true;
                        db.Entry(param).Property(x => x.PrePrecioMaximoF).IsModified = true;
                        db.Entry(param).Property(x => x.PreTerminoPrecioF).IsModified = true;
                        db.Entry(param).Property(x => x.PreFactorTelaF).IsModified = true;
                        db.Entry(param).Property(x => x.PreFactorInsumoF).IsModified = true;

                        param.PreFecActD = DateTime.Now;
                    }
                    else
                    {
                        param.PreFecCreD = DateTime.Now;
                        db.Entry(param).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    //db.Entry(param).State = param.PreCodigoN == 0 ? EntityState.Added : EntityState.Modified;
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