using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebHojaCosto.Models
{
    public class HOJA_COSTO_PNP
    {
        public string TipoHojaCosto { get; set; }
        public TBL_HOJA_COSTO_PNP TBL_HOJA_COSTO_PNP { get; set; }
        public IEnumerable<TBL_HOJA_COSTO_PNP> LST_TBL_HOJA_COSTO_PNP { get; set; }
        public IEnumerable<TBL_SIM_HOJA_COSTO_PNP> LST_TBL_SIM_HOJA_COSTO_PNP { get; set; }
        public IEnumerable<SelectListItem> TipoHojas { get; set; }
        public IEnumerable<SelectListItem> Referencias { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Colecciones { get; set; }
        public IEnumerable<SelectListItem> Lineas { get; set; }
        public IEnumerable<SelectListItem> Estados { get; set; }
    }
}