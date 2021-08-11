using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_MOD_CIF
    {
        [Key]
        public int SimMcCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [Display(Name = "text_McCostoManoObraD", ResourceType = typeof(Resources.HojaEstandar.ModCif))]
        public decimal SimMcCostoManoObraD { get; set; }

        [Display(Name = "text_McCostoIndirectosD", ResourceType = typeof(Resources.HojaEstandar.ModCif))]
        public decimal SimMcCostoIndirectosD { get; set; }

        [Required]
        public DateTime SimMcFecCreD { get; set; }

        public DateTime? SimMcFecActD { get; set; }

        [MaxLength(20)]
        public string SimMcUsuActS { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}