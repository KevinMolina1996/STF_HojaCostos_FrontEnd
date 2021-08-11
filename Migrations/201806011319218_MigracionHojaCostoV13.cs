namespace AppWebHojaCosto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionHojaCostoV13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaB", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_HOJA_COSTO_PNP", "PnpMarcaB", c => c.Binary(nullable: false));
        }
    }
}
