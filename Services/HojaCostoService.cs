using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AppWebHojaCosto.Services
{
    public class HojaCostoService
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
            lstTipos.Add(new SelectListItem
            {
                Text = "Hoja de Costo PreCosteo",
                Value = "CP"
            });
            return lstTipos;
        }

        public List<string> ObtenerReferencias(string Tipo)
        {
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PN
                        .Select(x => x.HcReferenciaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PN
                        .Select(x => x.SimHcReferenciaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_PRE_HOJA_COSTO_PN
                        .Select(x => x.PreHcReferenciaS).Distinct().ToList();
                }
            }
            return null;
        }

        public List<string> ObtenerMarcas(string Tipo)
        {
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PN
                        .Select(x => x.HcMarcaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PN
                        .Select(x => x.SimHcMarcaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_PRE_HOJA_COSTO_PN
                        .Select(x => x.PreHcMarcaS).Distinct().ToList();
                }
            }
            return null;
        }

        public List<string> ObtenerColeccion(string Tipo, string Marca)
        {
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca)
                        .Select(x => x.HcColeccionS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca)
                        .Select(x => x.SimHcColeccionS).Distinct().ToList();
                }
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca)
                        .Select(x => x.PreHcColeccionS).Distinct().ToList();
                }
            }
            return null;
        }

        public List<string> ObtenerLinea(string Tipo, string Marca, string Coleccion)
        {
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca && x.HcColeccionS == Coleccion)
                        .Select(x => x.HcLineaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca && x.SimHcColeccionS == Coleccion)
                        .Select(x => x.SimHcLineaS).Distinct().ToList();
                }
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca && x.PreHcColeccionS == Coleccion)
                        .Select(x => x.PreHcLineaS).Distinct().ToList();
                }
            }
            return null;
        }

        public List<string> ObtenerEstado(string Tipo, string Marca, string Coleccion, string Linea)
        {
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca && x.HcColeccionS == Coleccion && x.HcLineaS == Linea)
                        .Select(x => x.HcEstadoS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca && x.SimHcColeccionS == Coleccion && x.SimHcLineaS == Linea)
                        .Select(x => x.SimHcEstadoS).Distinct().ToList();
                }
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca && x.PreHcColeccionS == Coleccion && x.PreHcLineaS == Linea)
                        .Select(x => x.PreHcEstadoS).Distinct().ToList();
                }
            }
            return null;
        }

        public List<string> ObtenerEstadoCierre(string Tipo, string Marca, string Coleccion, string Linea/*, string Estado*/)
        {
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca && x.HcColeccionS == Coleccion && x.HcLineaS == Linea/* && x.HcEstadoS == Estado*/)
                        .Select(x => x.HcEstadoAproS).Distinct().ToList();
                }
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca && x.SimHcColeccionS == Coleccion && x.SimHcLineaS == Linea /*&& x.SimHcEstadoS == Estado*/)
                        .Select(x => x.SimHcEstadoAproS).Distinct().ToList();
                }
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca && x.PreHcColeccionS == Coleccion && x.PreHcLineaS == Linea /*&& x.PreHcEstadoS == Estado*/)
                        .Select(x => x.PreHcEstadoAproS).Distinct().ToList();
                }
            }
            return null;
        }

        /// <summary>
        /// Consulta de tablas dependientes en forma de lista para hoja de costo estandar
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public HOJA_COSTO_ESTANDAR _COSTO_ESTANDAR(string Referencia)
        {
            HOJA_COSTO_ESTANDAR model = new HOJA_COSTO_ESTANDAR();
            using (DataBaseContext db = new DataBaseContext())
            {
                model.TBL_HOJA_COSTO_PN = db.TBL_HOJA_COSTO_PN.Where(x => x.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_CONSUMO_TELAS = db.TBL_CONSUMO_TELAS.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_PROCESO = db.TBL_PROCESO.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_INS_ACC = db.TBL_INS_ACC.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_ETIQ_MAR_EMP = db.TBL_ETIQ_MAR_EMP.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_MOD_CIF = db.TBL_MOD_CIF.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_RES_GEN_COS_PRD = db.TBL_RES_GEN_COS_PRD.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_RES_GAS_COS_DIS = db.TBL_RES_GAS_COS_DIS.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
                model.TBL_ANALISIS_PREC = db.TBL_ANALISIS_PREC.Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_HOJA_COSTO_PN.HcReferenciaS == Referencia)
                    .ToList();
            }
            return model;
        }

        /// <summary>
        /// Consulta de tablas dependientes en forma de lista para Hoja Costo Simulada
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public HOJA_COSTO_SIMULADA _COSTO_SIMLUADA(string Referencia)
        {
            HOJA_COSTO_SIMULADA model = new HOJA_COSTO_SIMULADA();
            using (DataBaseContext db = new DataBaseContext())
            {
                model.TBL_SIM_HOJA_COSTO_PN = db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcReferenciaS == Referencia).FirstOrDefault();
                model.TBL_SIM_CONSUMO_TELAS = db.TBL_SIM_CONSUMO_TELAS.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_SIM_PROCESO = db.TBL_SIM_PROCESO.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_SIM_INS_ACC = db.TBL_SIM_INS_ACC.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_SIM_ETIQ_MAR_EMP = db.TBL_SIM_ETIQ_MAR_EMP.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_SIM_MOD_CIF = db.TBL_SIM_MOD_CIF.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .FirstOrDefault();
                model.TBL_SIM_RES_GEN_COS_PRD = db.TBL_SIM_RES_GEN_COS_PRD.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .FirstOrDefault();
                model.TBL_SIM_RES_GAS_COS_DIS = db.TBL_SIM_RES_GAS_COS_DIS.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .FirstOrDefault();
                model.TBL_SIM_ANALISIS_PREC = db.TBL_SIM_ANALISIS_PREC.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .FirstOrDefault();
            }
            return model;
        }

        /// <summary>
        /// FUNCION UTILIZADA PARA LA GENERACION DEL REPORTE
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public LST_HOJA_COSTO_SIMULADA LST_COSTO_SIMLUADA(string Referencia)
        {
            LST_HOJA_COSTO_SIMULADA model = new LST_HOJA_COSTO_SIMULADA();
            using (DataBaseContext db = new DataBaseContext())
            {
                model.TBL_SIM_HOJA_COSTO_PN = db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcReferenciaS == Referencia).ToList();
                model.TBL_SIM_CONSUMO_TELAS = db.TBL_SIM_CONSUMO_TELAS.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_PROCESO = db.TBL_SIM_PROCESO.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_INS_ACC = db.TBL_SIM_INS_ACC.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_ETIQ_MAR_EMP = db.TBL_SIM_ETIQ_MAR_EMP.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_MOD_CIF = db.TBL_SIM_MOD_CIF.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_RES_GEN_COS_PRD = db.TBL_SIM_RES_GEN_COS_PRD.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_RES_GAS_COS_DIS = db.TBL_SIM_RES_GAS_COS_DIS.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
                model.TBL_SIM_ANALISIS_PREC = db.TBL_SIM_ANALISIS_PREC.Join(db.TBL_SIM_HOJA_COSTO_PN, x => x.SimHcCodigoN, y => y.SimHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_SIM_HOJA_COSTO_PN.SimHcReferenciaS == Referencia)
                    .ToList();
            }
            return model;
        }

        /// <summary>
        /// Consulta de tablas dependientes en forma de lista para Hoja Costo Precosteo
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public HOJA_COSTO_PRECOSTEO _COSTO_PRECOSTEO(string Referencia)
        {
            HOJA_COSTO_PRECOSTEO model = new HOJA_COSTO_PRECOSTEO();
            using (DataBaseContext db = new DataBaseContext())
            {
                model.TBL_PRE_HOJA_COSTO_PN = db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcReferenciaS == Referencia).FirstOrDefault();
                model.TBL_PRE_CONSUMO_TELAS = db.TBL_PRE_CONSUMO_TELAS.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_PRE_PROCESO = db.TBL_PRE_PROCESO.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_PRE_INS_ACC = db.TBL_PRE_INS_ACC.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_PRE_ETIQ_MAR_EMP = db.TBL_PRE_ETIQ_MAR_EMP.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .ToList();
                model.TBL_PRE_MOD_CIF = db.TBL_PRE_MOD_CIF.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .FirstOrDefault();
                model.TBL_PRE_RES_GEN_COS_PRD = db.TBL_PRE_RES_GEN_COS_PRD.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .FirstOrDefault();
                model.TBL_PRE_RES_GAS_COS_DIS = db.TBL_PRE_RES_GAS_COS_DIS.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .FirstOrDefault();
                model.TBL_PRE_ANALISIS_PREC = db.TBL_PRE_ANALISIS_PREC.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Select(z => z.x)
                    .Where(x => x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia).DefaultIfEmpty()
                    .FirstOrDefault();
            }
            return model;
        }

        public LST_HOJA_COSTO_PRECOSTEO LST_COSTO_PRECOSTEO(string Referencia)
        {
            LST_HOJA_COSTO_PRECOSTEO model = new LST_HOJA_COSTO_PRECOSTEO();
            using (DataBaseContext db = new DataBaseContext())
            {
                model.TBL_PRE_HOJA_COSTO_PN = db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcReferenciaS == Referencia).ToList();
                model.TBL_PRE_CONSUMO_TELAS = db.TBL_PRE_CONSUMO_TELAS.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_PROCESO = db.TBL_PRE_PROCESO.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_INS_ACC = db.TBL_PRE_INS_ACC.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_ETIQ_MAR_EMP = db.TBL_PRE_ETIQ_MAR_EMP.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_MOD_CIF = db.TBL_PRE_MOD_CIF.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_RES_GEN_COS_PRD = db.TBL_PRE_RES_GEN_COS_PRD.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_RES_GAS_COS_DIS = db.TBL_PRE_RES_GAS_COS_DIS.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
                model.TBL_PRE_ANALISIS_PREC = db.TBL_PRE_ANALISIS_PREC.Join(db.TBL_PRE_HOJA_COSTO_PN, x => x.PreHcCodigoN, y => y.PreHcCodigoN, (x, y) => new { x, y })
                    .Where(x => x.x.PreHcCodigoN == x.y.PreHcCodigoN && x.x.TBL_PRE_HOJA_COSTO_PN.PreHcReferenciaS == Referencia)
                    .Select(z => z.x)
                    .ToList();
            }
            return model;
        }

        /// <summary>
        /// Metodo de consulta para llenar la tabla de hojas de costo PN
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="Marca"></param>
        /// <param name="Coleccion"></param>
        /// <param name="Linea"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public HOJA_COSTO_PN _LST_COSTO_PN(string Tipo, string Marca, string Coleccion, string Linea, string Estado)
        {
            HOJA_COSTO_PN model = new HOJA_COSTO_PN();
            if (Tipo == "CE")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    if (!string.IsNullOrEmpty(Linea) && !string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_HOJA_COSTO_PN = db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca && x.HcColeccionS == Coleccion
                                                                            && x.HcLineaS == Linea && x.HcEstadoAproS == Estado).ToList();
                    }
                    else if (!string.IsNullOrEmpty(Linea) && string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_HOJA_COSTO_PN = db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca && x.HcColeccionS == Coleccion
                                                                            && x.HcLineaS == Linea).ToList();
                    }
                    else
                    {
                        model.LST_TBL_HOJA_COSTO_PN = db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == Marca && x.HcColeccionS == Coleccion).ToList();
                    }
                }
                return model;
            }
            else if (Tipo == "CS")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    if (!string.IsNullOrEmpty(Linea) && !string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_SIM_HOJA_COSTO_PN = db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca && x.SimHcColeccionS == Coleccion
                                                                            && x.SimHcLineaS == Linea && x.SimHcEstadoAproS == Estado).ToList();
                    }
                    else if (!string.IsNullOrEmpty(Linea) && string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_SIM_HOJA_COSTO_PN = db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca && x.SimHcColeccionS == Coleccion
                                                                            && x.SimHcLineaS == Linea).ToList();
                    }
                    else
                    {
                        model.LST_TBL_SIM_HOJA_COSTO_PN = db.TBL_SIM_HOJA_COSTO_PN.Where(x => x.SimHcMarcaS == Marca && x.SimHcColeccionS == Coleccion).ToList();
                    }
                }
                return model;
            }
            else if (Tipo == "CP")
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    if (!string.IsNullOrEmpty(Linea) && !string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_PRE_HOJA_COSTO_PN = db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca && x.PreHcColeccionS == Coleccion
                                                                            && x.PreHcLineaS == Linea && x.PreHcEstadoAproS == Estado).ToList();
                    }
                    else if (!string.IsNullOrEmpty(Linea) && string.IsNullOrEmpty(Estado))
                    {
                        model.LST_TBL_PRE_HOJA_COSTO_PN = db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca && x.PreHcColeccionS == Coleccion
                                                                            && x.PreHcLineaS == Linea).ToList();
                    }
                    else
                    {
                        model.LST_TBL_PRE_HOJA_COSTO_PN = db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == Marca && x.PreHcColeccionS == Coleccion).ToList();
                    }
                }
                return model;
            }
            return null;
        }

        /// <summary>
        /// Metodo de consulta de hoja de costo estandar para la generacion del reporte
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<TBL_HOJA_COSTO_PN> _LST_HOJA_COSTO_PN(string Referencia)
        {
            List<TBL_HOJA_COSTO_PN> model = new List<TBL_HOJA_COSTO_PN>();
            using (DataBaseContext db = new DataBaseContext())
            {
                model = db.TBL_HOJA_COSTO_PN.Where(x => x.HcReferenciaS == Referencia)
                    .ToList();
            }
            return model;
        }

        /// <summary>
        /// ACTUALIZO LOS ESTADOS DE CIERRE DE LA HOJA DE COSTOS
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="Referencias"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public List<string> CerrarHojas(string Estado, List<string> Referencias, string Tipo)
        {
            List<string> lstEstados = new List<string>();
            int Codigo;
            foreach (string var in Referencias)
            {
                try
                {
                    if (Tipo == "CE")
                    {
                        using (DataBaseContext db = new DataBaseContext())
                        {
                            db.Configuration.ValidateOnSaveEnabled = false;
                            Codigo = db.TBL_HOJA_COSTO_PN.Where(e => e.HcReferenciaS == var).Select(e => e.HcCodigoN).FirstOrDefault();
                            TBL_HOJA_COSTO_PN _model = new TBL_HOJA_COSTO_PN { HcCodigoN = Codigo, HcEstadoAproS = Estado };
                            db.TBL_HOJA_COSTO_PN.Attach(_model);
                            db.Entry(_model).Property(e => e.HcEstadoAproS).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                    else if (Tipo == "CS")
                    {
                        using (DataBaseContext db = new DataBaseContext())
                        {
                            db.Configuration.ValidateOnSaveEnabled = false;
                            Codigo = db.TBL_SIM_HOJA_COSTO_PN.Where(e => e.SimHcReferenciaS == var).Select(e => e.SimHcCodigoN).FirstOrDefault();
                            TBL_SIM_HOJA_COSTO_PN _model = new TBL_SIM_HOJA_COSTO_PN { SimHcCodigoN = Codigo, SimHcEstadoAproS = Estado };
                            db.TBL_SIM_HOJA_COSTO_PN.Attach(_model);
                            db.Entry(_model).Property(e => e.SimHcEstadoAproS).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                    else if (Tipo == "CP")
                    {
                        using (DataBaseContext db = new DataBaseContext())
                        {
                            db.Configuration.ValidateOnSaveEnabled = false;
                            Codigo = db.TBL_PRE_HOJA_COSTO_PN.Where(e => e.PreHcReferenciaS == var).Select(e => e.PreHcCodigoN).FirstOrDefault();
                            TBL_PRE_HOJA_COSTO_PN _model = new TBL_PRE_HOJA_COSTO_PN { PreHcCodigoN = Codigo, PreHcEstadoAproS = Estado };
                            db.TBL_PRE_HOJA_COSTO_PN.Attach(_model);
                            db.Entry(_model).Property(e => e.PreHcEstadoAproS).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {
                    lstEstados.Add("Ocurrio un error en la referencia: " + var);
                }
            }
            return lstEstados;
        }

        /// <summary>
        /// METODO PARA RETORNAR VALORES DEL RECALCULO DE LA HOJA DE COSTOS
        /// </summary>
        /// <param name="Marca"></param>
        /// <param name="Coleccion"></param>
        /// <param name="Linea"></param>
        /// <param name="Sublinea"></param>
        /// <returns></returns>
        public List<LISTA_PARAMETROS> ListParametros(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            List<LISTA_PARAMETROS> lstParam = new List<LISTA_PARAMETROS>();
            DataTable dt = new DataTable();
            DataTable dtReal = new DataTable();
            using (DataBaseContext db = new DataBaseContext())
            {
                List<TBL_PARAM_PN> data = db.TBL_PARAM_PN.Where(x => x.PpMarcaS == Marca && x.PpColeccionS == Coleccion && x.PpLineaS == Linea && x.PpSubLineaS == Sublinea && x.PpFactorS == "FE").ToList();
                List<TBL_PARAM_PN> dataReal = db.TBL_PARAM_PN.Where(x => x.PpMarcaS == Marca && x.PpColeccionS == Coleccion && x.PpLineaS == Linea && x.PpSubLineaS == Sublinea && x.PpFactorS == "FR").ToList();
                using (ObjectReader reader = ObjectReader.Create(data))
                {
                    dt.Load(reader);
                }
                using (ObjectReader reader = ObjectReader.Create(dataReal))
                {
                    dtReal.Load(reader);
                }
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    LISTA_PARAMETROS obj = new LISTA_PARAMETROS
                    {
                        NombreCampo = dt.Columns[i].ColumnName.ToString(),
                        ValorCampo = dt.Rows[0][i].ToString()
                    };
                    lstParam.Add(obj);
                }
            }
            if (dtReal != null && dtReal.Rows.Count > 0)
            {
                for (int i = 0; i < dtReal.Columns.Count; i++)
                {
                    LISTA_PARAMETROS obj = new LISTA_PARAMETROS
                    {
                        NombreCampo = dtReal.Columns[i].ColumnName.ToString() + "_Real",
                        ValorCampo = dtReal.Rows[0][i].ToString()
                    };
                    lstParam.Add(obj);
                }
            }
            return lstParam;
        }

        /// <summary>
        /// GUARDAR HOJA DE COSTO SIMULADA
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GuardarHojaSimulada(HOJA_COSTO_SIMULADA model)
        {
            int CodigoHoja = model.TBL_SIM_HOJA_COSTO_PN.SimHcCodigoN;
            //GUARDAR CONSUMO DE TELAS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_SIM_CONSUMO_TELAS telas = new TBL_SIM_CONSUMO_TELAS();
                    if (model.TBL_SIM_CONSUMO_TELAS.Count > 0)
                    {
                        foreach (TBL_SIM_CONSUMO_TELAS item in model.TBL_SIM_CONSUMO_TELAS)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.SimCtCodigoN != 0)
                                {
                                    telas = new TBL_SIM_CONSUMO_TELAS
                                    {
                                        SimCtCodigoN = item.SimCtCodigoN
                                    };
                                    db.Entry(telas).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.SimCtCodigoN != 0)
                            {
                                telas = new TBL_SIM_CONSUMO_TELAS
                                {
                                    SimCtCodigoN = item.SimCtCodigoN,
                                    SimHcCodigoN = item.SimHcCodigoN,
                                    SimCtNombreS = item.SimCtNombreS,
                                    SimCtColorS = item.SimCtColorS,
                                    SimCtCtsxMtD = item.SimCtCtsxMtD,
                                    SimCtConF = item.SimCtConF,
                                    SimCtTotalD = item.SimCtTotalD,
                                    SimCtFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_SIM_CONSUMO_TELAS.Attach(telas);
                                db.Entry(telas).Property(x => x.SimCtNombreS).IsModified = true;
                                db.Entry(telas).Property(x => x.SimCtColorS).IsModified = true;
                                db.Entry(telas).Property(x => x.SimCtCtsxMtD).IsModified = true;
                                db.Entry(telas).Property(x => x.SimCtConF).IsModified = true;
                                db.Entry(telas).Property(x => x.SimCtTotalD).IsModified = true;
                                db.Entry(telas).Property(x => x.SimCtFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                telas = new TBL_SIM_CONSUMO_TELAS
                                {
                                    SimHcCodigoN = CodigoHoja,
                                    SimCtNombreS = item.SimCtNombreS,
                                    SimCtColorS = item.SimCtColorS,
                                    SimCtCtsxMtD = item.SimCtCtsxMtD,
                                    SimCtConF = item.SimCtConF,
                                    SimCtTotalD = item.SimCtTotalD,
                                    SimCtFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(telas).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                        hoja = new TBL_SIM_HOJA_COSTO_PN
                        {
                            SimHcCodigoN = CodigoHoja,
                            SimHcTotalConTelasD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalConTelasD,
                            SimHcTotalTelasD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalTelasD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.SimHcTotalConTelasD).IsModified = true;
                        db.Entry(hoja).Property(x => x.SimHcTotalTelasD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Consumo Telas";
                }
            }

            //FIN

            //GUARDAR PROCESOS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_SIM_PROCESO procesos = new TBL_SIM_PROCESO();
                    if (model.TBL_SIM_PROCESO.Count > 0)
                    {
                        foreach (TBL_SIM_PROCESO item in model.TBL_SIM_PROCESO)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.SimPrCodigoN != 0)
                                {
                                    procesos = new TBL_SIM_PROCESO
                                    {
                                        SimPrCodigoN = item.SimPrCodigoN
                                    };
                                    db.Entry(procesos).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.SimPrCodigoN != 0)
                            {
                                procesos = new TBL_SIM_PROCESO
                                {
                                    SimPrCodigoN = item.SimPrCodigoN,
                                    SimHcCodigoN = item.SimHcCodigoN,
                                    SimPrDetalleS = item.SimPrDetalleS,
                                    SimPrCostoM = item.SimPrCostoM,
                                    SimPrFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_SIM_PROCESO.Attach(procesos);
                                db.Entry(procesos).Property(x => x.SimPrDetalleS).IsModified = true;
                                db.Entry(procesos).Property(x => x.SimPrCostoM).IsModified = true;
                                db.Entry(procesos).Property(x => x.SimPrFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                procesos = new TBL_SIM_PROCESO
                                {
                                    SimHcCodigoN = item.SimHcCodigoN,
                                    SimPrDetalleS = item.SimPrDetalleS,
                                    SimPrCostoM = item.SimPrCostoM,
                                    SimPrFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(procesos).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                        hoja = new TBL_SIM_HOJA_COSTO_PN
                        {
                            SimHcCodigoN = CodigoHoja,
                            SimHcTotalProcesosD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalProcesosD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.SimHcTotalProcesosD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Procesos";
                }
            }

            //FIN

            //GUARDAR CONSUMO DE INSUMOS Y ACCESORIOS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_SIM_INS_ACC insumos = new TBL_SIM_INS_ACC();
                    if (model.TBL_SIM_INS_ACC.Count > 0)
                    {
                        foreach (TBL_SIM_INS_ACC item in model.TBL_SIM_INS_ACC)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.SimIaCodigoN != 0)
                                {
                                    insumos = new TBL_SIM_INS_ACC
                                    {
                                        SimIaCodigoN = item.SimIaCodigoN
                                    };
                                    db.Entry(insumos).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.SimIaCodigoN != 0)
                            {
                                insumos = new TBL_SIM_INS_ACC
                                {
                                    SimIaCodigoN = item.SimIaCodigoN,
                                    SimHcCodigoN = item.SimHcCodigoN,
                                    SimIaNombreS = item.SimIaNombreS,
                                    SimIaColorS = item.SimIaColorS,
                                    SimIaCtsxMtD = item.SimIaCtsxMtD,
                                    SimIaConF = item.SimIaConF,
                                    SimIaTotalD = item.SimIaTotalD,
                                    SimIaFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_SIM_INS_ACC.Attach(insumos);
                                db.Entry(insumos).Property(x => x.SimIaNombreS).IsModified = true;
                                db.Entry(insumos).Property(x => x.SimIaColorS).IsModified = true;
                                db.Entry(insumos).Property(x => x.SimIaCtsxMtD).IsModified = true;
                                db.Entry(insumos).Property(x => x.SimIaConF).IsModified = true;
                                db.Entry(insumos).Property(x => x.SimIaTotalD).IsModified = true;
                                db.Entry(insumos).Property(x => x.SimIaFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                insumos = new TBL_SIM_INS_ACC
                                {
                                    SimHcCodigoN = CodigoHoja,
                                    SimIaNombreS = item.SimIaNombreS,
                                    SimIaColorS = item.SimIaColorS,
                                    SimIaCtsxMtD = item.SimIaCtsxMtD,
                                    SimIaConF = item.SimIaConF,
                                    SimIaTotalD = item.SimIaTotalD,
                                    SimIaFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(insumos).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                        hoja = new TBL_SIM_HOJA_COSTO_PN
                        {
                            SimHcCodigoN = CodigoHoja,
                            SimHcTotalInsumoD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalInsumoD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.SimHcTotalInsumoD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Insumos y Accesorios";
                }
            }

            //FIN

            //GUARDAR CONSUMO DE MARQUILLAS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_SIM_ETIQ_MAR_EMP marquillas = new TBL_SIM_ETIQ_MAR_EMP();
                    if (model.TBL_SIM_ETIQ_MAR_EMP.Count > 0)
                    {
                        foreach (TBL_SIM_ETIQ_MAR_EMP item in model.TBL_SIM_ETIQ_MAR_EMP)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.SimEmeCodigoN != 0)
                                {
                                    marquillas = new TBL_SIM_ETIQ_MAR_EMP
                                    {
                                        SimEmeCodigoN = item.SimEmeCodigoN
                                    };
                                    db.Entry(marquillas).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.SimEmeCodigoN != 0)
                            {
                                marquillas = new TBL_SIM_ETIQ_MAR_EMP
                                {
                                    SimEmeCodigoN = item.SimEmeCodigoN,
                                    SimHcCodigoN = item.SimHcCodigoN,
                                    SimEmeNombreS = item.SimEmeNombreS,
                                    SimEmeCtsxMtD = item.SimEmeCtsxMtD,
                                    SimEmeConF = item.SimEmeConF,
                                    SimEmeTotalD = item.SimEmeTotalD,
                                    SimEmeFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_SIM_ETIQ_MAR_EMP.Attach(marquillas);
                                db.Entry(marquillas).Property(x => x.SimEmeNombreS).IsModified = true;
                                db.Entry(marquillas).Property(x => x.SimEmeCtsxMtD).IsModified = true;
                                db.Entry(marquillas).Property(x => x.SimEmeConF).IsModified = true;
                                db.Entry(marquillas).Property(x => x.SimEmeTotalD).IsModified = true;
                                db.Entry(marquillas).Property(x => x.SimEmeFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                marquillas = new TBL_SIM_ETIQ_MAR_EMP
                                {
                                    SimHcCodigoN = CodigoHoja,
                                    SimEmeNombreS = item.SimEmeNombreS,
                                    SimEmeCtsxMtD = item.SimEmeCtsxMtD,
                                    SimEmeConF = item.SimEmeConF,
                                    SimEmeTotalD = item.SimEmeTotalD,
                                    SimEmeFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(marquillas).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                        hoja = new TBL_SIM_HOJA_COSTO_PN
                        {
                            SimHcCodigoN = CodigoHoja,
                            SimHcTotalMarquillaD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalMarquillaD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.SimHcTotalMarquillaD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Marquillas";
                }
            }

            //FIN

            //GUARDAR MODF Y CIF

            TBL_SIM_MOD_CIF mod = new TBL_SIM_MOD_CIF();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    mod = model.TBL_SIM_MOD_CIF;
                    mod.SimMcFecActD = DateTime.Now;
                    mod.SimHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_MOD_CIF.Attach(mod);
                    db.Entry(mod).Property(x => x.SimMcCostoIndirectosD).IsModified = true;
                    db.Entry(mod).Property(x => x.SimMcCostoManoObraD).IsModified = true;
                    db.Entry(mod).Property(x => x.SimMcFecActD).IsModified = true;
                    db.SaveChanges();
                    //GUARDO TOTALES
                    TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                    hoja = new TBL_SIM_HOJA_COSTO_PN
                    {
                        SimHcCodigoN = CodigoHoja,
                        SimHcTotalCIFMODD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalCIFMODD
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.SimHcTotalCIFMODD).IsModified = true;
                    db.SaveChanges();
                    //FIN
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: MOD y CIF";
                }
            }

            //FIN

            //GUARDAR RESUMEN GENERAL COSTO PRODUCCION

            TBL_SIM_RES_GEN_COS_PRD costo_prd = new TBL_SIM_RES_GEN_COS_PRD();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    costo_prd = model.TBL_SIM_RES_GEN_COS_PRD;
                    costo_prd.SimRpFecActD = DateTime.Now;
                    costo_prd.SimHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_RES_GEN_COS_PRD.Attach(costo_prd);
                    db.Entry(costo_prd).Property(x => x.SimRpCostoMaterialesD).IsModified = true;
                    db.Entry(costo_prd).Property(x => x.SimRpCostoConversionD).IsModified = true;
                    db.Entry(costo_prd).Property(x => x.SimRpFecActD).IsModified = true;
                    db.SaveChanges();
                    //GUARDO TOTALES
                    TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                    hoja = new TBL_SIM_HOJA_COSTO_PN
                    {
                        SimHcCodigoN = CodigoHoja,
                        SimHcTotalCosPrdD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalCosPrdD
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.SimHcTotalCosPrdD).IsModified = true;
                    db.SaveChanges();
                    //FIN
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Costo Producción";
                }
            }

            //FIN

            //GUARDAR GASTO Y COSTO POR DESTINO DISTRIBUCCION

            TBL_SIM_RES_GAS_COS_DIS costo_dis = new TBL_SIM_RES_GAS_COS_DIS();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    costo_dis = model.TBL_SIM_RES_GAS_COS_DIS;
                    costo_dis.SimRdFecActD = DateTime.Now;
                    costo_dis.SimHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_RES_GAS_COS_DIS.Attach(costo_dis);
                    db.Entry(costo_dis).Property(x => x.SimRdAdminEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdAdminRealD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdFinanEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdFinanRealD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdMercadeoEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdMercadeoRealD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdVentasxCanalEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.SimRdVentasxCanalRealD).IsModified = true;
                    db.SaveChanges();
                    //GUARDO TOTALES
                    TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                    hoja = new TBL_SIM_HOJA_COSTO_PN
                    {
                        SimHcCodigoN = CodigoHoja,
                        SimHcTotalGastosEstD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalGastosEstD,
                        SimHcTotalGastosRealD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalGastosRealD,
                        SimHcTotalxCanalEstD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalxCanalEstD,
                        SimHcTotalxCanalRealD = model.TBL_SIM_HOJA_COSTO_PN.SimHcTotalxCanalRealD
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.SimHcTotalGastosEstD).IsModified = true;
                    db.Entry(hoja).Property(x => x.SimHcTotalGastosRealD).IsModified = true;
                    db.Entry(hoja).Property(x => x.SimHcTotalxCanalEstD).IsModified = true;
                    db.Entry(hoja).Property(x => x.SimHcTotalxCanalRealD).IsModified = true;
                    db.SaveChanges();
                    //FIN
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Gastos por Destino Distribucion";
                }
            }

            //FIN

            //GUARDAR ANALISIS PRECIOS

            TBL_SIM_ANALISIS_PREC analisis = new TBL_SIM_ANALISIS_PREC();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    analisis = model.TBL_SIM_ANALISIS_PREC;
                    analisis.SimApFecActD = DateTime.Now;
                    analisis.SimHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_ANALISIS_PREC.Attach(analisis);
                    db.Entry(analisis).Property(x => x.SimApPrecMaxIvaEstD).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApPrecMaxIvaRealD).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMaxBrutoEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMaxBrutoRealF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMaxOpeEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMaxOpeRealF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApPrecMinIvaEstD).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApPrecMinIvaRealD).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMinBrutoEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMinBrutoRealF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMinOpeEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.SimApMargenMinOpeRealF).IsModified = true;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Analisis Precios";
                }
            }

            //FIN

            //GUARDAR PIRAMIDE PRECIOS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_SIM_HOJA_COSTO_PN hoja = new TBL_SIM_HOJA_COSTO_PN();
                    hoja = new TBL_SIM_HOJA_COSTO_PN
                    {
                        SimHcCodigoN = CodigoHoja,
                        SimHcEnterPriceD = model.TBL_SIM_HOJA_COSTO_PN.SimHcEnterPriceD,
                        SimHcMediumPriceD = model.TBL_SIM_HOJA_COSTO_PN.SimHcMediumPriceD,
                        SimHcPremiumPriceD = model.TBL_SIM_HOJA_COSTO_PN.SimHcPremiumPriceD,
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.SimHcEnterPriceD).IsModified = true;
                    db.Entry(hoja).Property(x => x.SimHcMediumPriceD).IsModified = true;
                    db.Entry(hoja).Property(x => x.SimHcPremiumPriceD).IsModified = true;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Piramide Precios";
                }
            }

            //FIN

            return "Proceso Terminado Correctamente";
        }

        /// <summary>
        /// GUARDAR HOJA DE COSTO PRECOSTEO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GuardarHojaPrecosteo(HOJA_COSTO_PRECOSTEO model)
        {
            int CodigoHoja = model.TBL_PRE_HOJA_COSTO_PN.PreHcCodigoN;
            //GUARDAR CONSUMO DE TELAS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_PRE_CONSUMO_TELAS telas = new TBL_PRE_CONSUMO_TELAS();
                    if (model.TBL_PRE_CONSUMO_TELAS.Count > 0)
                    {
                        foreach (TBL_PRE_CONSUMO_TELAS item in model.TBL_PRE_CONSUMO_TELAS)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.PreCtCodigoN != 0)
                                {
                                    telas = new TBL_PRE_CONSUMO_TELAS
                                    {
                                        PreCtCodigoN = item.PreCtCodigoN
                                    };
                                    db.Entry(telas).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.PreCtCodigoN != 0)
                            {
                                telas = new TBL_PRE_CONSUMO_TELAS
                                {
                                    PreCtCodigoN = item.PreCtCodigoN,
                                    PreHcCodigoN = item.PreHcCodigoN,
                                    PreCtNombreS = item.PreCtNombreS,
                                    PreCtColorS = item.PreCtColorS,
                                    PreCtCtsxMtD = item.PreCtCtsxMtD,
                                    PreCtConF = item.PreCtConF,
                                    PreCtTotalD = item.PreCtTotalD,
                                    PreCtFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_PRE_CONSUMO_TELAS.Attach(telas);
                                db.Entry(telas).Property(x => x.PreCtNombreS).IsModified = true;
                                db.Entry(telas).Property(x => x.PreCtColorS).IsModified = true;
                                db.Entry(telas).Property(x => x.PreCtCtsxMtD).IsModified = true;
                                db.Entry(telas).Property(x => x.PreCtConF).IsModified = true;
                                db.Entry(telas).Property(x => x.PreCtTotalD).IsModified = true;
                                db.Entry(telas).Property(x => x.PreCtFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                telas = new TBL_PRE_CONSUMO_TELAS
                                {
                                    PreHcCodigoN = CodigoHoja,
                                    PreCtNombreS = item.PreCtNombreS,
                                    PreCtColorS = item.PreCtColorS,
                                    PreCtCtsxMtD = item.PreCtCtsxMtD,
                                    PreCtConF = item.PreCtConF,
                                    PreCtTotalD = item.PreCtTotalD,
                                    PreCtFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(telas).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                        hoja = new TBL_PRE_HOJA_COSTO_PN
                        {
                            PreHcCodigoN = CodigoHoja,
                            PreHcTotalConTelasD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalConTelasD,
                            PreHcTotalTelasD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalTelasD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.PreHcTotalConTelasD).IsModified = true;
                        db.Entry(hoja).Property(x => x.PreHcTotalTelasD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Consumo Telas";
                }
            }

            //FIN

            //GUARDAR PROCESOS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_PRE_PROCESO procesos = new TBL_PRE_PROCESO();
                    if (model.TBL_PRE_PROCESO.Count > 0)
                    {
                        foreach (TBL_PRE_PROCESO item in model.TBL_PRE_PROCESO)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.PrePrCodigoN != 0)
                                {
                                    procesos = new TBL_PRE_PROCESO
                                    {
                                        PrePrCodigoN = item.PrePrCodigoN
                                    };
                                    db.Entry(procesos).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.PrePrCodigoN != 0)
                            {
                                procesos = new TBL_PRE_PROCESO
                                {
                                    PrePrCodigoN = item.PrePrCodigoN,
                                    PreHcCodigoN = item.PreHcCodigoN,
                                    PrePrDetalleS = item.PrePrDetalleS,
                                    PrePrCostoM = item.PrePrCostoM,
                                    PrePrFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_PRE_PROCESO.Attach(procesos);
                                db.Entry(procesos).Property(x => x.PrePrDetalleS).IsModified = true;
                                db.Entry(procesos).Property(x => x.PrePrCostoM).IsModified = true;
                                db.Entry(procesos).Property(x => x.PrePrFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                procesos = new TBL_PRE_PROCESO
                                {
                                    PreHcCodigoN = item.PreHcCodigoN,
                                    PrePrDetalleS = item.PrePrDetalleS,
                                    PrePrCostoM = item.PrePrCostoM,
                                    PrePrFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(procesos).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                        hoja = new TBL_PRE_HOJA_COSTO_PN
                        {
                            PreHcCodigoN = CodigoHoja,
                            PreHcTotalProcesosD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalProcesosD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.PreHcTotalProcesosD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Procesos";
                }
            }

            //FIN

            //GUARDAR CONSUMO DE INSUMOS Y ACCESORIOS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_PRE_INS_ACC insumos = new TBL_PRE_INS_ACC();
                    if (model.TBL_PRE_INS_ACC.Count > 0)
                    {
                        foreach (TBL_PRE_INS_ACC item in model.TBL_PRE_INS_ACC)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.PreIaCodigoN != 0)
                                {
                                    insumos = new TBL_PRE_INS_ACC
                                    {
                                        PreIaCodigoN = item.PreIaCodigoN
                                    };
                                    db.Entry(insumos).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.PreIaCodigoN != 0)
                            {
                                insumos = new TBL_PRE_INS_ACC
                                {
                                    PreIaCodigoN = item.PreIaCodigoN,
                                    PreHcCodigoN = item.PreHcCodigoN,
                                    PreIaNombreS = item.PreIaNombreS,
                                    PreIaColorS = item.PreIaColorS,
                                    PreIaCtsxMtD = item.PreIaCtsxMtD,
                                    PreIaConF = item.PreIaConF,
                                    PreIaTotalD = item.PreIaTotalD,
                                    PreIaFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_PRE_INS_ACC.Attach(insumos);
                                db.Entry(insumos).Property(x => x.PreIaNombreS).IsModified = true;
                                db.Entry(insumos).Property(x => x.PreIaColorS).IsModified = true;
                                db.Entry(insumos).Property(x => x.PreIaCtsxMtD).IsModified = true;
                                db.Entry(insumos).Property(x => x.PreIaConF).IsModified = true;
                                db.Entry(insumos).Property(x => x.PreIaTotalD).IsModified = true;
                                db.Entry(insumos).Property(x => x.PreIaFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                insumos = new TBL_PRE_INS_ACC
                                {
                                    PreHcCodigoN = CodigoHoja,
                                    PreIaNombreS = item.PreIaNombreS,
                                    PreIaColorS = item.PreIaColorS,
                                    PreIaCtsxMtD = item.PreIaCtsxMtD,
                                    PreIaConF = item.PreIaConF,
                                    PreIaTotalD = item.PreIaTotalD,
                                    PreIaFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(insumos).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                        hoja = new TBL_PRE_HOJA_COSTO_PN
                        {
                            PreHcCodigoN = CodigoHoja,
                            PreHcTotalInsumoD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalInsumoD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.PreHcTotalInsumoD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Insumos y Accesorios";
                }
            }

            //FIN

            //GUARDAR CONSUMO DE MARQUILLAS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_PRE_ETIQ_MAR_EMP marquillas = new TBL_PRE_ETIQ_MAR_EMP();
                    if (model.TBL_PRE_ETIQ_MAR_EMP.Count > 0)
                    {
                        foreach (TBL_PRE_ETIQ_MAR_EMP item in model.TBL_PRE_ETIQ_MAR_EMP)
                        {
                            if (item.Borrado == true)
                            {
                                if (item.PreEmeCodigoN != 0)
                                {
                                    marquillas = new TBL_PRE_ETIQ_MAR_EMP
                                    {
                                        PreEmeCodigoN = item.PreEmeCodigoN
                                    };
                                    db.Entry(marquillas).State = EntityState.Deleted;
                                    db.SaveChanges();
                                }
                            }
                            else if (item.PreEmeCodigoN != 0)
                            {
                                marquillas = new TBL_PRE_ETIQ_MAR_EMP
                                {
                                    PreEmeCodigoN = item.PreEmeCodigoN,
                                    PreHcCodigoN = item.PreHcCodigoN,
                                    PreEmeNombreS = item.PreEmeNombreS,
                                    PreEmeCtsxMtD = item.PreEmeCtsxMtD,
                                    PreEmeConF = item.PreEmeConF,
                                    PreEmeTotalD = item.PreEmeTotalD,
                                    PreEmeFecActD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.TBL_PRE_ETIQ_MAR_EMP.Attach(marquillas);
                                db.Entry(marquillas).Property(x => x.PreEmeNombreS).IsModified = true;
                                db.Entry(marquillas).Property(x => x.PreEmeCtsxMtD).IsModified = true;
                                db.Entry(marquillas).Property(x => x.PreEmeConF).IsModified = true;
                                db.Entry(marquillas).Property(x => x.PreEmeTotalD).IsModified = true;
                                db.Entry(marquillas).Property(x => x.PreEmeFecActD).IsModified = true;
                                db.SaveChanges();
                            }
                            else
                            {
                                marquillas = new TBL_PRE_ETIQ_MAR_EMP
                                {
                                    PreHcCodigoN = CodigoHoja,
                                    PreEmeNombreS = item.PreEmeNombreS,
                                    PreEmeCtsxMtD = item.PreEmeCtsxMtD,
                                    PreEmeConF = item.PreEmeConF,
                                    PreEmeTotalD = item.PreEmeTotalD,
                                    PreEmeFecCreD = DateTime.Now
                                };
                                db.Configuration.ValidateOnSaveEnabled = false;
                                db.Entry(marquillas).State = EntityState.Added;
                                db.SaveChanges();
                            }
                        }
                        //GUARDO TOTALES
                        TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                        hoja = new TBL_PRE_HOJA_COSTO_PN
                        {
                            PreHcCodigoN = CodigoHoja,
                            PreHcTotalMarquillaD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalMarquillaD
                        };
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                        db.Entry(hoja).Property(x => x.PreHcTotalMarquillaD).IsModified = true;
                        db.SaveChanges();
                        //FIN
                    }
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Marquillas";
                }
            }

            //FIN

            //GUARDAR MODF Y CIF

            TBL_PRE_MOD_CIF mod = new TBL_PRE_MOD_CIF();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    mod = model.TBL_PRE_MOD_CIF;
                    mod.PreMcFecActD = DateTime.Now;
                    mod.PreHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_MOD_CIF.Attach(mod);
                    db.Entry(mod).Property(x => x.PreMcCostoIndirectosD).IsModified = true;
                    db.Entry(mod).Property(x => x.PreMcCostoManoObraD).IsModified = true;
                    db.Entry(mod).Property(x => x.PreMcFecActD).IsModified = true;
                    db.SaveChanges();
                    //GUARDO TOTALES
                    TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                    hoja = new TBL_PRE_HOJA_COSTO_PN
                    {
                        PreHcCodigoN = CodigoHoja,
                        PreHcTotalCIFMODD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalCIFMODD
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.PreHcTotalCIFMODD).IsModified = true;
                    db.SaveChanges();
                    //FIN
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: MOD y CIF";
                }
            }

            //FIN

            //GUARDAR RESUMEN GENERAL COSTO PRODUCCION

            TBL_PRE_RES_GEN_COS_PRD costo_prd = new TBL_PRE_RES_GEN_COS_PRD();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    costo_prd = model.TBL_PRE_RES_GEN_COS_PRD;
                    costo_prd.PreRpFecActD = DateTime.Now;
                    costo_prd.PreHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_RES_GEN_COS_PRD.Attach(costo_prd);
                    db.Entry(costo_prd).Property(x => x.PreRpCostoMaterialesD).IsModified = true;
                    db.Entry(costo_prd).Property(x => x.PreRpCostoConversionD).IsModified = true;
                    db.Entry(costo_prd).Property(x => x.PreRpFecActD).IsModified = true;
                    db.SaveChanges();
                    //GUARDO TOTALES
                    TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                    hoja = new TBL_PRE_HOJA_COSTO_PN
                    {
                        PreHcCodigoN = CodigoHoja,
                        PreHcTotalCosPrdD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalCosPrdD
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.PreHcTotalCosPrdD).IsModified = true;
                    db.SaveChanges();
                    //FIN
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Costo Producción";
                }
            }

            //FIN

            //GUARDAR GASTO Y COSTO POR DESTINO DISTRIBUCCION

            TBL_PRE_RES_GAS_COS_DIS costo_dis = new TBL_PRE_RES_GAS_COS_DIS();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    costo_dis = model.TBL_PRE_RES_GAS_COS_DIS;
                    costo_dis.PreRdFecActD = DateTime.Now;
                    costo_dis.PreHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_RES_GAS_COS_DIS.Attach(costo_dis);
                    db.Entry(costo_dis).Property(x => x.PreRdAdminEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.PreRdFinanEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.PreRdMercadeoEstD).IsModified = true;
                    db.Entry(costo_dis).Property(x => x.PreRdVentasxCanalEstD).IsModified = true;
                    db.SaveChanges();
                    //GUARDO TOTALES
                    TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                    hoja = new TBL_PRE_HOJA_COSTO_PN
                    {
                        PreHcCodigoN = CodigoHoja,
                        PreHcTotalGastosEstD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalGastosEstD,
                        PreHcTotalxCanalEstD = model.TBL_PRE_HOJA_COSTO_PN.PreHcTotalxCanalEstD,
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.PreHcTotalGastosEstD).IsModified = true;
                    db.Entry(hoja).Property(x => x.PreHcTotalxCanalEstD).IsModified = true;
                    db.SaveChanges();
                    //FIN
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Gastos por Destino Distribucion";
                }
            }

            //FIN

            //GUARDAR ANALISIS PRECIOS

            TBL_PRE_ANALISIS_PREC analisis = new TBL_PRE_ANALISIS_PREC();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    analisis = model.TBL_PRE_ANALISIS_PREC;
                    analisis.PreApFecActD = DateTime.Now;
                    analisis.PreHcCodigoN = CodigoHoja;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_ANALISIS_PREC.Attach(analisis);
                    db.Entry(analisis).Property(x => x.PreApPrecMaxIvaEstD).IsModified = true;
                    db.Entry(analisis).Property(x => x.PreApMargenMaxBrutoEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.PreApMargenMaxOpeEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.PreApPrecMinIvaEstD).IsModified = true;
                    db.Entry(analisis).Property(x => x.PreApMargenMinBrutoEstF).IsModified = true;
                    db.Entry(analisis).Property(x => x.PreApMargenMinOpeEstF).IsModified = true;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Analisis Precios";
                }
            }

            //FIN

            //GUARDAR PIRAMIDE PRECIOS

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    TBL_PRE_HOJA_COSTO_PN hoja = new TBL_PRE_HOJA_COSTO_PN();
                    hoja = new TBL_PRE_HOJA_COSTO_PN
                    {
                        PreHcCodigoN = CodigoHoja,
                        PreHcEnterPriceD = model.TBL_PRE_HOJA_COSTO_PN.PreHcEnterPriceD,
                        PreHcMediumPriceD = model.TBL_PRE_HOJA_COSTO_PN.PreHcMediumPriceD,
                        PreHcPremiumPriceD = model.TBL_PRE_HOJA_COSTO_PN.PreHcPremiumPriceD,
                    };
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_PRE_HOJA_COSTO_PN.Attach(hoja);
                    db.Entry(hoja).Property(x => x.PreHcEnterPriceD).IsModified = true;
                    db.Entry(hoja).Property(x => x.PreHcMediumPriceD).IsModified = true;
                    db.Entry(hoja).Property(x => x.PreHcPremiumPriceD).IsModified = true;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return "Se presento un error en el rubro: Piramide Precios";
                }
            }

            //FIN

            return "Proceso Terminado Correctamente";
        }

        public bool ValidaImpresion(string Referencia, ref string Mensaje)
        {
            try
            {
                bool telas, insumos, marquillas, estado = false;
                using (DataBaseContext db = new DataBaseContext())
                {
                    telas = db.TBL_CONSUMO_TELAS
                        .Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                        .Any(j => j.y.HcReferenciaS == Referencia && (j.x.CtCtsxMtD <= 0 || j.x.CtConF <= 0));

                    insumos = db.TBL_INS_ACC
                        .Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                        .Any(j => j.y.HcReferenciaS == Referencia && (j.x.IaCtsxMtD <= 0 || j.x.IaConF <= 0));

                    marquillas = db.TBL_ETIQ_MAR_EMP
                        .Join(db.TBL_HOJA_COSTO_PN, x => x.HcCodigoN, y => y.HcCodigoN, (x, y) => new { x, y })
                        .Any(j => j.y.HcReferenciaS == Referencia && (j.x.EmeCtsxMtD <= 0 || j.x.EmeConF <= 0));

                    if (telas)
                    {
                        Mensaje = Mensaje + " - Pendiente Telas";
                        estado = true;
                    }
                    if (insumos)
                    {
                        Mensaje = Mensaje + " - Pendiente Insumos";
                        estado = true;
                    }
                    if (marquillas)
                    {
                        Mensaje = Mensaje + " - Pendiente Marquillas";
                        estado = true;
                    }
                    return estado;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}