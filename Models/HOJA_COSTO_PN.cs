using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AppWebHojaCosto.Models
{
    public class HOJA_COSTO_PN
    {
        [Required]
        public string TipoHojaCosto { get; set; }
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
        public List<TBL_HOJA_COSTO_PN> LST_TBL_HOJA_COSTO_PN { get; set; }
        public List<TBL_SIM_HOJA_COSTO_PN> LST_TBL_SIM_HOJA_COSTO_PN { get; set; }
        public List<TBL_PRE_HOJA_COSTO_PN> LST_TBL_PRE_HOJA_COSTO_PN { get; set; }
        public IEnumerable<SelectListItem> TipoHojas { get; set; }
        public IEnumerable<SelectListItem> Referencias { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Colecciones { get; set; }
        public IEnumerable<SelectListItem> Lineas { get; set; }
        public IEnumerable<SelectListItem> Estados { get; set; }
        public IEnumerable<SelectListItem> EstadosCierre { get; set; }
    }
}