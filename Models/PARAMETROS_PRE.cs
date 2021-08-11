using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebHojaCosto.Models
{
    public class PARAMETROS_PRE
    {
        public TBL_PARAM_PRE _TBL_PARAM_PRE { get; set; }
        public string Factor { get; set; }
        public IEnumerable<SelectListItem> Colecciones { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Lineas { get; set; }
        public IEnumerable<SelectListItem> Sublineas { get; set; }
    }

    public class LISTA_PARAMETROS_PRE
    {
        public string NombreCampo { get; set; }
        public string ValorCampo { get; set; }
    }

}