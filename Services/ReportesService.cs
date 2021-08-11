using AppWebHojaCosto.Context;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AppWebHojaCosto.Services
{
    public class ReportesService
    {
        public class Componentes
        {
            public string Referencia { get; set; }
            public string Estado { get; set; }
            public string Pendiente { get; set; }
            public string CodigoPendiente { get; set; }
            public string DescripcionPendiente { get; set; }
            public string Coleccion { get; set; }
        }

        public class AlmacenamientoNoProducido
        {
            public string Referencia { get; set; }
            public string Linea { get; set; }
            public string Sublinea { get; set; }
            public string Coleccion { get; set; }
            public string Proveedor { get; set; }
            public string Origen { get; set; }
            public string Marca { get; set; }
            public string CantidadPedida { get; set; }
            public string TipoTransporte { get; set; }
            public string PrecioCompra { get; set; }
            public string Incoterm { get; set; }
            public string CostoCompra { get; set; }
            public string PinSeguridad { get; set; }
            public string GastosOrigen { get; set; }
            public string Flete { get; set; }
            public string Arancel { get; set; }
            public string SeguroInter { get; set; }
            public string GastosDestino { get; set; }
            public string TotalCostoBodega { get; set; }
            public string AdecuacionProducto { get; set; }
            public string Sensorizacion { get; set; }
            public string ArregloProducto { get; set; }
            public string ReconstruccionProducto { get; set; }
            public string GastosAdmon { get; set; }
            public string TotalCostosGastos { get; set; }
        }

        public DataTable CargarComponentesGenericos(string FechaInicio, string FechaFin)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    DataTable dt = new DataTable();

                    var fecIni = new SqlParameter("@FechaInicio", FechaInicio);
                    var fecFin = new SqlParameter("@FechaFin", FechaFin);
                    var consulta = db.Database.SqlQuery<Componentes>("spConsultarPendientes @FechaInicio, @FechaFin", fecIni, fecFin).ToList();

                    using (ObjectReader reader = ObjectReader.Create(consulta))
                    {
                        dt.Load(reader);
                    }
                    return dt;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable ConsultaAlmaNoProducido(string FechaInicio, string FechaFin)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    DataTable dt = new DataTable();

                    var fecIni = new SqlParameter("@FechaInicio", FechaInicio);
                    var fecFin = new SqlParameter("@FechaFin", FechaFin);
                    var consulta = db.Database.SqlQuery<AlmacenamientoNoProducido>("spConsultarComponentesNoProducido @FechaInicio, @FechaFin", fecIni, fecFin).ToList();

                    using (ObjectReader reader = ObjectReader.Create(consulta))
                    {
                        dt.Load(reader);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}