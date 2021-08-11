using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_INS_ACC
    {
        [Key]
        public int PreIaCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_IaNombreS", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public string PreIaNombreS { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_IaColorS", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public string PreIaColorS { get; set; }

        [Display(Name = "text_IaCtsxMtD", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public decimal PreIaCtsxMtD { get; set; }

        [Display(Name = "text_IaConF", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public float PreIaConF { get; set; }

        [Display(Name = "text_IaTotalD", ResourceType = typeof(Resources.HojaEstandar.Insumos))]
        public decimal PreIaTotalD { get; set; }

        [Required]
        public DateTime PreIaFecCreD { get; set; }

        public DateTime? PreIaFecActD { get; set; }

        [MaxLength(20)]
        public string PreIaUsuActS { get; set; }

        [MaxLength(20)]
        public string PreIaCodeS { get; set; }

        [MaxLength(10)]
        public string PreIaUnidadS { get; set; }

        public double PreIaRendimientoF { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}