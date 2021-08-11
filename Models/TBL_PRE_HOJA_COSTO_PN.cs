using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_PRE_HOJA_COSTO_PN
    {
        [Key]
        public int PreHcCodigoN { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcReferenciaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcReferenciaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcColeccionS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcColeccionS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcDisenadorS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcDisenadorS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcLineaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcLineaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcSubLineaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcSubLineaS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcEstadoS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcEstadoS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_HcEstadoAproS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcEstadoAproS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_HcPatronistaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcPatronistaS { get; set; }

        [MaxLength(200)]
        public string PreHcDescripcionS { get; set; }

        [Required]
        [MaxLength(20)]
        public string PreHcUsuCostoS { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "text_HcMarcaS", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public string PreHcMarcaS { get; set; }

        [MaxLength(100)]
        public string PreHcImgMarcaS { get; set; }

        [Display(Name = "text_HcTotalTelasM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalTelasD { get; set; }

        [Display(Name = "text_HcTotalConTelasM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalConTelasD { get; set; }

        [Display(Name = "text_HcTotalProcesosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalProcesosD { get; set; }

        [Display(Name = "text_HcTotalInsumoM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalInsumoD { get; set; }

        [Display(Name = "text_HcTotalMarquillaM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalMarquillaD { get; set; }

        [Display(Name = "text_HcTotalCIFMODM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalCIFMODD { get; set; }

        [Display(Name = "text_HcTotalCosPrdM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalCosPrdD { get; set; }

        [Display(Name = "text_HcTotalGastosM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalGastosEstD { get; set; }

        [Display(Name = "text_HcTotalxCanalM", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcTotalxCanalEstD { get; set; }

        [Display(Name = "text_HcEnterPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcEnterPriceD { get; set; }

        [Display(Name = "text_HcMediumPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcMediumPriceD { get; set; }

        [Display(Name = "text_HcPremiumPriceD", ResourceType = typeof(Resources.HojaEstandar.Index))]
        public decimal PreHcPremiumPriceD { get; set; }

        //Precio aprobado registrado en unoee
        public decimal PreHcPrecioD { get; set; }
        //fin

        //Fecha de aprobacion
        public DateTime? PreHcFechaAprobacionD { get; set; }
        //Fin

        //Maquila y Despiece
        public double PreHcMaquilaF { get; set; }
        public double PreHcDespieceF { get; set; }
        //Fin

        public string PreHcImagenDS { get; set; }
        public string PreHcImagenTS { get; set; }
        public DateTime PreHcFecCreD { get; set; }
        public DateTime? PreHcFecActD { get; set; }
        public string PreHcUsuActS { get; set; }

        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}