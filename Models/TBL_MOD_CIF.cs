using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_MOD_CIF
    {
        [Key]
        public int McCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [Display(Name = "text_McCostoManoObraD", ResourceType = typeof(Resources.HojaEstandar.ModCif))]
        public decimal McCostoManoObraD { get; set; }

        [Display(Name = "text_McCostoIndirectosD", ResourceType = typeof(Resources.HojaEstandar.ModCif))]
        public decimal McCostoIndirectosD { get; set; }

        [Required]
        public DateTime McFecCreD { get; set; }

        public DateTime? McFecActD { get; set; }

        [MaxLength(20)]
        public string McUsuActS { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}