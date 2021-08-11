namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_PRE_ANALISIS_PREC",
                c => new
                    {
                        PreApCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreApPrecMaxIvaEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreApPrecMaxIvaRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreApMargenMaxBrutoEstF = c.Single(nullable: false),
                        PreApMargenMaxBrutoRealF = c.Single(nullable: false),
                        PreApMargenMaxOpeEstF = c.Single(nullable: false),
                        PreApMargenMaxOpeRealF = c.Single(nullable: false),
                        PreApPrecMinIvaEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreApPrecMinIvaRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreApMargenMinBrutoEstF = c.Single(nullable: false),
                        PreApMargenMinBrutoRealF = c.Single(nullable: false),
                        PreApMargenMinOpeEstF = c.Single(nullable: false),
                        PreApMargenMinOpeRealF = c.Single(nullable: false),
                        PreApFecCreD = c.DateTime(nullable: false),
                        PreApFecActD = c.DateTime(),
                        PreApUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreApCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_HOJA_COSTO_PN",
                c => new
                    {
                        PreHcCodigoN = c.Int(nullable: false, identity: true),
                        PreHcReferenciaS = c.String(nullable: false, maxLength: 10),
                        PreHcColeccionS = c.String(nullable: false, maxLength: 50),
                        PreHcDisenadorS = c.String(nullable: false, maxLength: 50),
                        PreHcLineaS = c.String(nullable: false, maxLength: 50),
                        PreHcSubLineaS = c.String(nullable: false, maxLength: 50),
                        PreHcEstadoS = c.String(nullable: false, maxLength: 10),
                        PreHcEstadoAproS = c.String(nullable: false, maxLength: 10),
                        PreHcPatronistaS = c.String(nullable: false, maxLength: 50),
                        PreHcDescripcionS = c.String(maxLength: 200),
                        PreHcUsuCostoS = c.String(nullable: false, maxLength: 20),
                        PreHcMarcaS = c.String(nullable: false, maxLength: 20),
                        PreHcImgMarcaS = c.String(maxLength: 100),
                        PreHcTotalTelasD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalConTelasD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalProcesosD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalInsumoD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalMarquillaD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalCIFMODD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalCosPrdD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalGastosEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalGastosRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalxCanalEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcTotalxCanalRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcEnterPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcMediumPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcPremiumPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreHcImagenDS = c.String(),
                        PreHcImagenTS = c.String(),
                        PreHcFecCreD = c.DateTime(nullable: false),
                        PreHcFecActD = c.DateTime(),
                        PreHcUsuActS = c.String(),
                    })
                .PrimaryKey(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_CONSUMO_TELAS",
                c => new
                    {
                        PreCtCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreCtNombreS = c.String(maxLength: 100),
                        PreCtColorS = c.String(maxLength: 100),
                        PreCtCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreCtConF = c.Single(nullable: false),
                        PreCtTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreCtFecCreD = c.DateTime(nullable: false),
                        PreCtFecActD = c.DateTime(),
                        PreCtUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreCtCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_ETIQ_MAR_EMP",
                c => new
                    {
                        PreEmeCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreEmeNombreS = c.String(maxLength: 100),
                        PreEmeCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreEmeConF = c.Single(nullable: false),
                        PreEmeTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreEmeFecCreD = c.DateTime(nullable: false),
                        PreEmeFecActD = c.DateTime(),
                        PreEmeUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreEmeCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_INS_ACC",
                c => new
                    {
                        PreIaCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreIaNombreS = c.String(maxLength: 100),
                        PreIaColorS = c.String(maxLength: 100),
                        PreIaCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreIaConF = c.Single(nullable: false),
                        PreIaTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreIaFecCreD = c.DateTime(nullable: false),
                        PreIaFecActD = c.DateTime(),
                        PreIaUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreIaCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_MOD_CIF",
                c => new
                    {
                        PreMcCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreMcCostoManoObraD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreMcCostoIndirectosD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreMcFecCreD = c.DateTime(nullable: false),
                        PreMcFecActD = c.DateTime(),
                        PreMcUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreMcCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_PROCESO",
                c => new
                    {
                        PrePrCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PrePrDetalleS = c.String(nullable: false, maxLength: 50),
                        PrePrCostoM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrePrFecCreD = c.DateTime(nullable: false),
                        PrePrFecActD = c.DateTime(),
                        PrePrUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PrePrCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_RES_GAS_COS_DIS",
                c => new
                    {
                        PreRdCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreRdAdminEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdAdminRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdFinanEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdFinanRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdMercadeoEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdMercadeoRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdVentasxCanalEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdVentasxCanalRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRdFecCreD = c.DateTime(nullable: false),
                        PreRdFecActD = c.DateTime(),
                        PreRdUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreRdCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_PRE_RES_GEN_COS_PRD",
                c => new
                    {
                        PreRpCodigoN = c.Int(nullable: false, identity: true),
                        PreHcCodigoN = c.Int(nullable: false),
                        PreRpCostoMaterialesD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRpCostoConversionD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreRpFecCreD = c.DateTime(nullable: false),
                        PreRpFecActD = c.DateTime(),
                        PreRpUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.PreRpCodigoN)
                .ForeignKey("dbo.TBL_PRE_HOJA_COSTO_PN", t => t.PreHcCodigoN, cascadeDelete: true)
                .Index(t => t.PreHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_ANALISIS_PREC",
                c => new
                    {
                        SimApCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimApPrecMaxIvaEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimApPrecMaxIvaRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimApMargenMaxBrutoEstF = c.Single(nullable: false),
                        SimApMargenMaxBrutoRealF = c.Single(nullable: false),
                        SimApMargenMaxOpeEstF = c.Single(nullable: false),
                        SimApMargenMaxOpeRealF = c.Single(nullable: false),
                        SimApPrecMinIvaEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimApPrecMinIvaRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimApMargenMinBrutoEstF = c.Single(nullable: false),
                        SimApMargenMinBrutoRealF = c.Single(nullable: false),
                        SimApMargenMinOpeEstF = c.Single(nullable: false),
                        SimApMargenMinOpeRealF = c.Single(nullable: false),
                        SimApFecCreD = c.DateTime(nullable: false),
                        SimApFecActD = c.DateTime(),
                        SimApUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimApCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_HOJA_COSTO_PN",
                c => new
                    {
                        SimHcCodigoN = c.Int(nullable: false, identity: true),
                        SimHcReferenciaS = c.String(nullable: false, maxLength: 10),
                        SimHcColeccionS = c.String(nullable: false, maxLength: 50),
                        SimHcDisenadorS = c.String(nullable: false, maxLength: 50),
                        SimHcLineaS = c.String(nullable: false, maxLength: 50),
                        SimHcSubLineaS = c.String(nullable: false, maxLength: 50),
                        SimHcEstadoS = c.String(nullable: false, maxLength: 10),
                        SimHcEstadoAproS = c.String(nullable: false, maxLength: 10),
                        SimHcPatronistaS = c.String(nullable: false, maxLength: 50),
                        SimHcDescripcionS = c.String(maxLength: 200),
                        SimHcUsuCostoS = c.String(nullable: false, maxLength: 20),
                        SimHcMarcaS = c.String(nullable: false, maxLength: 20),
                        SimHcImgMarcaS = c.String(maxLength: 100),
                        SimHcTotalTelasD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalConTelasD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalProcesosD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalInsumoD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalMarquillaD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalCIFMODD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalCosPrdD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalGastosEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalGastosRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalxCanalEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcTotalxCanalRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcEnterPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcMediumPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcPremiumPriceD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimHcImagenDS = c.String(),
                        SimHcImagenTS = c.String(),
                        SimHcFecCreD = c.DateTime(nullable: false),
                        SimHcFecActD = c.DateTime(),
                        SimHcUsuActS = c.String(),
                    })
                .PrimaryKey(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_CONSUMO_TELAS",
                c => new
                    {
                        SimCtCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimCtNombreS = c.String(maxLength: 100),
                        SimCtColorS = c.String(maxLength: 100),
                        SimCtCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimCtConF = c.Single(nullable: false),
                        SimCtTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimCtFecCreD = c.DateTime(nullable: false),
                        SimCtFecActD = c.DateTime(),
                        SimCtUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimCtCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_ETIQ_MAR_EMP",
                c => new
                    {
                        SimEmeCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimEmeNombreS = c.String(maxLength: 100),
                        SimEmeCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimEmeConF = c.Single(nullable: false),
                        SimEmeTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimEmeFecCreD = c.DateTime(nullable: false),
                        SimEmeFecActD = c.DateTime(),
                        SimEmeUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimEmeCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_INS_ACC",
                c => new
                    {
                        SimIaCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimIaNombreS = c.String(maxLength: 100),
                        SimIaColorS = c.String(maxLength: 100),
                        SimIaCtsxMtD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimIaConF = c.Single(nullable: false),
                        SimIaTotalD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimIaFecCreD = c.DateTime(nullable: false),
                        SimIaFecActD = c.DateTime(),
                        SimIaUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimIaCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_MOD_CIF",
                c => new
                    {
                        SimMcCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimMcCostoManoObraD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimMcCostoIndirectosD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimMcFecCreD = c.DateTime(nullable: false),
                        SimMcFecActD = c.DateTime(),
                        SimMcUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimMcCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_PROCESO",
                c => new
                    {
                        SimPrCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimPrDetalleS = c.String(nullable: false, maxLength: 50),
                        SimPrCostoM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimPrFecCreD = c.DateTime(nullable: false),
                        SimPrFecActD = c.DateTime(),
                        SimPrUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimPrCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_RES_GAS_COS_DIS",
                c => new
                    {
                        SimRdCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimRdAdminEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdAdminRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdFinanEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdFinanRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdMercadeoEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdMercadeoRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdVentasxCanalEstD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdVentasxCanalRealD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRdFecCreD = c.DateTime(nullable: false),
                        SimRdFecActD = c.DateTime(),
                        SimRdUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimRdCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            CreateTable(
                "dbo.TBL_SIM_RES_GEN_COS_PRD",
                c => new
                    {
                        SimRpCodigoN = c.Int(nullable: false, identity: true),
                        SimHcCodigoN = c.Int(nullable: false),
                        SimRpCostoMaterialesD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRpCostoConversionD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SimRpFecCreD = c.DateTime(nullable: false),
                        SimRpFecActD = c.DateTime(),
                        SimRpUsuActS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SimRpCodigoN)
                .ForeignKey("dbo.TBL_SIM_HOJA_COSTO_PN", t => t.SimHcCodigoN, cascadeDelete: true)
                .Index(t => t.SimHcCodigoN);
            
            AddColumn("dbo.TBL_PROCESO", "PrFecCreD", c => c.DateTime(nullable: false));
            AddColumn("dbo.TBL_PROCESO", "PrFecActD", c => c.DateTime());
            AddColumn("dbo.TBL_PROCESO", "PrUsuActS", c => c.String(maxLength: 20));
            DropColumn("dbo.TBL_PROCESO", "HcFecCreD");
            DropColumn("dbo.TBL_PROCESO", "HcFecActD");
            DropColumn("dbo.TBL_PROCESO", "HcUsuActS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PROCESO", "HcUsuActS", c => c.String(maxLength: 20));
            AddColumn("dbo.TBL_PROCESO", "HcFecActD", c => c.DateTime());
            AddColumn("dbo.TBL_PROCESO", "HcFecCreD", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.TBL_SIM_RES_GEN_COS_PRD", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_RES_GAS_COS_DIS", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_PROCESO", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_MOD_CIF", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_INS_ACC", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_ETIQ_MAR_EMP", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_CONSUMO_TELAS", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_SIM_ANALISIS_PREC", "SimHcCodigoN", "dbo.TBL_SIM_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_RES_GEN_COS_PRD", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_PROCESO", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_MOD_CIF", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_INS_ACC", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_ETIQ_MAR_EMP", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_CONSUMO_TELAS", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropForeignKey("dbo.TBL_PRE_ANALISIS_PREC", "PreHcCodigoN", "dbo.TBL_PRE_HOJA_COSTO_PN");
            DropIndex("dbo.TBL_SIM_RES_GEN_COS_PRD", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_RES_GAS_COS_DIS", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_PROCESO", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_MOD_CIF", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_INS_ACC", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_ETIQ_MAR_EMP", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_CONSUMO_TELAS", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_SIM_ANALISIS_PREC", new[] { "SimHcCodigoN" });
            DropIndex("dbo.TBL_PRE_RES_GEN_COS_PRD", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_RES_GAS_COS_DIS", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_PROCESO", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_MOD_CIF", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_INS_ACC", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_ETIQ_MAR_EMP", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_CONSUMO_TELAS", new[] { "PreHcCodigoN" });
            DropIndex("dbo.TBL_PRE_ANALISIS_PREC", new[] { "PreHcCodigoN" });
            DropColumn("dbo.TBL_PROCESO", "PrUsuActS");
            DropColumn("dbo.TBL_PROCESO", "PrFecActD");
            DropColumn("dbo.TBL_PROCESO", "PrFecCreD");
            DropTable("dbo.TBL_SIM_RES_GEN_COS_PRD");
            DropTable("dbo.TBL_SIM_RES_GAS_COS_DIS");
            DropTable("dbo.TBL_SIM_PROCESO");
            DropTable("dbo.TBL_SIM_MOD_CIF");
            DropTable("dbo.TBL_SIM_INS_ACC");
            DropTable("dbo.TBL_SIM_ETIQ_MAR_EMP");
            DropTable("dbo.TBL_SIM_CONSUMO_TELAS");
            DropTable("dbo.TBL_SIM_HOJA_COSTO_PN");
            DropTable("dbo.TBL_SIM_ANALISIS_PREC");
            DropTable("dbo.TBL_PRE_RES_GEN_COS_PRD");
            DropTable("dbo.TBL_PRE_RES_GAS_COS_DIS");
            DropTable("dbo.TBL_PRE_PROCESO");
            DropTable("dbo.TBL_PRE_MOD_CIF");
            DropTable("dbo.TBL_PRE_INS_ACC");
            DropTable("dbo.TBL_PRE_ETIQ_MAR_EMP");
            DropTable("dbo.TBL_PRE_CONSUMO_TELAS");
            DropTable("dbo.TBL_PRE_HOJA_COSTO_PN");
            DropTable("dbo.TBL_PRE_ANALISIS_PREC");
        }
    }
}
