namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov47 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PN", "HcFechaAprobacionD", c => c.DateTime());
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpFechaAprobacionD", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpFechaAprobacionD");
            DropColumn("dbo.TBL_HOJA_COSTO_PN", "HcFechaAprobacionD");
        }
    }
}
