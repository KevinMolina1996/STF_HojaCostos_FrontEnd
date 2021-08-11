namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinEstimadoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinRealM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinRealM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMinEstimadoM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxRealM");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioMaxEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinRealM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMinEstimadoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxRealM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPrecioMaxEstimadoM");
        }
    }
}
