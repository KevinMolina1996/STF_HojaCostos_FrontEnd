using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_HOJA_COSTO_PNP
    {
        [Key] 
        [Column(Order = 1)]
        public int PnpCodigoN { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpEstadoS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpEstadoS { get; set; }

        [MaxLength(20)]
        public string PnpUsuCostoS { get; set; }

        [Required]
        [MaxLength(50)]
        public string PnpOrdenCompraS { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "text_PnpMarcaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpMarcaS { get; set; }

        [MaxLength(100)]
        public string PnpImgMarcaS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_PnpColeccionS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpColeccionS { get; set; }

        [Required]
        [Key]
        [Column(Order = 2)]
        [MaxLength(50)]
        [Display(Name = "text_PnpReferenciaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpReferenciaS { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "text_PnpProveedorS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpProveedorS { get; set; }

        [Required]
        [Display(Name = "text_PnpCostoCompraUSDD", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public double PnpCostoCompraUSDD { get; set; }

        [Display(Name = "text_PnpTrmM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpTrmM { get; set; }

        [Required]
        [Display(Name = "text_PnpCntPedN", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public int PnpCntPedN { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "text_PnpDescripS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpDescripS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_PnpTermNegocS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpTermNegocS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpSubLineaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpSubLineaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpPaisOrigenS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpPaisOrigenS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpLineaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string PnpLineaS { get; set; }

        //Pin Seguridad
        [Display(Name = "text_PnpPinSeguridadPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpPinSeguridadPesosM { get; set; }

        [Display(Name = "text_PnpPinSeguridadPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpPinSeguridadUsdF { get; set; }

        [Display(Name = "text_PnpPinSeguridadPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpPinSeguridadPorcF { get; set; }

        //Costo Compra
        [Display(Name = "text_PnpCostoCompraPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpCostoCompraPesosM { get; set; }

        [Display(Name = "text_PnpCostoCompraPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpCostoCompraUsdF { get; set; }

        [Display(Name = "text_PnpCostoCompraPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpCostoCompraPorcF { get; set; }

        //Gasto Origen
        [Display(Name = "text_PnpGastosOrigenPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosOrigenPesosM { get; set; }

        [Display(Name = "text_PnpGastosOrigenPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosOrigenUsdF { get; set; }

        [Display(Name = "text_PnpGastosOrigenPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosOrigenPorcF { get; set; }

        //Gasto Flete
        [Display(Name = "text_PnpGastosFletePesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosFletePesosM { get; set; }

        [Display(Name = "text_PnpGastosFletePesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosFleteUsdF { get; set; }

        [Display(Name = "text_PnpGastosFletePesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosFletePorcF { get; set; }

        //Arancel
        [Display(Name = "text_PnpGastosArancelPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosArancelPesosM { get; set; }

        [Display(Name = "text_PnpGastosArancelPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosArancelUsdF { get; set; }

        [Display(Name = "text_PnpGastosArancelPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosArancelPorcF { get; set; }

        //Seguro internacional
        [Display(Name = "text_PnpGastosSeguroPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosSeguroPesosM { get; set; }

        [Display(Name = "text_PnpGastosSeguroPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosSeguroUsdF { get; set; }

        [Display(Name = "text_PnpGastosSeguroPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosSeguroPorcF { get; set; }

        //Gasto Destino
        [Display(Name = "text_PnpGastosDestinoPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosDestinoPesosM { get; set; }

        [Display(Name = "text_PnpGastosDestinoPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosDestinoUsdF { get; set; }

        [Display(Name = "text_PnpGastosDestinoPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosDestinoPorcF { get; set; }

        //Otros Gastos
        [Display(Name = "text_PnpGastosOtrosPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosOtrosPesosM { get; set; }

        [Display(Name = "text_PnpGastosOtrosPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosOtrosUsdF { get; set; }

        [Display(Name = "text_PnpGastosOtrosPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosOtrosPorcF { get; set; }

        //Total Costo Puesto Bodega
        [Display(Name = "text_PnpTotalCostoBodegaM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpTotalCostoBodegaM { get; set; }

        [Display(Name = "text_PnpTotalCostoBodegaM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpTotalCostoBodegaF { get; set; }

        //Adecuacion Producto
        [Display(Name = "text_PnpAdecuacionPrdM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpAdecuacionPrdM { get; set; }

        [Display(Name = "text_PnpAdecuacionPrdM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpAdecuacionPrdF { get; set; }

        //Sensorización
        [Display(Name = "text_PnpSensorizacionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpSensorizacionM { get; set; }

        [Display(Name = "text_PnpSensorizacionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpSensorizacionF { get; set; }

        //Arreglo producto
        [Display(Name = "text_PnpArregloM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpArregloM { get; set; }

        [Display(Name = "text_PnpArregloM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpArregloF { get; set; }

        //Reconstruccion Producto
        [Display(Name = "text_PnpReconstruccionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpReconstruccionM { get; set; }

        [Display(Name = "text_PnpReconstruccionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpReconstruccionF { get; set; }

        //Gastos Administrativos ventas
        [Display(Name = "text_PnpGastosAdmonRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosAdmonRealM { get; set; }

        [Display(Name = "text_PnpGastosAdmonRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosAdmonRealF { get; set; }

        [Display(Name = "text_PnpGastosAdmonEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpGastosAdmonEstimadoM { get; set; }

        [Display(Name = "text_PnpGastosAdmonEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpGastosAdmonEstimadoF { get; set; }

        //Total Gastos + Costos
        [Display(Name = "text_PnpTotalCostosGastosRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpTotalCostosGastosRealM { get; set; }

        [Display(Name = "text_PnpTotalCostosGastosRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpTotalCostosGastosRealF { get; set; }

        [Display(Name = "text_PnpTotalCostosGastosEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpTotalCostosGastosEstimadoM { get; set; }

        [Display(Name = "text_PnpTotalCostosGastosEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpTotalCostosGastosEstimadoF { get; set; }

        //Precio maximo con iva
        [Display(Name = "text_PnpPrecioMaxRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpPrecioMaxRealM { get; set; }

        [Display(Name = "text_PnpPrecioMaxRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpPrecioMaxEstimadoM { get; set; }

        //Margen Bruto %
        [Display(Name = "text_PnpMargenMaxBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMaxBrutoRealF { get; set; }

        [Display(Name = "text_PnpMargenMaxBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMaxBrutoEstimadoF { get; set; }

        //Margen operacional %
        [Display(Name = "text_PnpMargenMaxOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMaxOpeRealF { get; set; }

        [Display(Name = "text_PnpMargenMaxOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMaxOpeEstimadoF { get; set; }

        //Precio minimo con iva
        [Display(Name = "text_PnpPrecioMinRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpPrecioMinRealM { get; set; }

        [Display(Name = "text_PnpPrecioMinRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpPrecioMinEstimadoM { get; set; }

        //Margen bruto
        [Display(Name = "text_PnpMargenMinBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMinBrutoRealF { get; set; }

        [Display(Name = "text_PnpMargenMinBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMinBrutoEstimadoF { get; set; }

        //Margen operacional
        [Display(Name = "text_PnpMargenMinOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMinOpeRealF { get; set; }

        [Display(Name = "text_PnpMargenMinOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float PnpMargenMinOpeEstimadoF { get; set; }

        //Piramide Precios
        [Display(Name = "text_PnpEnterPriceM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpEnterPriceM { get; set; }

        [Display(Name = "text_PnpMediumPriceM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpMediumPriceM { get; set; }

        [Display(Name = "text_PnpPremiumPriceM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal PnpPremiumPriceM { get; set; }

        //Estado orden de compra de unoee
        public string PnpEstadoOrdenCompraS { get; set; }
        //Fin

        //Estado de aprobacion de unoee
        public string PnpEstadoAprobacion { get; set; }
        //Fin

        //Precio aprobado registrado en unoee
        public decimal PnpPrecioD { get; set; }
        //Fin

        //Fecha de aprobacion
        public DateTime? PnpFechaAprobacionD { get; set; }
        //Fin

        //Moneda
        public string PnpMonedaS { get; set; }
        //Fin

        //Imagen Delantera
        public string PnpImagenS { get; set; }

        //Imagen Trasera
        public string PnpImagenTrasS { get; set; }

        //Fecha Creación
        public DateTime PnpFecCreD { get; set; }

        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}