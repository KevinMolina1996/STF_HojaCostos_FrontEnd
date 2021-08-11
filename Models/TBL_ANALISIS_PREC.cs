using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_ANALISIS_PREC
    {
        [Key]
        public int ApCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [Display(Name = "text_ApPrecMaxIvaEstD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal ApPrecMaxIvaEstD { get; set; }

        [Display(Name = "text_ApPrecMaxIvaRealD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal ApPrecMaxIvaRealD { get; set; }

        [Display(Name = "text_ApMargenMaxBrutoEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMaxBrutoEstF { get; set; }

        [Display(Name = "text_ApMargenMaxBrutoRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMaxBrutoRealF { get; set; }

        [Display(Name = "text_ApMargenMaxOpeEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMaxOpeEstF { get; set; }

        [Display(Name = "text_ApMargenMaxOpeRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMaxOpeRealF { get; set; }

        [Display(Name = "text_ApPrecMinIvaEstD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal ApPrecMinIvaEstD { get; set; }

        [Display(Name = "text_ApPrecMinIvaRealD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal ApPrecMinIvaRealD { get; set; }

        [Display(Name = "text_ApMargenMinBrutoEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMinBrutoEstF { get; set; }

        [Display(Name = "text_ApMargenMinBrutoRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMinBrutoRealF { get; set; }

        [Display(Name = "text_ApMargenMinOpeEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMinOpeEstF { get; set; }

        [Display(Name = "text_ApMargenMinOpeRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float ApMargenMinOpeRealF { get; set; }

        [Required]
        public DateTime ApFecCreD { get; set; }

        public DateTime? ApFecActD { get; set; }

        [MaxLength(20)]
        public string ApUsuActS { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}