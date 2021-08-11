using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class CargueService
    {
        public bool ExisteReferencia(string Referencia, ref int Codigo)
        {
            bool Existe = false;
            using (var db = new DataBaseContext())
            {
                Existe = db.TBL_PRE_HOJA_COSTO_PN.Any(x => x.PreHcReferenciaS == Referencia);
                if (Existe)
                {
                    Codigo = db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcReferenciaS == Referencia).Select(x => x.PreHcCodigoN).FirstOrDefault();
                }
                else
                {
                    Codigo = 0;
                }
            }
            return Existe;
        }

        public int InsertarTelas(TBL_PRE_CONSUMO_TELAS model)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(model).State = EntityState.Added;
                return db.SaveChanges();
            }
        }

        public int InsertarProcesos(TBL_PRE_PROCESO model)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(model).State = EntityState.Added;
                return db.SaveChanges();
            }
        }

        public int InsertarInsumos(TBL_PRE_INS_ACC model)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(model).State = EntityState.Added;
                return db.SaveChanges();
            }
        }

        public int InsertarMarquillas(TBL_PRE_ETIQ_MAR_EMP model)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(model).State = EntityState.Added;
                return db.SaveChanges();
            }
        }

        public int InsertarMODCIF(TBL_PRE_MOD_CIF model)
        {
            using (var db = new DataBaseContext())
            {
                db.Entry(model).State = EntityState.Added;
                return db.SaveChanges();
            }
        }

        public int InsertarCotizacionTelas(TBL_CARGUE_COTIZACION_TELA model)
        {
            try
            {
                bool Existe = false;
                using (var db = new DataBaseContext())
                {
                    Existe = db.TBL_CARGUE_COTIZACION_TELA.Any(x => x.CtCodeS == model.CtCodeS);
                    if (Existe)
                    {
                        model.CtCodigoN = db.TBL_CARGUE_COTIZACION_TELA.Where(x => x.CtCodeS == model.CtCodeS).Select(x => x.CtCodigoN).FirstOrDefault();
                        db.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(model).State = EntityState.Added;
                    }
                    return db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int InsertarCotizacionInsumos(TBL_CARGUE_COTIZACION_INSUMO model)
        {
            try
            {
                bool Existe = false;
                using (var db = new DataBaseContext())
                {
                    Existe = db.TBL_CARGUE_COTIZACION_INSUMO.Any(x => x.CiCodeS == model.CiCodeS);
                    if (Existe)
                    {
                        model.CiCodigoN = db.TBL_CARGUE_COTIZACION_INSUMO.Where(x => x.CiCodeS == model.CiCodeS).Select(x => x.CiCodigoN).FirstOrDefault();
                        db.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(model).State = EntityState.Added;
                    }
                    return db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}