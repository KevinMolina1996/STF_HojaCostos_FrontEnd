using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_PARAM_PNP
    {
        [Key]
        public int PnCodigoN { get; set; }

        [Display(Name = "text_PnColeccionS", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        public string PnColeccionS { get; set; }

        [Display(Name = "text_PnMarcaS", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        public string PnMarcaS { get; set; }

        [Display(Name = "text_PnLineaS", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        public string PnLineaS { get; set; }

        [Display(Name = "text_PnSubLineaS", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        public string PnSubLineaS { get; set; }

        [Display(Name = "text_PnFactorS", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        public string PnFactorS { get; set; }

        [Required]
        [Display(Name = "text_PnAdcPrdM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnAdcPrdM { get; set; }

        [Required]
        [Display(Name = "text_PnSensorizacionM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnSensorizacionM { get; set; }

        [Required]
        [Display(Name = "text_PnArregloPrdM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnArregloPrdM { get; set; }

        [Required]
        [Display(Name = "text_PnReconstruccionM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnReconstruccionM { get; set; }

        [Required]
        [Display(Name = "text_PnFactorMinF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnFactorMinF { get; set; }

        [Required]
        [Display(Name = "text_PnFactorMaxF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnFactorMaxF { get; set; }

        [Required]
        [Display(Name = "text_PnIvaF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnIvaF { get; set; }

        //Valor en condicionales de valor maximo y minimo
        [Required]
        [Display(Name = "text_PnDivisorCocienteF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnDivisorCocienteF { get; set; }

        [Required]
        [Display(Name = "text_PnDivisorCocienteF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnDivisorCocienteDosF { get; set; }

        [Required]
        [Display(Name = "text_PnDivisorResiduoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public int PnDivisorResiduoF { get; set; }

        [Required]
        [Display(Name = "text_PnTopeMinimoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnTopeMinimoF { get; set; }

        [Required]
        [Display(Name = "text_PnTopeMaximoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnTopeMaximoF { get; set; }

        [Required]
        [Display(Name = "text_PnValorVerdaderoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnValorVerdaderoF { get; set; }

        [Required]
        [Display(Name = "text_PnValorFalsoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnValorFalsoF { get; set; }

        [Required]
        [Display(Name = "text_PnRedondeoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnRedondeoF { get; set; }

        //Fin

        //Piramide Precios

        [Required]
        [Display(Name = "text_PnEnterpriceM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnEnterpriceM { get; set; }

        [Required]
        [Display(Name = "text_PnMediumPriceM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnMediumPriceM { get; set; }

        [Required]
        [Display(Name = "text_PnPremiumPriceM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnPremiumPriceM { get; set; }

        //Fin

        //Gastos importacion

        [Required]
        [Display(Name = "text_PnPinSeguridadF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnPinSeguridadF { get; set; }

        [Required]
        [Display(Name = "text_PnGastosOrigenF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnGastosOrigenF { get; set; }

        [Required]
        [Display(Name = "text_PnGastosFleteF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnGastosFleteF { get; set; }

        [Required]
        [Display(Name = "text_PnGastosFleteAereroF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnGastosFleteAereoF { get; set; }

        [Required]
        [Display(Name = "text_PnArancelF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnArancelF { get; set; }

        [Required]
        [Display(Name = "text_PnSeguroIntF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnSeguroIntF { get; set; }

        [Required]
        [Display(Name = "text_PnGastosDestF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnGastosDestF { get; set; }

        [Required]
        [Display(Name = "text_PnOtrosGastosF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnOtrosGastosF { get; set; }

        //Fin

        //Generales

        [Required]
        [Display(Name = "text_PnTRMF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnTRMF { get; set; }

        //Fin

        //Gastos

        [Required]
        [Display(Name = "text_PnGastosEstimadoF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnGastosEstimadoF { get; set; }

        [Required]
        [Display(Name = "text_PnGastosRealesM", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public decimal PnGastosRealesM { get; set; }

        //Fin

        [Required]
        [Display(Name = "text_PnPorcGastosF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnPorcGastosRealF { get; set; }

        [Required]
        [Display(Name = "text_PnPorcGastosF", ResourceType = typeof(Resources.ParametrosPnp.Index))]
        [RegularExpression(@"^[0-9]\d*(\,\d+)?$", ErrorMessage = "Valor incorrecto")]
        public double PnPorcGastosEstimadoF { get; set; }

        public DateTime PnFecCreD { get; set; }

        public DateTime? PnFecActD { get; set; }
        public string PnUsuActS { get; set; }
        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}