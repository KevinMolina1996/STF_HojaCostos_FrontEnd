using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_RES_GEN_COS_PRD
    {
        [Key]
        public int PreRpCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [Display(Name = "text_RpCostoMaterialesD", ResourceType = typeof(Resources.HojaEstandar.GastosProduccion))]
        public decimal PreRpCostoMaterialesD { get; set; }

        [Display(Name = "text_RpCostoConversionD", ResourceType = typeof(Resources.HojaEstandar.GastosProduccion))]
        public decimal PreRpCostoConversionD { get; set; }

        [Required]
        public DateTime PreRpFecCreD { get; set; }

        public DateTime? PreRpFecActD { get; set; }

        [MaxLength(20)]
        public string PreRpUsuActS { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}