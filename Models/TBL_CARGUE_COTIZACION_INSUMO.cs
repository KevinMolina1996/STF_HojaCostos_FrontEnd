using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_CARGUE_COTIZACION_INSUMO
    {
        [Key]
        public int CiCodigoN { get; set; }
        public string CiReferenciaS { get; set; }
        public string CiCodeS { get; set; }
        public string CiNombreS { get; set; }
        public string CiColorS { get; set; }
        public double CiCostoS { get; set; }
        public double CiConsumoS { get; set; }
        public double CiTotalS { get; set; }
        public DateTime CiFechaCreD { get; set; }
    }
}