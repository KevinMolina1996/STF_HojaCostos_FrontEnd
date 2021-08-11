using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_ANALISIS_PREC
    {
        [Key]
        public int PreApCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [Display(Name = "text_ApPrecMaxIvaEstD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal PreApPrecMaxIvaEstD { get; set; }

        [Display(Name = "text_ApMargenMaxBrutoEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float PreApMargenMaxBrutoEstF { get; set; }

        [Display(Name = "text_ApMargenMaxOpeEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float PreApMargenMaxOpeEstF { get; set; }

        [Display(Name = "text_ApPrecMinIvaEstD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal PreApPrecMinIvaEstD { get; set; }

        [Display(Name = "text_ApMargenMinBrutoEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float PreApMargenMinBrutoEstF { get; set; }

        [Display(Name = "text_ApMargenMinOpeEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float PreApMargenMinOpeEstF { get; set; }

        [Required]
        public DateTime PreApFecCreD { get; set; }

        public DateTime? PreApFecActD { get; set; }

        [MaxLength(20)]
        public string PreApUsuActS { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}