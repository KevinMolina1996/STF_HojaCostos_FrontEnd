namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV35 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxBrutoEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxOpeEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinBrutoEstimadoF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinOpeEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxBrutoEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxOpeEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinBrutoEstimadoF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinOpeEstimadoF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMinBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMargenMaxBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMinBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxOpeEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMargenMaxBrutoEstimadoF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
