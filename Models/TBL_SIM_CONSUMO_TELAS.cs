using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_CONSUMO_TELAS
    {
        [Key]
        public int SimCtCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_CtNombreS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public string SimCtNombreS { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_CtColorS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public string SimCtColorS { get; set; }

        [Display(Name = "text_CtCtsxMtS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public decimal SimCtCtsxMtD { get; set; }

        [Display(Name = "text_CtConS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public float SimCtConF { get; set; }

        [Display(Name = "text_CtTotalS", ResourceType = typeof(Resources.HojaEstandar.ConsumoTelas))]
        public decimal SimCtTotalD { get; set; }

        [Required]
        public DateTime SimCtFecCreD { get; set; }

        public DateTime? SimCtFecActD { get; set; }

        [MaxLength(20)]
        public string SimCtUsuActS { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}