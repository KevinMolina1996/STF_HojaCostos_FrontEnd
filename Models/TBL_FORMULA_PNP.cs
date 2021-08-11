using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_FORMULA_PNP
    {
        [Key]
        public int FoCodigoN { get; set; }
        public string FoCampoS { get; set; }
        public String FoNombreS { get; set; }
        public String FoOperacionS { get; set; }
        public String FoConsultaS { get; set; }
        public String FoConsultaSQLiteS { get; set; }
        public DateTime FoFecCreD { get; set; }
        public DateTime? FoFecActD { get; set; }
        public String FoCampoReferenciaS { get; set; }
        public int FoOrdenEjecucionN { get; set; }
        public String FoTablaReferenciaN { get; set; }
    }
}