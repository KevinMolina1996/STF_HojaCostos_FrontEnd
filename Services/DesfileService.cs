using AppWebHojaCosto.Context;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class DesfileService
    {
        public void ConsultaReferencia(string Referencia, ref string Descripcion, ref string PrecMinimo, ref string PrecMaximo, ref string Costo, ref string MargenBruto, ref string Tipo)
        {
            using (var db = new DataBaseContext())
            {
                var obj = (from hoja in db.TBL_HOJA_COSTO_PN
                           join analisis in db.TBL_ANALISIS_PREC on hoja.HcCodigoN equals analisis.HcCodigoN into precio
                           from prc in precio.DefaultIfEmpty() 
                           where hoja.HcReferenciaS == Referencia
                           select new
                           {
                               Descripcion = hoja.HcDescripcionS.ToString(),
                               PrecMinimo = prc.ApPrecMinIvaEstD.ToString(),
                               PrecMaximo = prc.ApPrecMaxIvaEstD.ToString(),
                               Costo = hoja.HcTotalCosPrdD.ToString(),
                               MargenBruto = prc.ApMargenMaxBrutoEstF.ToString(),
                               Tipo = "PN"
                           }).Union
                          (from hoja in db.TBL_HOJA_COSTO_PNP
                           where hoja.PnpReferenciaS == Referencia
                           select new
                           {
                               Descripcion = hoja.PnpDescripS.ToString(),
                               PrecMinimo = hoja.PnpPrecioMinEstimadoM.ToString(),
                               PrecMaximo = hoja.PnpPrecioMaxEstimadoM.ToString(),
                               Costo = hoja.PnpCostoCompraUSDD.ToString(),
                               MargenBruto = hoja.PnpMargenMaxBrutoEstimadoF.ToString(),
                               Tipo = "PNP"
                           });
                foreach(var item in obj)
                {
                    Descripcion = item.Descripcion;
                    PrecMinimo = item.PrecMinimo.ToString();
                    PrecMaximo = item.PrecMaximo.ToString();
                    Costo = item.Costo.ToString();
                    MargenBruto = item.MargenBruto.ToString();
                    Tipo = item.Tipo.ToString();
                }
            }
        }
    }
}