using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class HojaCostoSimPNPService
    {
        public TBL_SIM_HOJA_COSTO_PNP _HOJA_COSTO_PNP(string Referencia)
        {
            TBL_SIM_HOJA_COSTO_PNP model = new TBL_SIM_HOJA_COSTO_PNP();
            using (var db = new DataBaseContext())
            {
                model = db.TBL_SIM_HOJA_COSTO_PNP.Where(x => x.SimPnpReferenciaS == Referencia)
                    .FirstOrDefault();
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

        public string Guardar(TBL_SIM_HOJA_COSTO_PNP model)
        {
            string strMensaje = String.Empty;
            using (var db = new DataBaseContext())
            {
                try
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TBL_SIM_HOJA_COSTO_PNP.Attach(model);
                    db.Entry(model).Property(x => x.SimPnpCostoCompraPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpCostoCompraUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpCostoCompraPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPinSeguridadPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPinSeguridadUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPinSeguridadPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosOrigenPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosOrigenUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosOrigenPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosFletePesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosFleteUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosFletePorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosArancelPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosArancelUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosArancelPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosSeguroPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosSeguroUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosSeguroPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosDestinoPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosDestinoUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosDestinoPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosOtrosPesosM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosOtrosUsdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosOtrosPorcF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpTotalCostoBodegaM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpTotalCostoBodegaF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpAdecuacionPrdM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpAdecuacionPrdF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpSensorizacionM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpSensorizacionF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpArregloM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpArregloF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpReconstruccionM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpReconstruccionF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosAdmonRealF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosAdmonRealM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosAdmonEstimadoF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpGastosAdmonEstimadoM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpTotalCostosGastosRealM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpTotalCostosGastosRealF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpTotalCostosGastosEstimadoM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpTotalCostosGastosEstimadoF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpEnterPriceM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMediumPriceM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPremiumPriceM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPrecioMaxRealM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMaxBrutoRealF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMaxOpeRealF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPrecioMinRealM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMinBrutoRealF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMinOpeRealF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPrecioMinEstimadoM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMinBrutoEstimadoF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMinOpeEstimadoF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpPrecioMaxEstimadoM).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMaxBrutoEstimadoF).IsModified = true;
                    db.Entry(model).Property(x => x.SimPnpMargenMaxOpeEstimadoF).IsModified = true;
                    db.SaveChanges();
                    return "Proceso completado con exito";
                }
                catch (Exception ex)
                {
                    return "Se presento un error en el proceso.";
                }
            }
        }

        public List<LISTA_PARAMETROS> ListParametrosPNP(string Marca, string Coleccion, string Linea, string Sublinea)
        {
            List<LISTA_PARAMETROS> lstParam = new List<LISTA_PARAMETROS>();
            DataTable dt = new DataTable();
            using (var db = new DataBaseContext())
            {
                var data = db.TBL_PARAM_PNP.Where(x => x.PnMarcaS == Marca && x.PnColeccionS == Coleccion && x.PnLineaS == Linea && x.PnSubLineaS == Sublinea).ToList();
                using (var reader = ObjectReader.Create(data))
                {
                    dt.Load(reader);
                }
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    LISTA_PARAMETROS obj = new LISTA_PARAMETROS
                    {
                        NombreCampo = "Sim" + dt.Columns[i].ColumnName.ToString(),
                        ValorCampo = dt.Rows[0][i].ToString()
                    };
                    lstParam.Add(obj);
                }
            }
            return lstParam;
        }
    }
}