namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinOpeEstimadoF", c => c.Single(nullable: false));
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinOpeEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinBrutoEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxOpeEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxBrutoEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonRealF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpGastosAdmonRealM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinOpeEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinBrutoEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxOpeEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxBrutoEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonRealF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpGastosAdmonRealM");
        }
    }
}
