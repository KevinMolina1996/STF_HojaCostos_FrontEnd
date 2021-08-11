using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_CARGUE_COTIZACION_TELA
    {
        [Key]
        public int CtCodigoN { get; set; }
        public string CtReferenciaS { get; set; }
        public string CtCodeS { get; set; }
        public string CtNombreS { get; set; }
        public string CtColorS { get; set; }
        public double CtCostoS { get; set; }
        public double CtConsumoS { get; set; }
        public double CtTotalS { get; set; }
        public DateTime CtFechaCreD { get; set; }
    }
}