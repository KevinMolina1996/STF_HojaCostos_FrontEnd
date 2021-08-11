using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_MOD_CIF
    {
        [Key]
        public int PreMcCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [Display(Name = "text_McCostoManoObraD", ResourceType = typeof(Resources.HojaEstandar.ModCif))]
        public decimal PreMcCostoManoObraD { get; set; }

        [Display(Name = "text_McCostoIndirectosD", ResourceType = typeof(Resources.HojaEstandar.ModCif))]
        public decimal PreMcCostoIndirectosD { get; set; }

        [Required]
        public DateTime PreMcFecCreD { get; set; }

        public DateTime? PreMcFecActD { get; set; }

        [MaxLength(20)]
        public string PreMcUsuActS { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}