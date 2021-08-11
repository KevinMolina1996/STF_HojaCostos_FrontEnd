using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_PARAM_PN
    {
        [Key]
        public int PpCodigoN { get; set; }

        [Display(Name = "text_coleccion", ResourceType = typeof(Resources.Parametros.Index))]
        public string PpColeccionS { get; set; }

        [Display(Name = "text_marca", ResourceType = typeof(Resources.Parametros.Index))]
        public string PpMarcaS { get; set; }

        [Display(Name = "text_linea", ResourceType = typeof(Resources.Parametros.Index))]
        public string PpLineaS { get; set; }

        [Display(Name = "text_sub_linea", ResourceType = typeof(Resources.Parametros.Index))]
        public string PpSubLineaS { get; set; }

        [Display(Name = "text_factor", ResourceType = typeof(Resources.Parametros.Index))]
        public string PpFactorS { get; set; }

        //[Required]
        //[Display(Name = "text_gastos_usd", ResourceType = typeof(Resources.Parametros.Index))]
        //[RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        //public double PpMayorUSDAdminF { get; set; }

        [Required]
        [Display(Name = "text_administrativos", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpGastosAdminF { get; set; }

        [Required]
        [Display(Name = "text_financieros", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpGastosFinanF { get; set; }

        [Required]
        [Display(Name = "text_mercadeo", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpGastosMercadeoF { get; set; }

        //[Required]
        //[Display(Name = "text_tasa_coleccion", ResourceType = typeof(Resources.Parametros.Index))]
        //[RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        //public double PpTasaColeccionF { get; set; }

        //[Required]
        //[Display(Name = "text_tasa_especial", ResourceType = typeof(Resources.Parametros.Index))]
        //[RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        //public double PpTasaEspecialF { get; set; }

        //[Required]
        //[Display(Name = "text_tasa_eur", ResourceType = typeof(Resources.Parametros.Index))]
        //[RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        //public double PpTasaCambioEURxUSDF { get; set; }

        [Required]
        [Display(Name = "text_iva", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpIvaF { get; set; }

        [Required]
        [Display(Name = "text_tope_admin", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpAdminxFinanF { get; set; }

        [Required]
        [Display(Name = "text_tope_mercadeo", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpMercadeoF { get; set; }

        [Required]
        [Display(Name = "text_tope_vnts", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpVntsxCanalLineaF { get; set; }

        [Required]
        [Display(Name = "text_participacion_almacen", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpAlmacenLineaCanalF { get; set; }
        //public float PpMayorCanalF { get; set; }

        public double PpTopeCostoF { get; set; }

        [Required]
        [Display(Name = "text_factor_min", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpFactorRentabilidadMaxF { get; set; }

        [Required]
        [Display(Name = "text_factor_max", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpFactorRentabilidadMinF { get; set; }

        [Required]
        [Display(Name = "text_enter_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PpEnterPriceM { get; set; }

        [Required]
        [Display(Name = "text_medium_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PpMediumPriceM { get; set; }

        [Required]
        [Display(Name = "text_premium_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PpPremiumPriceM { get; set; }

        [Required]
        [Display(Name = "text_PpCocienteDivisorF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpCocienteDivisorF { get; set; }

        [Required]
        [Display(Name = "text_PpCocienteDivisor2F", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpCocienteDivisor2F { get; set; }

        [Required]
        [Display(Name = "text_PpResiduoDivisorF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public int PpResiduoDivisorF { get; set; }

        [Required]
        [Display(Name = "text_PpTopePrecioMilesF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpTopePrecioMilesF { get; set; }

        [Required]
        [Display(Name = "text_PpPrecioMinimoF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpPrecioMinimoF { get; set; }

        [Required]
        [Display(Name = "text_PpPrecioMaximoF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpPrecioMaximoF { get; set; }

        [Required]
        [Display(Name = "text_premium_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpTerminoPrecioF { get; set; }

        //PARAMETROS PARTICIPACION EN LAS VENTAS
        [Required]
        [Display(Name = "text_PpParticipacionAdminF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpParticipacionAdminF { get; set; }

        [Required]
        [Display(Name = "text_PpParticipacionFinanF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpParticipacionFinanF { get; set; }

        [Required]
        [Display(Name = "text_PpParticipacionMercadeoF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpParticipacionMercadeoF { get; set; }
        //FIN

        //PARAMETROS FACTORES GASTOS COTIZACION

        [Required]
        [Display(Name = "text_gasto_insumo", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpFactorInsumoF { get; set; }

        [Required]
        [Display(Name = "text_gasto_tela", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpFactorTelaF { get; set; }

        //FIN

        //TRM
        [Required]
        [Display(Name = "text_trm", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PpTrmF { get; set; }

        public DateTime PpFecCreD { get; set; }
        public DateTime? PpFecActD { get; set; }
        public string PpUsuActS { get; set; }
        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}