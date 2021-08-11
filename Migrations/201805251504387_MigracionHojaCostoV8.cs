namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_SIM_HOJA_COSTO_PNP",
                c => new
                    {
                        SimPnpCodigoN = c.Int(nullable: false, identity: true),
                        SimPnpEstadoS = c.String(nullable: false, maxLength: 10),
                        SimPnpUsuCostoS = c.String(nullable: false, maxLength: 20),
                        SimPnpOrdenCompraS = c.String(nullable: false, maxLength: 50),
                        SimPnpMarcaS = c.String(nullable: false, maxLength: 20),
                        SimPnpAvalS = c.String(nullable: false, maxLength: 50),
                        SimPnpColeccionS = c.String(nullable: false, maxLength: 10),
                        SimPnpReferenciaS = c.String(nullable: false, maxLength: 50),
                        SimPnpProveedorS = c.String(nullable: false, maxLength: 60),
                        SimPnpCostoCompraUSDD = c.Double(nullable: false),
                        SimPnpTrmM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpCntPedN = c.Int(nullable: false),
                        SimPnpDescripS = c.String(nullable: false, maxLength: 100),
                        SimPnpTermNegocS = c.String(nullable: false, maxLength: 10),
                        SimPnpSubLineaS = c.String(nullable: false, maxLength: 50),
                        SimPnpPaisOrigenS = c.String(nullable: false, maxLength: 50),
                        SimPnpLineaS = c.String(nullable: false, maxLength: 50),
                        SimPnpCostoCompraPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpCostoCompraUsdF = c.Single(nullable: false),
                        SimPnpCostoCompraPorcF = c.Single(nullable: false),
                        SimPnpGastosOrigenPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosOrigenUsdF = c.Single(nullable: false),
                        SimPnpGastosOrigenPorcF = c.Single(nullable: false),
                        SimPnpGastosFletePesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosFleteUsdF = c.Single(nullable: false),
                        SimPnpGastosFletePorcF = c.Single(nullable: false),
                        SimPnpGastosArancelPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosArancelUsdF = c.Single(nullable: false),
                        SimPnpGastosArancelPorcF = c.Single(nullable: false),
                        SimPnpGastosSeguroPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosSeguroUsdF = c.Single(nullable: false),
                        SimPnpGastosSeguroPorcF = c.Single(nullable: false),
                        SimPnpGastosDestinoPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosDestinoUsdF = c.Single(nullable: false),
                        SimPnpGastosDestinoPorcF = c.Single(nullable: false),
                        SimPnpGastosOtrosPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosOtrosUsdF = c.Single(nullable: false),
                        SimPnpGastosOtrosPorcF = c.Single(nullable: false),
                        SimPnpTotalCostoBodegaM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpTotalCostoBodegaF = c.Single(nullable: false),
                        SimPnpAdecuacionPrdM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpAdecuacionPrdF = c.Single(nullable: false),
                        SimPnpSensorizacionM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpSensorizacionF = c.Single(nullable: false),
                        SimPnpArregloM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpArregloF = c.Single(nullable: false),
                        SimPnpReconstruccionM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpReconstruccionF = c.Single(nullable: false),
                        SimPnpGastosAdmonM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpGastosAdmonF = c.Single(nullable: false),
                        SimPnpTotalCostosGastosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpTotalCostosGastosF = c.Single(nullable: false),
                        SimPnpMargenMaxBrutoEstimadoF = c.Single(nullable: false),
                        SimPnpMargenMaxBrutoRealF = c.Single(nullable: false),
                        SimPnpMargenMaxOpeEstimadoF = c.Single(nullable: false),
                        SimPnpMargenMaxOpeRealF = c.Single(nullable: false),
                        SimPnpMargenMinBrutoEstimadoF = c.Single(nullable: false),
                        SimPnpMargenMinBrutoRealF = c.Single(nullable: false),
                        SimPnpMargenMinOpeEstimadoF = c.Single(nullable: false),
                        SimPnpMargenMinOpeRealF = c.Single(nullable: false),
                        SimPnpEnterPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpMediumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpPremiumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPnpImagenS = c.String(),
                        SimPnpImagenTrasS = c.String(),
                        SimPnpFecCreD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SimPnpCodigoN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_SIM_HOJA_COSTO_PNP");
        }
    }
}
