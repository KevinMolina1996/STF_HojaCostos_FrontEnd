using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_INS_ACC
    {
        [Key]
        public int SimIaCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_IaNombreS", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public string SimIaNombreS { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_IaColorS", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public string SimIaColorS { get; set; }

        [Display(Name = "text_IaCtsxMtD", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public decimal SimIaCtsxMtD { get; set; }

        [Display(Name = "text_IaConF", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public float SimIaConF { get; set; }

        [Display(Name = "text_IaTotalD", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public decimal SimIaTotalD { get; set; }

        [Required]
        public DateTime SimIaFecCreD { get; set; }

        public DateTime? SimIaFecActD { get; set; }

        [MaxLength(20)]
        public string SimIaUsuActS { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}