using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_RES_GAS_COS_DIS
    {
        [Key]
        public int SimRdCodigoN { get; set; }

        [Required]
        public int SimHcCodigoN { get; set; }

        [Display(Name = "text_RdAdminEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdAdminEstD { get; set; }

        [Display(Name = "text_RdAdminRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdAdminRealD { get; set; }

        [Display(Name = "text_RdFinanEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdFinanEstD { get; set; }

        [Display(Name = "text_RdFinanRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdFinanRealD { get; set; }

        [Display(Name = "text_RdMercadeoEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdMercadeoEstD { get; set; }

        [Display(Name = "text_RdMercadeoRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdMercadeoRealD { get; set; }

        [Display(Name = "text_RdVentasxCanalEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdVentasxCanalEstD { get; set; }

        [Display(Name = "text_RdVentasxCanalRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal SimRdVentasxCanalRealD { get; set; }

        [Required]
        public DateTime SimRdFecCreD { get; set; }

        public DateTime? SimRdFecActD { get; set; }

        [MaxLength(20)]
        public string SimRdUsuActS { get; set; }

        [ForeignKey("SimHcCodigoN")]
        public TBL_SIM_HOJA_COSTO_PN TBL_SIM_HOJA_COSTO_PN { get; set; }
    }
}