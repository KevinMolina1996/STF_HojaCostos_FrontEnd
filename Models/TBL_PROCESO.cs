using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PROCESO
    {
        [Key]
        public int PrCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PrDetalleS", ResourceType = typeof(Resources.HojaEstandar.Proceso))]
        public string PrDetalleS { get; set; }

        [Required]
        [Display(Name = "text_PrCostoM", ResourceType = typeof(Resources.HojaEstandar.Proceso))]
        public decimal PrCostoM { get; set; }

        [Required]
        public DateTime PrFecCreD { get; set; }

        public DateTime? PrFecActD { get; set; }

        [MaxLength(20)]
        public string PrUsuActS { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}