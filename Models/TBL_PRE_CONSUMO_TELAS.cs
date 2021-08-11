using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_CONSUMO_TELAS
    {
        [Key]
        public int PreCtCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_CtNombreS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public string PreCtNombreS { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_CtColorS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public string PreCtColorS { get; set; }

        [Display(Name = "text_CtCtsxMtS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public decimal PreCtCtsxMtD { get; set; }

        [Display(Name = "text_CtConS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public float PreCtConF { get; set; }

        [Display(Name = "text_CtTotalS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public decimal PreCtTotalD { get; set; }

        [Required]
        public DateTime PreCtFecCreD { get; set; }

        public DateTime? PreCtFecActD { get; set; }

        [MaxLength(20)]
        public string PreCtUsuActS { get; set; }

        [MaxLength(20)]
        public string PreCtCodeS { get; set; }

        [MaxLength(10)]
        public string PreCtUnidadS { get; set; }

        public double PreCtRendimientoF { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}