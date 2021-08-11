using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_ETIQ_MAR_EMP
    {
        [Key]
        public int PreEmeCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_EmeNombreS", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public string PreEmeNombreS { get; set; }

        [Display(Name = "text_EmeCtsxMtD", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public decimal PreEmeCtsxMtD { get; set; }

        [Display(Name = "text_EmeConF", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public float PreEmeConF { get; set; }

        [Display(Name = "text_EmeTotalD", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public decimal PreEmeTotalD { get; set; }

        [Required]
        public DateTime PreEmeFecCreD { get; set; }

        public DateTime? PreEmeFecActD { get; set; }

        [MaxLength(20)]
        public string PreEmeUsuActS { get; set; }

        [MaxLength(20)]
        public string PreEmeCodeS { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}