using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_RES_GEN_COS_PRD
    {
        [Key]
        public int SimRpCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [Display(Name = "text_RpCostoMaterialesD", ResourceType = typeof(Resources.HojaEstandar.GastosProduccion))]
        public decimal SimRpCostoMaterialesD { get; set; }

        [Display(Name = "text_RpCostoConversionD", ResourceType = typeof(Resources.HojaEstandar.GastosProduccion))]
        public decimal SimRpCostoConversionD { get; set; }

        [Required]
        public DateTime SimRpFecCreD { get; set; }

        public DateTime? SimRpFecActD { get; set; }

        [MaxLength(20)]
        public string SimRpUsuActS { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}