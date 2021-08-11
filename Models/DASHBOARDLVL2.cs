using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebHojaCosto.Models
{
    public class DASHBOARDLVL2
    {
        public string Marca { get; set; }
        public string Coleccion { get; set; }
        public string Linea { get; set; }
        public string Sublinea { get; set; }
        public List<SelectListItem> Colecciones { get; set; }
        public List<SelectListItem> Marcas { get; set; }
        public List<SelectListItem> Lineas { get; set; }
        public List<SelectListItem> Sublineas { get; set; }
        public List<DASH_PRODUCIDO> _DASH_PRODUCIDO { get; set; }
        public List<DASH_PRECOSTEO> _DASH_PRECOSTEO { get; set; }
        public List<DASH_NO_PRODUCIDO> _DASH_NO_PRODUCIDO { get; set; }
    }

    public class DASH_PRODUCIDO
    {
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Linea { get; set; }
        public string TelasConsumo { get; set; }
        public string TelasCosto { get; set; }
        public string InsumosConsumo { get; set; }
        public string InsumosCosto { get; set; }
        public string MarquillasConsumo { get; set; }
        public string MarquillasCosto { get; set; }
        public string Despiece { get; set; }
        public string Mod { get; set; }
        public string Cif { get; set; }
        public string Maquila { get; set; }
        public string ProcesosDescripcion { get; set; }
        public string ProcesosEstado { get; set; }
        public string EstadoCierre { get; set; }
        public string EstadoDatos { get; set; }
    }

    public class DASH_PRECOSTEO
    {
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Linea { get; set; }
        public string TelasConsumo { get; set; }
        public string TelasCosto { get; set; }
        public string InsumosConsumo { get; set; }
        public string InsumosCosto { get; set; }
        public string MarquillasConsumo { get; set; }
        public string MarquillasCosto { get; set; }
        public string Despiece { get; set; }
        public string Mod { get; set; }
        public string Cif { get; set; }
        public string Maquila { get; set; }
        public string ProcesosDescripcion { get; set; }
        public string ProcesosEstado { get; set; }
        public string EstadoCierre { get; set; }
        public string EstadoDatos { get; set; }
    }

    public class DASH_NO_PRODUCIDO
    {
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Linea { get; set; }
        public string FechaOc { get; set; }
        public string OrdenCompra { get; set; }
        public string EstadoOc { get; set; }
        public string CostoCompra { get; set; }
        public string Moneda { get; set; }
        public string Trm { get; set; }
        public string CostoCompraCop { get; set; }
        public string Cantidad { get; set; }
        public string Proveedor { get; set; }
        public string TerminoNegociacion { get; set; }
        public string PaisOrigen { get; set; }
        public string Estado { get; set; }
    }
}