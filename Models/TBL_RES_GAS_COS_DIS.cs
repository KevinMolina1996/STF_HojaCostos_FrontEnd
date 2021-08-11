using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_RES_GAS_COS_DIS
    {
        [Key]
        public int RdCodigoN { get; set; }

        [Required]
        public int HcCodigoN { get; set; }

        [Display(Name = "text_RdAdminEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdAdminEstD { get; set; }

        [Display(Name = "text_RdAdminRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdAdminRealD { get; set; }

        [Display(Name = "text_RdFinanEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdFinanEstD { get; set; }

        [Display(Name = "text_RdFinanRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdFinanRealD { get; set; }

        [Display(Name = "text_RdMercadeoEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdMercadeoEstD { get; set; }

        [Display(Name = "text_RdMercadeoRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdMercadeoRealD { get; set; }

        [Display(Name = "text_RdVentasxCanalEstD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdVentasxCanalEstD { get; set; }

        [Display(Name = "text_RdVentasxCanalRealD", ResourceType = typeof(Resources.HojaEstandar.ResumenGastos))]
        public decimal RdVentasxCanalRealD { get; set; }

        [Required]
        public DateTime RdFecCreD { get; set; }

        public DateTime? RdFecActD { get; set; }

        [MaxLength(20)]
        public string RdUsuActS { get; set; }

        [ForeignKey("HcCodigoN")]
        public TBL_HOJA_COSTO_PN TBL_HOJA_COSTO_PN { get; set; }
    }
}