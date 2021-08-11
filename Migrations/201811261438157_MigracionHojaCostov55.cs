namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov55 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TBL_SIM_HOJA_COSTO_PNP");
            CreateTable(
                "dbo.TBL_REF_SINC",
                c => new
                    {
                        RsCodigoN = c.Int(nullable: false, identity: true),
                        RsColeccionS = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RsCodigoN);
            
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpEstadoOrdenCompraS", c => c.String());
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpEstadoAprobacion", c => c.String());
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpFechaAprobacionD", c => c.DateTime());
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMonedaS", c => c.String());
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpCodigoN", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpUsuCostoS", c => c.String(maxLength: 20));
            AddPrimaryKey("dbo.TBL_SIM_HOJA_COSTO_PNP", new[] { "SimPnpCodigoN", "SimPnpReferenciaS" });
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "PnpCodigoN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "PnpCodigoN", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.TBL_SIM_HOJA_COSTO_PNP");
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpUsuCostoS", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpCodigoN", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpMonedaS");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpFechaAprobacionD");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpPrecioD");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpEstadoAprobacion");
            DropColumn("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpEstadoOrdenCompraS");
            DropTable("dbo.TBL_REF_SINC");
            AddPrimaryKey("dbo.TBL_SIM_HOJA_COSTO_PNP", "SimPnpCodigoN");
        }
    }
}
