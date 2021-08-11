using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_CAMPOS_FORMULAS_PNP
    {
        [Key]
        public int CfCogidoN { get; set; }

        [MaxLength(100)]
        public String CfNomBdS { get; set; }

        [MaxLength(100)]
        public String CfNomViewS { get; set; }

        [MaxLength(100)]
        public String CfDescS { get; set; }

        public DateTime CfFecCreD { get; set; }

        [MaxLength(100)]
        public String CfClaseS { get; set; }

        public int CfOrderN { get; set; }

        [MaxLength(100)]
        public String CfGroupS { get; set; }
    }
}