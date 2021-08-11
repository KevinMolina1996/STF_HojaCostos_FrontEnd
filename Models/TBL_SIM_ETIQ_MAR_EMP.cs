using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_ETIQ_MAR_EMP
    {
        [Key]
        public int SimEmeCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_EmeNombreS", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public string SimEmeNombreS { get; set; }

        [Display(Name = "text_EmeCtsxMtD", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public decimal SimEmeCtsxMtD { get; set; }

        [Display(Name = "text_EmeConF", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public float SimEmeConF { get; set; }

        [Display(Name = "text_EmeTotalD", ResourceType = typeof(Resources.HojaEstandar.Marquilla))]
        public decimal SimEmeTotalD { get; set; }

        [Required]
        public DateTime SimEmeFecCreD { get; set; }

        public DateTime? SimEmeFecActD { get; set; }

        [MaxLength(20)]
        public string SimEmeUsuActS { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}