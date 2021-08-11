using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_HOJA_COSTO_PN
    {
        [Key]
        public int SimHcCodigoN { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcReferenciaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcReferenciaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcColeccionS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcColeccionS { get; set; }

        [MaxLength(50)]
        [Display(Name = "text_HcDisenadorS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcDisenadorS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcLineaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcLineaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcSubLineaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcSubLineaS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcEstadoS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcEstadoS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcEstadoAproS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcEstadoAproS { get; set; }

        [MaxLength(50)]
        [Display(Name = "text_HcPatronistaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcPatronistaS { get; set; }

        [MaxLength(200)]
        public string SimHcDescripcionS { get; set; }

        [MaxLength(20)]
        public string SimHcUsuCostoS { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "text_HcMarcaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string SimHcMarcaS { get; set; }

        [MaxLength(100)]
        public string SimHcImgMarcaS { get; set; }

        [Display(Name = "text_HcTotalTelasM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalTelasD { get; set; }

        [Display(Name = "text_HcTotalConTelasM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalConTelasD { get; set; }

        [Display(Name = "text_HcTotalProcesosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalProcesosD { get; set; }

        [Display(Name = "text_HcTotalInsumoM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalInsumoD { get; set; }

        [Display(Name = "text_HcTotalMarquillaM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalMarquillaD { get; set; }

        [Display(Name = "text_HcTotalCIFMODM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalCIFMODD { get; set; }

        [Display(Name = "text_HcTotalCosPrdM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalCosPrdD { get; set; }

        [Display(Name = "text_HcTotalGastosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalGastosEstD { get; set; }

        [Display(Name = "text_HcTotalGastosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalGastosRealD { get; set; }

        [Display(Name = "text_HcTotalxCanalM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalxCanalEstD { get; set; }

        [Display(Name = "text_HcTotalxCanalM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcTotalxCanalRealD { get; set; }

        [Display(Name = "text_HcEnterPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcEnterPriceD { get; set; }

        [Display(Name = "text_HcMediumPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcMediumPriceD { get; set; }

        [Display(Name = "text_HcPremiumPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal SimHcPremiumPriceD { get; set; }

        public string SimHcImagenDS { get; set; }
        public string SimHcImagenTS { get; set; }
        public DateTime SimHcFecCreD { get; set; }
        public DateTime? SimHcFecActD { get; set; }
        public string SimHcUsuActS { get; set; }

        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}