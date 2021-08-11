using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_HOJA_COSTO_PN
    {
        [Key]
        public int HcCodigoN { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcReferenciaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcReferenciaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcColeccionS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcColeccionS { get; set; }

        [MaxLength(50)]
        [Display(Name = "text_HcDisenadorS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcDisenadorS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcLineaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcLineaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcSubLineaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcSubLineaS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcEstadoS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcEstadoS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcEstadoAproS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcEstadoAproS { get; set; }

        [MaxLength(50)]
        [Display(Name = "text_HcPatronistaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcPatronistaS { get; set; }

        [MaxLength(200)]
        public string HcDescripcionS { get; set; }

        [Required]
        [MaxLength(20)]
        public string HcUsuCostoS { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "text_HcMarcaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string HcMarcaS { get; set; }

        [MaxLength(100)]
        public string HcImgMarcaS { get; set; }

        [Display(Name = "text_HcTotalTelasM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalTelasD { get; set; }

        [Display(Name = "text_HcTotalConTelasM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalConTelasD { get; set; }

        [Display(Name = "text_HcTotalProcesosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalProcesosD { get; set; }

        [Display(Name = "text_HcTotalInsumoM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalInsumoD { get; set; }

        [Display(Name = "text_HcTotalMarquillaM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalMarquillaD { get; set; }

        [Display(Name = "text_HcTotalCIFMODM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalCIFMODD { get; set; }

        [Display(Name = "text_HcTotalCosPrdM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalCosPrdD { get; set; }

        [Display(Name = "text_HcTotalGastosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalGastosEstD { get; set; }

        [Display(Name = "text_HcTotalGastosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalGastosRealD { get; set; }

        [Display(Name = "text_HcTotalxCanalM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalxCanalEstD { get; set; }

        [Display(Name = "text_HcTotalxCanalM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcTotalxCanalRealD { get; set; }

        [Display(Name = "text_HcEnterPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcEnterPriceD { get; set; }

        [Display(Name = "text_HcMediumPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcMediumPriceD { get; set; }

        [Display(Name = "text_HcPremiumPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal HcPremiumPriceD { get; set; }

        //Precio aprobado registrado en unoee
        public decimal HcPrecioD { get; set; }
        //fin

        //Fecha de aprobacion
        public DateTime? HcFechaAprobacionD { get; set; }
        //Fin

        //Maquila y Despiece
        public double HcMaquilaF { get; set; }
        public double HcDespieceF { get; set; }
        //Fin

        public string HcImagenDS { get; set; }
        public string HcImagenTS { get; set; }
        public DateTime HcFecCreD { get; set; }
        public DateTime? HcFecActD { get; set; }
        public string HcUsuActS { get; set; }
        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}