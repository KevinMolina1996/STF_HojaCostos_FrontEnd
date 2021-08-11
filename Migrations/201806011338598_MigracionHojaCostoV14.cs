namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaB");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenB");
            DropColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenTrasB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenTrasB", c => c.Binary());
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpImagenB", c => c.Binary());
            AddColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaB", c => c.Binary());
        }
    }
}
