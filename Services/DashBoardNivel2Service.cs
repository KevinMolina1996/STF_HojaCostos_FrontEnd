using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Services
{
    public class DashBoardNivel2Service
    {
        //Producido
        public DASHBOARDLVL2 ConsultarProducido(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            DASHBOARDLVL2 model = new DASHBOARDLVL2();
            List<DASH_PRODUCIDO> lstProducido = new List<DASH_PRODUCIDO>();
            using (var db = new DataBaseContext())
            {
                var consulta = (from hoja in db.TBL_HOJA_COSTO_PN
                                from telas in db.TBL_CONSUMO_TELAS.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                from insumos in db.TBL_INS_ACC.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                from marquillas in db.TBL_ETIQ_MAR_EMP.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                from mod in db.TBL_MOD_CIF.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                from procesos in db.TBL_PROCESO.Where(m => m.HcCodigoN == hoja.HcCodigoN).DefaultIfEmpty()
                                where hoja.HcMarcaS == Marca && hoja.HcColeccionS == Coleccion && hoja.HcLineaS == Linea && hoja.HcSubLineaS == Sublinea
                                orderby hoja.HcColeccionS
                                select new
                                {
                                    hoja.HcReferenciaS,
                                    hoja.HcDescripcionS,
                                    hoja.HcLineaS,
                                    ConsumoTelas = (telas.CtConF == 0 ? "PENDIENTE" : telas.CtConF.ToString()),
                                    CostoTelas = (telas.CtCtsxMtD == 0 ? "PENDIENTE" : telas.CtCtsxMtD.ToString()),
                                    ConsumoInsumos = (insumos.IaConF == 0 ? "PENDIENTE" : insumos.IaConF.ToString()),
                                    CostoInsumos = (insumos.IaCtsxMtD == 0 ? "PENDIENTE" : insumos.IaCtsxMtD.ToString()),
                                    ConsumoMarquillas = (marquillas.EmeConF == 0 ? "PENDIENTE" : marquillas.EmeConF.ToString()),
                                    CostoMarquillas = (marquillas.EmeCtsxMtD == 0 ? "PENDIENTE" : marquillas.EmeCtsxMtD.ToString()),
                                    Despiece = (hoja.HcDespieceF == 0 ? "PENDIENTE" : hoja.HcDespieceF.ToString()),
                                    Mod = (mod.McCostoManoObraD == 6000 ? "PENDIENTE" : mod.McCostoManoObraD.ToString()),
                                    Cif = (mod.McCostoIndirectosD == 60000 ? "PENDIENTE" : mod.McCostoIndirectosD.ToString()),
                                    Maquila = (hoja.HcMaquilaF == 0 ? "PENDIENTE" : hoja.HcMaquilaF.ToString()),
                                    DescProceso = procesos.PrDetalleS,
                                    EstadoProceso = (procesos.PrCostoM == 0 ? "PENDIENTE" : procesos.PrCostoM.ToString()),
                                    EstadoCierre = hoja.HcEstadoAproS,
                                    EstadoDatos = telas.CtConF == 0 ? "PENDIENTE" : telas.CtCtsxMtD == 0 ? "PENDIENTE" : insumos.IaConF == 0 ? "PENDIENTE" : insumos.IaCtsxMtD == 0 ? "PENDIENTE" : mod.McCostoManoObraD == 6000 ? "PENDIENTE" :
                                                    mod.McCostoIndirectosD == 60000 ? "PENDIENTE" : procesos.PrCostoM == 0 ? "PENDIENTE" : hoja.HcDespieceF == 0 ? "PENDIENTE" : hoja.HcMaquilaF == 0 ? "PENDIENTE" : "OK" //Valida todos los apartados menos marquillas
                                }).ToList();

                foreach (var item in consulta)
                {
                    DASH_PRODUCIDO model2 = new DASH_PRODUCIDO
                    {
                        Referencia = item.HcReferenciaS,
                        Descripcion = item.HcDescripcionS,
                        Linea = item.HcLineaS,
                        TelasConsumo = item.ConsumoTelas,
                        TelasCosto = item.CostoTelas,
                        InsumosConsumo = item.ConsumoInsumos,
                        InsumosCosto = item.CostoInsumos,
                        MarquillasConsumo = item.CostoMarquillas,
                        MarquillasCosto = item.CostoMarquillas,
                        Despiece = item.Despiece,
                        Mod = item.Mod,
                        Cif = item.Cif,
                        Maquila = item.Maquila,
                        ProcesosDescripcion = item.DescProceso,
                        ProcesosEstado = item.EstadoProceso,
                        EstadoCierre = item.EstadoCierre,
                        EstadoDatos = item.EstadoDatos
                    };
                    lstProducido.Add(model2);
                }
                model._DASH_PRODUCIDO = lstProducido;
            }
            return model;
        }

        //Precosteo
        public DASHBOARDLVL2 ConsultarPrecosteo(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            DASHBOARDLVL2 model = new DASHBOARDLVL2();
            List<DASH_PRECOSTEO> lstProducido = new List<DASH_PRECOSTEO>();
            using (var db = new DataBaseContext())
            {
                var consulta = (from hoja in db.TBL_PRE_HOJA_COSTO_PN
                                from telas in db.TBL_PRE_CONSUMO_TELAS.Where(m => m.PreHcCodigoN == hoja.PreHcCodigoN).DefaultIfEmpty()
                                from insumos in db.TBL_PRE_INS_ACC.Where(m => m.PreHcCodigoN == hoja.PreHcCodigoN).DefaultIfEmpty()
                                from marquillas in db.TBL_PRE_ETIQ_MAR_EMP.Where(m => m.PreHcCodigoN == hoja.PreHcCodigoN).DefaultIfEmpty()
                                from mod in db.TBL_PRE_MOD_CIF.Where(m => m.PreHcCodigoN == hoja.PreHcCodigoN).DefaultIfEmpty()
                                from procesos in db.TBL_PRE_PROCESO.Where(m => m.PreHcCodigoN == hoja.PreHcCodigoN).DefaultIfEmpty()
                                where hoja.PreHcMarcaS == Marca && hoja.PreHcColeccionS == Coleccion && hoja.PreHcLineaS == Linea && hoja.PreHcSubLineaS == Sublinea
                                select new
                                {
                                    hoja.PreHcReferenciaS,
                                    hoja.PreHcDescripcionS,
                                    hoja.PreHcLineaS,
                                    ConsumoTelas = (telas.PreCtConF == 0 ? "PENDIENTE" : telas.PreCtConF.ToString()),
                                    CostoTelas = (telas.PreCtCtsxMtD == 0 ? "PENDIENTE" : telas.PreCtCtsxMtD.ToString()),
                                    ConsumoInsumos = (insumos.PreIaConF == 0 ? "PENDIENTE" : insumos.PreIaConF.ToString()),
                                    CostoInsumos = (insumos.PreIaCtsxMtD == 0 ? "PENDIENTE" : insumos.PreIaCtsxMtD.ToString()),
                                    ConsumoMarquillas = (marquillas.PreEmeConF == 0 ? "PENDIENTE" : marquillas.PreEmeConF.ToString()),
                                    CostoMarquillas = (marquillas.PreEmeCtsxMtD == 0 ? "PENDIENTE" : marquillas.PreEmeCtsxMtD.ToString()),
                                    Despiece = (hoja.PreHcDespieceF == 0 ? "PENDIENTE" : hoja.PreHcDespieceF.ToString()),
                                    Mod = (mod.PreMcCostoManoObraD == 6000 ? "PENDIENTE" : mod.PreMcCostoManoObraD.ToString()),
                                    Cif = (mod.PreMcCostoIndirectosD == 60000 ? "PENDIENTE" : mod.PreMcCostoIndirectosD.ToString()),
                                    Maquila = (hoja.PreHcMaquilaF == 0 ? "PENDIENTE" : hoja.PreHcMaquilaF.ToString()),
                                    DescProceso = procesos.PrePrDetalleS,
                                    EstadoProceso = (procesos.PrePrCostoM == 0 ? "PENDIENTE" : procesos.PrePrCostoM.ToString()),
                                    EstadoCierre = hoja.PreHcEstadoAproS,
                                    EstadoDatos = telas.PreCtConF == 0 ? "PENDIENTE" : telas.PreCtCtsxMtD == 0 ? "PENDIENTE" : insumos.PreIaConF == 0 ? "PENDIENTE" : insumos.PreIaCtsxMtD == 0 ? "PENDIENTE" : mod.PreMcCostoManoObraD == 6000 ? "PENDIENTE" :
                                                    mod.PreMcCostoIndirectosD == 60000 ? "PENDIENTE" : procesos.PrePrCostoM == 0 ? "PENDIENTE" : hoja.PreHcDespieceF == 0 ? "PENDIENTE" : hoja.PreHcMaquilaF == 0 ? "PENDIENTE" : "OK" //Valida todos los apartados menos marquillas
                                }).ToList();

                foreach (var item in consulta)
                {
                    DASH_PRECOSTEO model2 = new DASH_PRECOSTEO
                    {
                        Referencia = item.PreHcReferenciaS,
                        Descripcion = item.PreHcDescripcionS,
                        Linea = item.PreHcLineaS,
                        TelasConsumo = item.ConsumoTelas,
                        TelasCosto = item.CostoTelas,
                        InsumosConsumo = item.ConsumoInsumos,
                        InsumosCosto = item.CostoInsumos,
                        MarquillasConsumo = item.CostoMarquillas,
                        MarquillasCosto = item.CostoMarquillas,
                        Despiece = item.Despiece,
                        Mod = item.Mod,
                        Cif = item.Cif,
                        Maquila = item.Maquila,
                        ProcesosDescripcion = item.DescProceso,
                        ProcesosEstado = item.EstadoProceso,
                        EstadoCierre = item.EstadoCierre,
                        EstadoDatos = item.EstadoDatos
                    };
                    lstProducido.Add(model2);
                }
                model._DASH_PRECOSTEO = lstProducido;
            }
            return model;
        }

        //No producido
        public DASHBOARDLVL2 ConsultarNoProducido(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            DASHBOARDLVL2 model = new DASHBOARDLVL2();
            List<DASH_NO_PRODUCIDO> lstProducido = new List<DASH_NO_PRODUCIDO>();
            using (var db = new DataBaseContext())
            {
                var consulta = (from hoja in db.TBL_HOJA_COSTO_PNP
                                where hoja.PnpMarcaS == Marca && hoja.PnpColeccionS == Coleccion && hoja.PnpLineaS == Linea && hoja.PnpSubLineaS == Sublinea
                                select new
                                {
                                    Referencia = hoja.PnpReferenciaS,
                                    Descripcion = hoja.PnpDescripS,
                                    Linea = hoja.PnpLineaS,
                                    FechaOc = hoja.PnpFechaAprobacionD.ToString(),
                                    OrdenCompra = hoja.PnpOrdenCompraS,
                                    EstadoOc = hoja.PnpEstadoOrdenCompraS, //No esta en la hoja
                                    CostoCompra = (hoja.PnpCostoCompraUSDD == 0 ? "PENDIENTE" : hoja.PnpCostoCompraUSDD.ToString()),
                                    Moneda = hoja.PnpMonedaS,
                                    Trm = hoja.PnpTrmM,
                                    CostoCompraCop = (hoja.PnpPrecioD == 0 ? "PENDIENTE" : hoja.PnpPrecioD.ToString()),
                                    Cantidad = (hoja.PnpCntPedN == 0 ? "PENDIENTE" : hoja.PnpCntPedN.ToString()),
                                    Proveedor = hoja.PnpProveedorS,
                                    TerminoNeg = hoja.PnpTermNegocS,
                                    PaisOrigen = hoja.PnpPaisOrigenS,
                                    Estado = hoja.PnpEstadoS
                                }).ToList();

                foreach (var item in consulta)
                {
                    DASH_NO_PRODUCIDO model2 = new DASH_NO_PRODUCIDO
                    {
                        Referencia = item.Referencia,
                        Descripcion = item.Descripcion,
                        Linea = item.Linea,
                        FechaOc = item.FechaOc,
                        OrdenCompra = item.OrdenCompra,
                        EstadoOc = item.EstadoOc,
                        CostoCompra = item.CostoCompra.ToString(),
                        Moneda  = item.Moneda,
                        Trm = item.Trm.ToString(),
                        CostoCompraCop = item.CostoCompraCop,
                        Cantidad = item.Cantidad.ToString(),
                        Proveedor = item.Proveedor,
                        TerminoNegociacion = item.TerminoNeg,
                        PaisOrigen = item.PaisOrigen,
                        Estado = item.Estado
                    };
                    lstProducido.Add(model2);
                }
                model._DASH_NO_PRODUCIDO = lstProducido;
            }
            return model;
        }

        //Producido
        public List<string> obtenerMarcas()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PN
                    .Select(x => x.HcMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColecciones(string marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PN.Where(x => x.HcMarcaS == marca)
                    .Select(x => x.HcColeccionS).Distinct().ToList();
            }
        }

        public List<string> obtenerLineas(string marca, string coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PN.Where(x => x.HcColeccionS == coleccion && x.HcMarcaS == marca)
                    .Select(x => x.HcLineaS).Distinct().ToList();
            }
        }

        public List<string> obtenerSublineas(string marca, string coleccion, string linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PN.Where(x => x.HcColeccionS == coleccion && x.HcMarcaS == marca && x.HcLineaS == linea)
                    .Select(x => x.HcSubLineaS).Distinct().ToList();
            }
        }

        //Precosteo
        public List<string> obtenerMarcasPrecosteo()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PRE_HOJA_COSTO_PN
                    .Select(x => x.PreHcMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColeccionesPrecosteo(string marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcMarcaS == marca)
                    .Select(x => x.PreHcColeccionS).Distinct().ToList();
            }
        }

        public List<string> obtenerLineasPrecosteo(string marca, string coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcColeccionS == coleccion && x.PreHcMarcaS == marca)
                    .Select(x => x.PreHcLineaS).Distinct().ToList();
            }
        }

        public List<string> obtenerSublineasPrecosteo(string marca, string coleccion, string linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_PRE_HOJA_COSTO_PN.Where(x => x.PreHcColeccionS == coleccion && x.PreHcMarcaS == marca && x.PreHcLineaS == linea)
                    .Select(x => x.PreHcSubLineaS).Distinct().ToList();
            }
        }

        //No Producido
        public List<string> obtenerMarcasNoProducido()
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PNP
                    .Select(x => x.PnpMarcaS).Distinct().ToList();
            }
        }

        public List<string> obtenerColeccionesNoProducido(string marca)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpMarcaS == marca)
                    .Select(x => x.PnpColeccionS).Distinct().ToList();
            }
        }

        public List<string> obtenerLineasNoProducido(string marca, string coleccion)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpColeccionS == coleccion && x.PnpMarcaS == marca)
                    .Select(x => x.PnpLineaS).Distinct().ToList();
            }
        }

        public List<string> obtenerSublineasNoProducido(string marca, string coleccion, string linea)
        {
            using (var db = new DataBaseContext())
            {
                return db.TBL_HOJA_COSTO_PNP.Where(x => x.PnpColeccionS == coleccion && x.PnpMarcaS == marca && x.PnpLineaS == linea)
                    .Select(x => x.PnpSubLineaS).Distinct().ToList();
            }
        }
    }
}