using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_PROCESO
    {
        [Key]
        public int SimPrCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PrDetalleS", ResourceType = typeof(Resources.HojaEstandar.Proceso))]
        public string SimPrDetalleS { get; set; }

        [Required]
        [Display(Name = "text_PrCostoM", ResourceType = typeof(Resources.HojaEstandar.Proceso))]
        public decimal SimPrCostoM { get; set; }

        [Required]
        public DateTime SimPrFecCreD { get; set; }

        public DateTime? SimPrFecActD { get; set; }

        [MaxLength(20)]
        public string SimPrUsuActS { get; set; }

        [NotMapped]
        public bool Borrado { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}