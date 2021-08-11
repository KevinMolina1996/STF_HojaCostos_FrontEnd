using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebHojaCosto.Models
{
    public class TBL_SIM_HOJA_COSTO_PNP
    {
        [Key]
        [Column(Order = 1)]
        public int SimPnpCodigoN { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpEstadoS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpEstadoS { get; set; }

        [MaxLength(20)]
        public string SimPnpUsuCostoS { get; set; }

        [Required]
        [MaxLength(50)]
        public string SimPnpOrdenCompraS { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "text_PnpMarcaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpMarcaS { get; set; }

        [MaxLength(100)]
        public string SimPnpImgMarcaS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_PnpColeccionS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpColeccionS { get; set; }

        [Required]
        [Key]
        [Column(Order = 2)]
        [MaxLength(50)]
        [Display(Name = "text_PnpReferenciaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpReferenciaS { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "text_PnpProveedorS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpProveedorS { get; set; }

        [Required]
        [Display(Name = "text_PnpCostoCompraUSDD", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public double SimPnpCostoCompraUSDD { get; set; }

        [Display(Name = "text_PnpTrmM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpTrmM { get; set; }

        [Required]
        [Display(Name = "text_PnpCntPedN", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public int SimPnpCntPedN { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "text_PnpDescripS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpDescripS { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "text_PnpTermNegocS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpTermNegocS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpSubLineaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpSubLineaS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpPaisOrigenS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpPaisOrigenS { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "text_PnpLineaS", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public string SimPnpLineaS { get; set; }

        //Pin Seguridad
        [Display(Name = "text_PnpPinSeguridadPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpPinSeguridadPesosM { get; set; }

        [Display(Name = "text_PnpPinSeguridadPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpPinSeguridadUsdF { get; set; }

        [Display(Name = "text_PnpPinSeguridadPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpPinSeguridadPorcF { get; set; }

        //Costo Compra
        [Display(Name = "text_PnpCostoCompraPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpCostoCompraPesosM { get; set; }

        [Display(Name = "text_PnpCostoCompraPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpCostoCompraUsdF { get; set; }

        [Display(Name = "text_PnpCostoCompraPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpCostoCompraPorcF { get; set; }

        //Gasto Origen
        [Display(Name = "text_PnpGastosOrigenPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosOrigenPesosM { get; set; }

        [Display(Name = "text_PnpGastosOrigenPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosOrigenUsdF { get; set; }

        [Display(Name = "text_PnpGastosOrigenPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosOrigenPorcF { get; set; }

        //Gasto Flete
        [Display(Name = "text_PnpGastosFletePesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosFletePesosM { get; set; }

        [Display(Name = "text_PnpGastosFletePesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosFleteUsdF { get; set; }

        [Display(Name = "text_PnpGastosFletePesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosFletePorcF { get; set; }

        //Arancel
        [Display(Name = "text_PnpGastosArancelPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosArancelPesosM { get; set; }

        [Display(Name = "text_PnpGastosArancelPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosArancelUsdF { get; set; }

        [Display(Name = "text_PnpGastosArancelPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosArancelPorcF { get; set; }

        //Seguro internacional
        [Display(Name = "text_PnpGastosSeguroPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosSeguroPesosM { get; set; }

        [Display(Name = "text_PnpGastosSeguroPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosSeguroUsdF { get; set; }

        [Display(Name = "text_PnpGastosSeguroPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosSeguroPorcF { get; set; }

        //Gasto Destino
        [Display(Name = "text_PnpGastosDestinoPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosDestinoPesosM { get; set; }

        [Display(Name = "text_PnpGastosDestinoPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosDestinoUsdF { get; set; }

        [Display(Name = "text_PnpGastosDestinoPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosDestinoPorcF { get; set; }

        //Otros Gastos
        [Display(Name = "text_PnpGastosOtrosPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosOtrosPesosM { get; set; }

        [Display(Name = "text_PnpGastosOtrosPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosOtrosUsdF { get; set; }

        [Display(Name = "text_PnpGastosOtrosPesosM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosOtrosPorcF { get; set; }

        //Total Costo Puesto Bodega
        [Display(Name = "text_PnpTotalCostoBodegaM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpTotalCostoBodegaM { get; set; }

        [Display(Name = "text_PnpTotalCostoBodegaM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpTotalCostoBodegaF { get; set; }

        //Adecuacion Producto
        [Display(Name = "text_PnpAdecuacionPrdM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpAdecuacionPrdM { get; set; }

        [Display(Name = "text_PnpAdecuacionPrdM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpAdecuacionPrdF { get; set; }

        //Sensorización
        [Display(Name = "text_PnpSensorizacionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpSensorizacionM { get; set; }

        [Display(Name = "text_PnpSensorizacionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpSensorizacionF { get; set; }

        //Arreglo producto
        [Display(Name = "text_PnpArregloM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpArregloM { get; set; }

        [Display(Name = "text_PnpArregloM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpArregloF { get; set; }

        //Reconstruccion Producto
        [Display(Name = "text_PnpReconstruccionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpReconstruccionM { get; set; }

        [Display(Name = "text_PnpReconstruccionM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpReconstruccionF { get; set; }

        //Gastos Administrativos ventas
        [Display(Name = "text_PnpGastosAdmonRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosAdmonRealM { get; set; }

        [Display(Name = "text_PnpGastosAdmonRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosAdmonRealF { get; set; }

        [Display(Name = "text_PnpGastosAdmonEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpGastosAdmonEstimadoM { get; set; }

        [Display(Name = "text_PnpGastosAdmonEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpGastosAdmonEstimadoF { get; set; }

        //Total Gastos + Costos
        [Display(Name = "text_PnpTotalCostosGastosRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpTotalCostosGastosRealM { get; set; }

        [Display(Name = "text_PnpTotalCostosGastosRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpTotalCostosGastosRealF { get; set; }

        [Display(Name = "text_PnpTotalCostosGastosEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpTotalCostosGastosEstimadoM { get; set; }

        [Display(Name = "text_PnpTotalCostosGastosEstimadoM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpTotalCostosGastosEstimadoF { get; set; }

        //Precio maximo con iva
        [Display(Name = "text_PnpPrecioMaxRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpPrecioMaxRealM { get; set; }

        [Display(Name = "text_PnpPrecioMaxRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpPrecioMaxEstimadoM { get; set; }

        //Margen Bruto %
        [Display(Name = "text_PnpMargenMaxBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMaxBrutoRealF { get; set; }

        [Display(Name = "text_PnpMargenMaxBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMaxBrutoEstimadoF { get; set; }

        //Margen operacional %
        [Display(Name = "text_PnpMargenMaxOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMaxOpeRealF { get; set; }

        [Display(Name = "text_PnpMargenMaxOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMaxOpeEstimadoF { get; set; }

        //Precio minimo con iva
        [Display(Name = "text_PnpPrecioMinRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpPrecioMinRealM { get; set; }

        [Display(Name = "text_PnpPrecioMinRealM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpPrecioMinEstimadoM { get; set; }

        //Margen bruto
        [Display(Name = "text_PnpMargenMinBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMinBrutoRealF { get; set; }

        [Display(Name = "text_PnpMargenMinBrutoEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMinBrutoEstimadoF { get; set; }

        //Margen operacional
        [Display(Name = "text_PnpMargenMinOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMinOpeRealF { get; set; }

        [Display(Name = "text_PnpMargenMinOpeEstimadoF", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public float SimPnpMargenMinOpeEstimadoF { get; set; }

        //Piramide Precios
        [Display(Name = "text_PnpEnterPriceM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpEnterPriceM { get; set; }

        [Display(Name = "text_PnpMediumPriceM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpMediumPriceM { get; set; }

        [Display(Name = "text_PnpPremiumPriceM", ResourceType = typeof(Resources.HojaCostoPNP.Index))]
        public decimal SimPnpPremiumPriceM { get; set; }

        //Estado orden de compra de unoee
        public string SimPnpEstadoOrdenCompraS { get; set; }
        //Fin

        //Estado de aprobacion de unoee
        public string SimPnpEstadoAprobacion { get; set; }
        //Fin

        //Precio aprobado registrado en unoee
        public decimal SimPnpPrecioD { get; set; }
        //Fin

        //Fecha de aprobacion
        public DateTime? SimPnpFechaAprobacionD { get; set; }
        //Fin

        //Moneda
        public string SimPnpMonedaS { get; set; }
        //Fin

        //Imagen Delantera
        public string SimPnpImagenS { get; set; }

        //Imagen Trasera
        public string SimPnpImagenTrasS { get; set; }

        //Fecha Creación
        public DateTime SimPnpFecCreD { get; set; }

        public string ID_Coleccion { get; set; }
        public string ID_Linea { get; set; }
        public string ID_Sublinea { get; set; }
    }
}