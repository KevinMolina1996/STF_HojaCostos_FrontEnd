using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_OPERACIONES_FORMULAS_PRE
    {
        [Key]
        public int OfCodigoN { get; set; }

        [MaxLength(100)]
        public String OfNombreS { get; set; }

        [MaxLength(100)]
        public String OfDescS { get; set; }

        [MaxLength(100)]
        public String OfColorS { get; set; }

        public DateTime OfFecCreD { get; set; }

        [MaxLength(100)]
        public String OfClaseS { get; set; }

        public int OfOrderN { get; set; }

        [MaxLength(100)]
        public String OfGroupS { get; set; }
    }
}