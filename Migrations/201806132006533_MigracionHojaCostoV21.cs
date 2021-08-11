namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApPrecMaxIvaRealD");
            DropColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMaxBrutoRealF");
            DropColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMaxOpeRealF");
            DropColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApPrecMinIvaRealD");
            DropColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMinBrutoRealF");
            DropColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMinOpeRealF");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcTotalGastosRealD");
            DropColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcTotalxCanalRealD");
            DropColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdAdminRealD");
            DropColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdFinanRealD");
            DropColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdMercadeoRealD");
            DropColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdVentasxCanalRealD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdVentasxCanalRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdMercadeoRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdFinanRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_RES_GAS_COS_DIS", "PreRdAdminRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcTotalxCanalRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_HOJA_COSTO_PN", "PreHcTotalGastosRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMinOpeRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMinBrutoRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApPrecMinIvaRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMaxOpeRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApMargenMaxBrutoRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_PRE_ANALISIS_PREC", "PreApPrecMaxIvaRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
