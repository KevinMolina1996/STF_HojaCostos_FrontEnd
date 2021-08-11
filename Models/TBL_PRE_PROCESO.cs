using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_PROCESO
    {
        [Key]
        public int PrePrCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PrDetalleS", ResourceType = typeof(Resources.HojaEstandar.Proceso))]
        public string PrePrDetalleS { get; set; }

        [Required]
        [Display(Name = "text_PrCostoM", ResourceType = typeof(Resources.HojaEstandar.Proceso))]
        public decimal PrePrCostoM { get; set; }

        [Required]
        public DateTime PrePrFecCreD { get; set; }

        public DateTime? PrePrFecActD { get; set; }

        [MaxLength(20)]
        public string PrePrUsuActS { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}