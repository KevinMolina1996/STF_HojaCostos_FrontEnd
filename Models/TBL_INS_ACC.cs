using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_INS_ACC
    {
        [Key]
        public int IaCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_IaNombreS", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public string IaNombreS { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_IaColorS", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public string IaColorS { get; set; }

        [Display(Name = "text_IaCtsxMtD", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public decimal IaCtsxMtD { get; set; }

        [Display(Name = "text_IaConF", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public float IaConF { get; set; }

        [Display(Name = "text_IaTotalD", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public decimal IaTotalD { get; set; }

        [Required]
        public DateTime IaFecCreD { get; set; }

        public DateTime? IaFecActD { get; set; }

        [MaxLength(20)]
        public string IaUsuActS { get; set; }

        [MaxLength(20)]
        public string IaCodeS { get; set; }

        [MaxLength(10)]
        public string IaUnidadS { get; set; }

        public double IaRendimientoF { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}