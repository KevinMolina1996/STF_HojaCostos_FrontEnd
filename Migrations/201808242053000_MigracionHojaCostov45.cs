namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcPrecioD", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEstadoOrdenCompraS", c => c.String());
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEstadoAprobacion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEstadoAprobacion");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpEstadoOrdenCompraS");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcPrecioD");
        }
    }
}
