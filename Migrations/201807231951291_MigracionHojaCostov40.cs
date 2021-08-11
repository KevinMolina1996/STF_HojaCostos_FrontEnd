namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosRealF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosEstimadoF", c => c.Single(nullable: false));
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosRealF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpTotalCostosGastosRealM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosRealF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpTotalCostosGastosRealM");
        }
    }
}
