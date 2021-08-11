using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_RES_GAS_COS_DIS
    {
        [Key]
        public int PreRdCodigoN { get; set; }

        [Required]
        public int PreHcCodigoN { get; set; }

        [Display(Name = "text_RdAdminEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal PreRdAdminEstD { get; set; }

        [Display(Name = "text_RdFinanEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal PreRdFinanEstD { get; set; }

        [Display(Name = "text_RdMercadeoEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal PreRdMercadeoEstD { get; set; }

        [Display(Name = "text_RdVentasxCanalEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal PreRdVentasxCanalEstD { get; set; }

        [Required]
        public DateTime PreRdFecCreD { get; set; }

        public DateTime? PreRdFecActD { get; set; }

        [MaxLength(20)]
        public string PreRdUsuActS { get; set; }

        [ForeignKey("PreHcCodigoN")]
        public TBL_PRE_HOJA_COSTO_PN TBL_PRE_HOJA_COSTO_PN { get; set; }
    }
}