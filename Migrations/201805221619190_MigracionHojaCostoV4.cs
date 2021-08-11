namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_HOJA_COSTO_PNP",
                c => new
                    {
                        PnpCodigoN = c.Int(nullable: false, identity: true),
                        PnpColeccionS = c.String(nullable: false, maxLength: 10),
                        PnpReferenciaS = c.String(nullable: false, maxLength: 50),
                        PnpProveedorS = c.String(nullable: false, maxLength: 60),
                        PnpCostoCompraUSDD = c.Double(nullable: false),
                        PnpTrmM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpCntPedN = c.Int(nullable: false),
                        PnpDescripS = c.String(nullable: false, maxLength: 100),
                        PnpTermNegocS = c.String(nullable: false, maxLength: 10),
                        PnpSubLineaS = c.String(nullable: false, maxLength: 50),
                        PnpPaisOrigenS = c.String(nullable: false, maxLength: 50),
                        PnpLineaS = c.String(nullable: false, maxLength: 50),
                        PnpCostoCompraPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpCostoCompraUsdF = c.Single(nullable: false),
                        PnpCostoCompraPorcF = c.Single(nullable: false),
                        PnpGastosOrigenPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosOrigenUsdF = c.Single(nullable: false),
                        PnpGastosOrigenPorcF = c.Single(nullable: false),
                        PnpGastosFletePesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosFleteUsdF = c.Single(nullable: false),
                        PnpGastosFletePorcF = c.Single(nullable: false),
                        PnpGastosArancelPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosArancelUsdF = c.Single(nullable: false),
                        PnpGastosArancelPorcF = c.Single(nullable: false),
                        PnpGastosSeguroPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosSeguroUsdF = c.Single(nullable: false),
                        PnpGastosSeguroPorcF = c.Single(nullable: false),
                        PnpGastosDestinoPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosDestinoUsdF = c.Single(nullable: false),
                        PnpGastosDestinoPorcF = c.Single(nullable: false),
                        PnpGastosOtrosPesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosOtrosUsdF = c.Single(nullable: false),
                        PnpGastosOtrosPorcF = c.Single(nullable: false),
                        PnpTotalCostoBodegaM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpTotalCostoBodegaF = c.Single(nullable: false),
                        PnpAdecuacionPrdM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpAdecuacionPrdF = c.Single(nullable: false),
                        PnpSensorizacionM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpSensorizacionF = c.Single(nullable: false),
                        PnpArregloM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpArregloF = c.Single(nullable: false),
                        PnpReconstruccionM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpReconstruccionF = c.Single(nullable: false),
                        PnpGastosAdmonM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpGastosAdmonF = c.Single(nullable: false),
                        PnpTotalCostosGastosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnpTotalCostosGastosF = c.Single(nullable: false),
                        PnpMargenMaxBrutoEstimadoF = c.Single(nullable: false),
                        PnpMargenMaxBrutoRealF = c.Single(nullable: false),
                        PnpMargenMaxOpeEstimadoF = c.Single(nullable: false),
                        PnpMargenMaxOpeRealF = c.Single(nullable: false),
                        PnpMargenMinBrutoEstimadoF = c.Single(nullable: false),
                        PnpMargenMinBrutoRealF = c.Single(nullable: false),
                        PnpMargenMinOpeEstimadoF = c.Single(nullable: false),
                        PnpMargenMinOpeRealF = c.Single(nullable: false),
                        PnpImagenS = c.String(),
                        PnpImagenTrasS = c.String(),
                        PnpFecCreD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PnpCodigoN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_HOJA_COSTO_PNP");
        }
    }
}
