namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostov10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadS", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenB", c => c.Byte(nullable: false));
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenTrasB", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenTrasB");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenB");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpPinSeguridadS");
        }
    }
}
