using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_PARAM_PRE
    {
        [Key]
        public int PreCodigoN { get; set; }

        [Display(Name = "text_coleccion", ResourceType = typeof(Resources.Parametros.Index))]
        public string PreColeccionS { get; set; }

        [Display(Name = "text_marca", ResourceType = typeof(Resources.Parametros.Index))]
        public string PreMarcaS { get; set; }

        [Display(Name = "text_linea", ResourceType = typeof(Resources.Parametros.Index))]
        public string PreLineaS { get; set; }

        [Display(Name = "text_sub_linea", ResourceType = typeof(Resources.Parametros.Index))]
        public string PreSubLineaS { get; set; }

        [Display(Name = "text_factor", ResourceType = typeof(Resources.Parametros.Index))]
        public string PreFactorS { get; set; }

        //[Required]
        //[Display(Name = "text_gastos_usd", ResourceType = typeof(Resources.Parametros.Index))]
        //[RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        //public double PpMayorUSDAdminF { get; set; }

        [Required]
        [Display(Name = "text_administrativos", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreGastosAdminF { get; set; }

        [Required]
        [Display(Name = "text_financieros", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreGastosFinanF { get; set; }

        [Required]
        [Display(Name = "text_mercadeo", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreGastosMercadeoF { get; set; }

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
        //public double PreTasaCambioEURxUSDF { get; set; }

        [Required]
        [Display(Name = "text_iva", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreIvaF { get; set; }

        [Required]
        [Display(Name = "text_tope_admin", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreAdminxFinanF { get; set; }

        [Required]
        [Display(Name = "text_tope_mercadeo", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreMercadeoF { get; set; }

        [Required]
        [Display(Name = "text_tope_vnts", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreVntsxCanalLineaF { get; set; }

        [Required]
        [Display(Name = "text_participacion_almacen", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreAlmacenLineaCanalF { get; set; }
        //public float PreMayorCanalF { get; set; }

        public double PreTopeCostoF { get; set; }

        [Required]
        [Display(Name = "text_factor_min", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreFactorRentabilidadMaxF { get; set; }

        [Required]
        [Display(Name = "text_factor_max", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreFactorRentabilidadMinF { get; set; }

        [Required]
        [Display(Name = "text_enter_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PreEnterPriceM { get; set; }

        [Required]
        [Display(Name = "text_medium_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PreMediumPriceM { get; set; }

        [Required]
        [Display(Name = "text_premium_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PrePremiumPriceM { get; set; }

        [Required]
        [Display(Name = "text_PpCocienteDivisorF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreCocienteDivisorF { get; set; }

        [Required]
        [Display(Name = "text_PpCocienteDivisor2F", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreCocienteDivisor2F { get; set; }

        [Required]
        [Display(Name = "text_PpResiduoDivisorF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public int PreResiduoDivisorF { get; set; }

        [Required]
        [Display(Name = "text_PpTopePrecioMilesF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreTopePrecioMilesF { get; set; }

        [Required]
        [Display(Name = "text_PpPrecioMinimoF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PrePrecioMinimoF { get; set; }

        [Required]
        [Display(Name = "text_PpPrecioMaximoF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PrePrecioMaximoF { get; set; }

        [Required]
        [Display(Name = "text_premium_price", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreTerminoPrecioF { get; set; }

        //PARAMETROS PARTICIPACION EN LAS VENTAS
        [Required]
        [Display(Name = "text_PpParticipacionAdminF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreParticipacionAdminF { get; set; }

        [Required]
        [Display(Name = "text_PpParticipacionFinanF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreParticipacionFinanF { get; set; }

        [Required]
        [Display(Name = "text_PpParticipacionMercadeoF", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreParticipacionMercadeoF { get; set; }
        //FIN

        //PARAMETROS FACTORES GASTOS PRECOSTEO

        [Required]
        [Display(Name = "text_gasto_insumo", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreFactorInsumoF { get; set; }

        [Required]
        [Display(Name = "text_gasto_tela", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreFactorTelaF { get; set; }

        //FIN

        //TRM
        [Required]
        [Display(Name = "text_trm", ResourceType = typeof(Resources.Parametros.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PreTrmF { get; set; }

        public DateTime PreFecCreD { get; set; }
        public DateTime? PreFecActD { get; set; }
        public string PreUsuActS { get; set; }
        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}