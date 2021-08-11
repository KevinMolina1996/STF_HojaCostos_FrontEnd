namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaB", c => c.Binary(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenB", c => c.Binary());
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenTrasB", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenTrasB", c => c.Byte(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenB", c => c.Byte(nullable: false));
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaB", c => c.Byte(nullable: false));
        }
    }
}
