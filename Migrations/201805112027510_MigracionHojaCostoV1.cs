namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_ALERTA",
                c => new
                    {
                        AlCodigoN = c.Int(nullable: false, identity: true),
                        AlMensajeS = c.String(),
                        AlEstadoS = c.String(),
                        AlFecCreD = c.DateTime(nullable: false),
                        AlUsuarioS = c.String(),
                        AlTituloS = c.String(),
                    })
                .PrimaryKey(t => t.AlCodigoN);
            
            CreateTable(
                "dbo.TBL_ANALISIS_PREC",
                c => new
                    {
                        ApCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        ApPrecMaxIvaEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApPrecMaxIvaRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApMargenMaxBrutoEstF = c.Single(nullable: false),
                        ApMargenMaxBrutoRealF = c.Single(nullable: false),
                        ApMargenMaxOpeEstF = c.Single(nullable: false),
                        ApMargenMaxOpeRealF = c.Single(nullable: false),
                        ApPrecMinIvaEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApPrecMinIvaRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApMargenMinBrutoEstF = c.Single(nullable: false),
                        ApMargenMinBrutoRealF = c.Single(nullable: false),
                        ApMargenMinOpeEstF = c.Single(nullable: false),
                        ApMargenMinOpeRealF = c.Single(nullable: false),
                        ApFecCreD = c.DateTime(nullable: false),
                        ApFecActD = c.DateTime(),
                        ApUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ApCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_HOJA_COSTO_PN",
                c => new
                    {
                        HcCodigoN = c.Int(nullable: false, identity: true),
                        HcReferenciaS = c.String(nullable: false, maxLength: 10),
                        HcColeccionS = c.String(nullable: false, maxLength: 50),
                        HcDisenadorS = c.String(nullable: false, maxLength: 50),
                        HcLineaS = c.String(nullable: false, maxLength: 50),
                        HcSubLineaS = c.String(nullable: false, maxLength: 50),
                        HcEstadoS = c.String(nullable: false, maxLength: 10),
                        HcPatronistaS = c.String(nullable: false, maxLength: 50),
                        HcMarcaS = c.String(nullable: false, maxLength: 20),
                        HcTotalTelasM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalConTelasM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalProcesosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalInsumoM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalMarquillaM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalCIFMODM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalCosPrdM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalGastosM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcTotalxCanalM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcEnterPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcMediumPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcPremiumPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcImagenDS = c.String(),
                        HcImagenTS = c.String(),
                        HcFecCreD = c.DateTime(nullable: false),
                        HcFecActD = c.DateTime(),
                        HcUsuActS = c.String(),
                    })
                .PrimaryKey(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_CONSUMO_TELAS",
                c => new
                    {
                        CtCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        CtNombreS = c.String(maxLength: 100),
                        CtColorS = c.String(maxLength: 100),
                        CtCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CtConF = c.Single(nullable: false),
                        CtTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CtFecCreD = c.DateTime(nullable: false),
                        CtFecActD = c.DateTime(),
                        CtUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CtCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_ETIQ_MAR_EMP",
                c => new
                    {
                        EmeCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        EmeNombreS = c.String(maxLength: 100),
                        EmeCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmeConF = c.Single(nullable: false),
                        EmeTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmeFecCreD = c.DateTime(nullable: false),
                        EmeFecActD = c.DateTime(),
                        EmeUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.EmeCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_FORMULA",
                c => new
                    {
                        FoCodigoN = c.Int(nullable: false, identity: true),
                        FoNombreS = c.String(),
                        FoOperacionS = c.String(),
                        FoConsultaS = c.String(),
                        FoFecCreD = c.DateTime(nullable: false),
                        FoFecActD = c.DateTime(),
                    })
                .PrimaryKey(t => t.FoCodigoN);
            
            CreateTable(
                "dbo.TBL_INS_ACC",
                c => new
                    {
                        IaCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        IaNombreS = c.String(maxLength: 100),
                        IaColorS = c.String(maxLength: 100),
                        IaCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IaConF = c.Single(nullable: false),
                        IaTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IaFecCreD = c.DateTime(nullable: false),
                        IaFecActD = c.DateTime(),
                        IaUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IaCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_MOD_CIF",
                c => new
                    {
                        McCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        McCostoManoObraD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        McCostoIndirectosD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        McFecCreD = c.DateTime(nullable: false),
                        McFecActD = c.DateTime(),
                        McUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.McCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_PARAM_PN",
                c => new
                    {
                        PpCodigoN = c.Int(nullable: false, identity: true),
                        PpColeccionS = c.String(),
                        PpMarcaS = c.String(),
                        PpLineaS = c.String(),
                        PpSubLineaS = c.String(),
                        PpFactorS = c.String(),
                        PpMargenMinF = c.Double(nullable: false),
                        PpMargenMaxF = c.Double(nullable: false),
                        PpMayorUSDUtilF = c.Double(nullable: false),
                        PpAlmacenLineaAdminF = c.Double(nullable: false),
                        PpMayorUSDAdminF = c.Double(nullable: false),
                        PpAlmacenLineaFinanF = c.Double(nullable: false),
                        PpMayorUSDFinanF = c.Double(nullable: false),
                        PpAlmacenLineaMercadeoF = c.Double(nullable: false),
                        PpMayorUSDMercadeoF = c.Double(nullable: false),
                        PpGastosAdminF = c.Double(nullable: false),
                        PpGastosFinanF = c.Double(nullable: false),
                        PpGastosMercadeoF = c.Double(nullable: false),
                        PpAlmacenLineaVntsF = c.Double(nullable: false),
                        PpMayorUSDVntsF = c.Double(nullable: false),
                        PpTasaColeccionF = c.Double(nullable: false),
                        PpTasaEspecialF = c.Double(nullable: false),
                        PpTasaCambioEURxUSDF = c.Double(nullable: false),
                        PpIvaF = c.Double(nullable: false),
                        PpAdminxFinanF = c.Double(nullable: false),
                        PpMercadeoF = c.Double(nullable: false),
                        PpVntsxCanalLineaF = c.Double(nullable: false),
                        PpAlmacenLineaCanalF = c.Double(nullable: false),
                        PpTopeCostoF = c.Double(nullable: false),
                        PpFactorRentabilidadMaxF = c.Double(nullable: false),
                        PpFactorRentabilidadMinF = c.Double(nullable: false),
                        PpEnterPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PpMediumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PpPremiumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PpCocienteDivisorF = c.Double(nullable: false),
                        PpCocienteDivisor2F = c.Double(nullable: false),
                        PpResiduoDivisorF = c.Double(nullable: false),
                        PpTopePrecioMilesF = c.Double(nullable: false),
                        PpPrecioMinimoF = c.Double(nullable: false),
                        PpPrecioMaximoF = c.Double(nullable: false),
                        PpTerminoPrecioF = c.Double(nullable: false),
                        PpFecCreD = c.DateTime(nullable: false),
                        PpFecActD = c.DateTime(),
                        PpUsuActS = c.String(),
                    })
                .PrimaryKey(t => t.PpCodigoN);
            
            CreateTable(
                "dbo.TBL_PARAM_PNP",
                c => new
                    {
                        PnCodigoN = c.Int(nullable: false, identity: true),
                        PnColeccionS = c.String(),
                        PnMarcaS = c.String(),
                        PnLineaS = c.String(),
                        PnSubLineaS = c.String(),
                        PnFactorS = c.String(),
                        PnPinSeguridadF = c.Double(nullable: false),
                        PnGastosOrigenF = c.Double(nullable: false),
                        PnGastosFleteF = c.Double(nullable: false),
                        PnArancelF = c.Double(nullable: false),
                        PnSeguroIntF = c.Double(nullable: false),
                        PnGastosDestF = c.Double(nullable: false),
                        PnOtrosGastosF = c.Double(nullable: false),
                        PnAdcPrdM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnSensorizacionM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnArregloPrdM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnReconstruccionM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnGastosEstimadoF = c.Double(nullable: false),
                        PnGastosRealesM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnFactorMinF = c.Double(nullable: false),
                        PnFactorMaxF = c.Double(nullable: false),
                        PnIvaF = c.Double(nullable: false),
                        PnTRMF = c.Double(nullable: false),
                        PnEnterpriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnMediumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnPremiumPriceM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PnFecCreD = c.DateTime(nullable: false),
                        PnFecActD = c.DateTime(),
                        PnUsuActS = c.String(),
                    })
                .PrimaryKey(t => t.PnCodigoN);
            
            CreateTable(
                "dbo.TBL_PROCESO",
                c => new
                    {
                        PrCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        PrDetalleS = c.String(nullable: false, maxLength: 50),
                        PrCostoM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HcFecCreD = c.DateTime(nullable: false),
                        HcFecActD = c.DateTime(),
                        HcUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PrCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_RES_GAS_COS_DIS",
                c => new
                    {
                        RdCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        RdAdminEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdAdminRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdFinanEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdFinanRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdMercadeoEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdMercadeoRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdVentasxCanalEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdVentasxCanalRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RdFecCreD = c.DateTime(nullable: false),
                        RdFecActD = c.DateTime(),
                        RdUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RdCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
            CreateTable(
                "dbo.TBL_RES_GEN_COS_PRD",
                c => new
                    {
                        RpCodigoN = c.Int(nullable: false, identity: true),
                        HcCodigoN = c.Int(nullable: false),
                        RpCostoMaterialesD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RpCostoConversionD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RpFecCreD = c.DateTime(nullable: false),
                        RpFecActD = c.DateTime(),
                        RpUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RpCodigoN)
                .ForeignKey("dbo.TBL_HOJA_COSTO_PN", t => t.HcCodigoN, cascadeDelete: true)
                .Index(t => t.HcCodigoN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_RES_GEN_COS_PRD", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_RES_GAS_COS_DIS", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PROCESO", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_MOD_CIF", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_INS_ACC", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_ETIQ_MAR_EMP", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_CONSUMO_TELAS", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_ANALISIS_PREC", "HcCodigoN", "dbo.TBL_HOJA_COSTO_PN");
            DropIndex("dbo.TBL_RES_GEN_COS_PRD", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_RES_GAS_COS_DIS", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_PROCESO", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_MOD_CIF", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_INS_ACC", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_ETIQ_MAR_EMP", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_CONSUMO_TELAS", new[] { "HcCodigoN" });
            DropIndex("dbo.TBL_ANALISIS_PREC", new[] { "HcCodigoN" });
            DropTable("dbo.TBL_RES_GEN_COS_PRD");
            DropTable("dbo.TBL_RES_GAS_COS_DIS");
            DropTable("dbo.TBL_PROCESO");
            DropTable("dbo.TBL_PARAM_PNP");
            DropTable("dbo.TBL_PARAM_PN");
            DropTable("dbo.TBL_MOD_CIF");
            DropTable("dbo.TBL_INS_ACC");
            DropTable("dbo.TBL_FORMULA");
            DropTable("dbo.TBL_ETIQ_MAR_EMP");
            DropTable("dbo.TBL_CONSUMO_TELAS");
            DropTable("dbo.TBL_HOJA_COSTO_PN");
            DropTable("dbo.TBL_ANALISIS_PREC");
            DropTable("dbo.TBL_ALERTA");
        }
    }
}
