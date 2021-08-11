namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadPesosM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadUsdF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadPorcF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPinSeguridadPesosM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPinSeguridadUsdF", c => c.Single(nullable: false));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPinSeguridadPorcF", c => c.Single(nullable: false));
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpAvalS");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadS");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpAvalS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpAvalS", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadS", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpAvalS", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPinSeguridadPorcF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPinSeguridadUsdF");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPinSeguridadPesosM");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadPorcF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadUsdF");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadPesosM");
        }
    }
}
