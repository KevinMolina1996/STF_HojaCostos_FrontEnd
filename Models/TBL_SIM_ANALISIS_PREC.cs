using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_ANALISIS_PREC
    {
        [Key]
        public int SimApCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [Display(Name = "text_ApPrecMaxIvaEstD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal SimApPrecMaxIvaEstD { get; set; }

        [Display(Name = "text_ApPrecMaxIvaRealD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal SimApPrecMaxIvaRealD { get; set; }

        [Display(Name = "text_ApMargenMaxBrutoEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMaxBrutoEstF { get; set; }

        [Display(Name = "text_ApMargenMaxBrutoRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMaxBrutoRealF { get; set; }

        [Display(Name = "text_ApMargenMaxOpeEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMaxOpeEstF { get; set; }

        [Display(Name = "text_ApMargenMaxOpeRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMaxOpeRealF { get; set; }

        [Display(Name = "text_ApPrecMinIvaEstD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal SimApPrecMinIvaEstD { get; set; }

        [Display(Name = "text_ApPrecMinIvaRealD", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public decimal SimApPrecMinIvaRealD { get; set; }

        [Display(Name = "text_ApMargenMinBrutoEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMinBrutoEstF { get; set; }

        [Display(Name = "text_ApMargenMinBrutoRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMinBrutoRealF { get; set; }

        [Display(Name = "text_ApMargenMinOpeEstF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMinOpeEstF { get; set; }

        [Display(Name = "text_ApMargenMinOpeRealF", ResourceType = typeof(Resources.HojaEstandar.AnalisisPrecios))]
        public float SimApMargenMinOpeRealF { get; set; }

        [Required]
        public DateTime SimApFecCreD { get; set; }

        public DateTime? SimApFecActD { get; set; }

        [MaxLength(20)]
        public string SimApUsuActS { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}