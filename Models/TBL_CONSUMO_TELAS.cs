using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_CONSUMO_TELAS
    {
        [Key]
        public int CtCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_CtNombreS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public string CtNombreS { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_CtColorS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public string CtColorS { get; set; }

        [Display(Name = "text_CtCtsxMtS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public decimal CtCtsxMtD { get; set; }

        [Display(Name = "text_CtConS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public float CtConF { get; set; }

        [Display(Name = "text_CtTotalS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public decimal CtTotalD { get; set; }

        [Required]
        public DateTime CtFecCreD { get; set; }

        public DateTime? CtFecActD { get; set; }

        [MaxLength(20)]
        public string CtUsuActS { get; set; }

        [MaxLength(20)]
        public string CtCodeS { get; set; }

        [MaxLength(10)]
        public string CtUnidadS { get; set; }

        public double CtRendimientoF { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set;}
    }
}