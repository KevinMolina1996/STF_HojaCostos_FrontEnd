using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_ETIQ_MAR_EMP
    {
        [Key]
        public int EmeCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_EmeNombreS", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public string EmeNombreS { get; set; }

        [Display(Name = "text_EmeCtsxMtD", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public decimal EmeCtsxMtD { get; set; }

        [Display(Name = "text_EmeConF", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public float EmeConF { get; set; }

        [Display(Name = "text_EmeTotalD", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public decimal EmeTotalD { get; set; }

        [Required]
        public DateTime EmeFecCreD { get; set; }

        public DateTime? EmeFecActD { get; set; }

        [MaxLength(20)]
        public string EmeUsuActS { get; set; }

        [MaxLength(20)]
        public string EmeCodeS { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}