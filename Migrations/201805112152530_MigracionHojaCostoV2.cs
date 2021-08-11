namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalTelasD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalConTelasD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalProcesosD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalInsumoD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalMarquillaD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCIFMODD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCosPrdD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalGastosEstD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalGastosRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalxCanalEstD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalxCanalRealD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalTelasM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalConTelasM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalProcesosM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalInsumoM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalMarquillaM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCIFMODM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCosPrdM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalGastosM");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalxCanalM");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalxCanalM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalGastosM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCosPrdM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCIFMODM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalMarquillaM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalInsumoM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalProcesosM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalConTelasM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalTelasM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalxCanalRealD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalxCanalEstD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalGastosRealD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalGastosEstD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCosPrdD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalCIFMODD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalMarquillaD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalInsumoD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalProcesosD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalConTelasD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcTotalTelasD");
        }
    }
}
