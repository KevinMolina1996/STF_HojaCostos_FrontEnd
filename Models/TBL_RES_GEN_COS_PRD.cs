using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_RES_GEN_COS_PRD
    {
        [Key]
        public int RpCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [Display(Name = "text_RpCostoMaterialesD", ResourceType = typeof(Resources.HojaEstandar.GastosProduccion))]
        public decimal RpCostoMaterialesD { get; set; }

        [Display(Name = "text_RpCostoConversionD", ResourceType = typeof(Resources.HojaEstandar.GastosProduccion))]
        public decimal RpCostoConversionD { get; set; }

        [Required]
        public DateTime RpFecCreD { get; set; }

        public DateTime? RpFecActD { get; set; }

        [MaxLength(20)]
        public string RpUsuActS { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}