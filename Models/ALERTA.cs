using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebHojaCosto.Models
{
    public class ALERTA
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Referencia { get; set; }
        public string Marca { get; set; }
        public string Coleccion { get; set; }
        public string Linea { get; set; }
        public IEnumerable<TBL_ALERTA> TBL_ALERTA { get; set; }
        public IEnumerable<SelectListItem> Referencias { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Colecciones { get; set; }
        public IEnumerable<SelectListItem> Lineas { get; set; }
    }
}