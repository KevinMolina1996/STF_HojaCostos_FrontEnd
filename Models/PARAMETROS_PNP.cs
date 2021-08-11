using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebHojaCosto.Models
{
    public class PARAMETROS_PNP
    {
        public TBL_PARAM_PNP _TBL_PARAM_PNP { get; set; }
        public string Factor { get; set; }
        public IEnumerable<SelectListItem> Colecciones { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Lineas { get; set; }
        public IEnumerable<SelectListItem> Sublineas { get; set; }
    }
}